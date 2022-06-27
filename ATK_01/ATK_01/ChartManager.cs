using AxKHOpenAPILib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace ATK_01
{
	public class ChartManager
	{
		Series maSeries;

		public string nowChartItemCode = "";
		public itemInfo nowChartItem;

		DateTime timeNin = new DateTime();
		int minTic = 3;

		public List<PreChartUpdate> preChartUpdateList = new List<PreChartUpdate>();

		public ChartManager()
		{
			InstanceManager.mainForm.firstChart.Series["Series1"].CustomProperties = "PriceDownColor=Blue, PriceUpColor=Red";
			maSeries = new Series();
			maSeries.Color = Color.Gold;
			maSeries.ChartType = SeriesChartType.Spline;

			Timer chartTimer = new Timer();
			chartTimer.Interval = 10;
			chartTimer.Tick += new EventHandler(UpdateChartTimer);
			chartTimer.Start();
		}

		//분봉차트 조회 요청
		public void RequestChartMin(string itemCode, string tic)
		{
			if (itemCode.Length > 0)
			{
				timeNin = DateTime.Now;     // 요청시간을 기록

				nowChartItemCode = itemCode;		// 요청종목 코드
				nowChartItem = InstanceManager.itemInfoList.Find(obj => obj.itemCode == itemCode);      // 요청종목 객체
				minTic = int.Parse(tic);
				InstanceManager.mainForm.firstChart.Titles["chartTitle"].Text = nowChartItem.itemName;
				preChartUpdateList.Clear();

				Console.WriteLine("차트조회 함수 종목 : " + nowChartItem.itemName);

				InstanceManager.OpenAPI.SetInputValue("종목코드", itemCode);
				InstanceManager.OpenAPI.SetInputValue("틱범위", tic);
				InstanceManager.OpenAPI.SetInputValue("수정주가구분", "0");

				InstanceManager.OpenAPI.CommRqData("주식분봉차트조회요청", "opt10080", 0, InstanceManager.Functions.GetScreenNum());
			}
		}

		//일봉차트 조회 요청
		public void RequestChartDay(string itemCode)
		{

		}

		//틱봉차트 조회 요청
		public void RequestChartTic(string itemCode)
		{

		}

		//차트 데이터를 그려준다.
		internal void ResponsChartData(_DKHOpenAPIEvents_OnReceiveTrDataEvent e)
		{
			if (e.sRQName == "주식분봉차트조회요청")
			{
				int count = Config.MIN_CHART_NUM_LIMIT;
				int ReceiveCount = InstanceManager.OpenAPI.GetRepeatCnt(e.sTrCode, e.sRQName);
				if (ReceiveCount < count)			// 이상 데이터 수신시 리턴
					return;

				//차트를 그려준다
				InstanceManager.mainForm.firstChart.Series["Series1"].Points.Clear();
				InstanceManager.mainForm.firstChart.Series["Series2"].Points.Clear();
				preChartUpdateList.Clear();

				for (int i = 0; i < count; i++)
				{
					long 현재가 = Math.Abs(long.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "현재가")));
					long 시가 = Math.Abs(long.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "시가")));
					long 저가 = Math.Abs(long.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "저가")));
					long 고가 = Math.Abs(long.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "고가")));
					long 거래량 = long.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "거래량"));
					string 체결시간 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, i, "체결시간").Trim().Substring(4,8);

					PreChartUpdate preChartUpdate = new PreChartUpdate();

					preChartUpdateList.Add(preChartUpdate);
					preChartUpdateList[i].string1 = 현재가.ToString();
					preChartUpdateList[i].string2 = 시가.ToString();
					preChartUpdateList[i].string3 = 저가.ToString();
					preChartUpdateList[i].string4 = 고가.ToString();
					preChartUpdateList[i].string5 = 거래량.ToString();
					preChartUpdateList[i].string6 = 체결시간;

					int index = InstanceManager.mainForm.firstChart.Series["Series1"].Points.AddXY(체결시간, 고가);
					InstanceManager.mainForm.firstChart.Series["Series1"].Points[index].YValues[1] = 저가;
					InstanceManager.mainForm.firstChart.Series["Series1"].Points[index].YValues[2] = 시가;
					InstanceManager.mainForm.firstChart.Series["Series1"].Points[index].YValues[3] = 현재가;

					if (시가 < 현재가)
					{
						InstanceManager.mainForm.firstChart.Series["Series1"].Points[index].Color = Color.Red;
						InstanceManager.mainForm.firstChart.Series["Series1"].Points[index].BorderColor = Color.Red;
					}
					else if (시가 > 현재가)
					{
						InstanceManager.mainForm.firstChart.Series["Series1"].Points[index].Color = Color.Blue;
						InstanceManager.mainForm.firstChart.Series["Series1"].Points[index].BorderColor = Color.Blue;
					}

					InstanceManager.mainForm.firstChart.Series["Series2"].Points.AddXY(체결시간, 거래량);
				}
			}

			//이동평균선을 그려준다.
			if (InstanceManager.mainForm.firstChart.Series.Contains(maSeries))
				InstanceManager.mainForm.firstChart.Series.Remove(maSeries);
			DrawMALine(20);
	
		}

		public void UpdateChart()
		{
			InstanceManager.mainForm.firstChart.Series["Series1"].Points.Clear();
			InstanceManager.mainForm.firstChart.Series["Series2"].Points.Clear();

			long 현재가 = 0;
			if (preChartUpdateList != null)
			{
				for (int i = 0; i < Config.MIN_CHART_NUM_LIMIT; i++)
				{
					if (i == 0 && nowChartItem.현재가 != null)
					{
						현재가 = Math.Abs(long.Parse(nowChartItem.현재가));
					}
					else
					{
						현재가 = long.Parse(preChartUpdateList[i].string1);
					}

					long 시가 = long.Parse(preChartUpdateList[i].string2);
					long 저가 = long.Parse(preChartUpdateList[i].string3);
					long 고가 = long.Parse(preChartUpdateList[i].string4);
					long 거래량 = long.Parse(preChartUpdateList[i].string5);
					string 체결시간 = preChartUpdateList[i].string6;

					int index = InstanceManager.mainForm.firstChart.Series["Series1"].Points.AddXY(체결시간, 고가);
					InstanceManager.mainForm.firstChart.Series["Series1"].Points[index].YValues[1] = 저가;
					InstanceManager.mainForm.firstChart.Series["Series1"].Points[index].YValues[2] = 시가;
					InstanceManager.mainForm.firstChart.Series["Series1"].Points[index].YValues[3] = 현재가;

					if (시가 < 현재가)
					{
						InstanceManager.mainForm.firstChart.Series["Series1"].Points[index].Color = Color.Red;
						InstanceManager.mainForm.firstChart.Series["Series1"].Points[index].BorderColor = Color.Red;
					}
					else if (시가 > 현재가)
					{
						InstanceManager.mainForm.firstChart.Series["Series1"].Points[index].Color = Color.Blue;
						InstanceManager.mainForm.firstChart.Series["Series1"].Points[index].BorderColor = Color.Blue;
					}

					InstanceManager.mainForm.firstChart.Series["Series2"].Points.AddXY(체결시간, 거래량);
				}
			}

			//이동평균선을 그려준다.
			if (InstanceManager.mainForm.firstChart.Series.Contains(maSeries))
				InstanceManager.mainForm.firstChart.Series.Remove(maSeries);
			DrawMALine(20);
	
		}

		//축 변경시 처리
		internal void DrawChangedChart(ViewEventArgs e)
		{
			int startPosition = (int)e.Axis.ScaleView.ViewMinimum;
			int endPosition = (int)e.Axis.ScaleView.ViewMaximum;

			//price chart y출 리스케일
			double priceyMinValue = double.MaxValue;
			double priceyMaxValue = double.MinValue;

			double volumeYMimvalue = double.MaxValue;
			double volumeYMaxvalue = double.MinValue;

			for (int i = startPosition; i < endPosition; i++)
			{
				Series priceSeries = InstanceManager.mainForm.firstChart.Series["Series1"];
				Series volumeSeries = InstanceManager.mainForm.firstChart.Series["Series2"];

				if (i < priceSeries.Points.Count)
				{
					priceyMaxValue = Math.Max(priceyMaxValue, priceSeries.Points[i].YValues[0]);
					priceyMinValue = Math.Min(priceyMinValue, priceSeries.Points[i].YValues[1]);
				}

				if (i < volumeSeries.Points.Count)
				{
					volumeYMaxvalue = Math.Max(volumeYMaxvalue, volumeSeries.Points[i].YValues[0]);
					volumeYMimvalue = Math.Min(volumeYMimvalue, volumeSeries.Points[i].YValues[0]);
				}

			}
			InstanceManager.mainForm.firstChart.ChartAreas["priceChartArea"].AxisY.Maximum = priceyMaxValue;
			InstanceManager.mainForm.firstChart.ChartAreas["priceChartArea"].AxisY.Minimum = priceyMinValue;

			InstanceManager.mainForm.firstChart.ChartAreas["volumeChartArea"].AxisY.Maximum = volumeYMaxvalue;
			//firstChart.ChartAreas["volumeChartArea"].AxisY.Minimum = volumeYMimvalue;
		}

		//이동평균선 추가
		private void DrawMALine(int ma_Period)
		{
			Series priceSeries = InstanceManager.mainForm.firstChart.Series["Series1"];

			maSeries.Points.Clear();

			for (int i = 0; i < priceSeries.Points.Count; i++)
			{
				if (i + ma_Period < priceSeries.Points.Count)
				{
					long priceSum = 0;
					for (int j = 0; j < ma_Period; j++)
					{
						priceSum += (long)priceSeries.Points[i + j].YValues[3];
					}

					double priceAverage = priceSum / ma_Period;
					maSeries.Points.AddXY(priceSeries.Points[i].XValue, priceAverage);
				}
			}

			InstanceManager.mainForm.firstChart.Series.Add(maSeries);
			maSeries.ChartArea = "priceChartArea";
		}

		// 차트 타이머 업데이트
		private void UpdateChartTimer(object sender, EventArgs e)
		{
			//3분마다 데이터를 조회한다
			if (nowChartItem != null)
			{
				if (InstanceManager.Functions.GetDiffTime(timeNin) >= minTic * 60)
				{
					Console.WriteLine("3분마다 데이터 조회");
					RequestChartMin(nowChartItemCode, "3");
				}
			}
				 
			if (nowChartItem != null)
			{
				if (InstanceManager.mainForm.firstChart.Series["Series1"].Points.Count > 0 && preChartUpdateList.Count > 0)
				{
					UpdateChart();
				}
			}
		}
			
	}

	public class PreChartUpdate
	{
		public string string1;
		public string string2;
		public string string3;
		public string string4;
		public string string5;
		public string string6;
	}
}
