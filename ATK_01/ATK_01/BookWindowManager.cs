using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AxKHOpenAPILib;
using System.Windows.Forms;
using System.Drawing;

namespace ATK_01
{
	public class BookWindowManager
	{
		public int Bid_Range = 20;
		public itemInfo nowBookItem;
		public string nowBookItemCode = "";
		public  BiddingEntityObject[] biddingEntityArray;

		int maxAmount = 0;
		String contractPrice;

		public bool isReady = false;
		public BookWindowManager()
		{
			int itemHieght = (int)(InstanceManager.mainForm.listBox_book_quoteUp.Height / 9.8);

			InstanceManager.mainForm.listBox_book_bidAmount.DrawItem += this.ListBox_DrawItem;
			InstanceManager.mainForm.listBox_book_bidAmount.DrawMode = DrawMode.OwnerDrawVariable;
			InstanceManager.mainForm.listBox_book_bidAmount.ItemHeight = itemHieght;
			InstanceManager.mainForm.listBox_book_bidAmount.Enabled = false;

			InstanceManager.mainForm.listBox_book_adkAmount.DrawItem += this.ListBox_DrawItem;
			InstanceManager.mainForm.listBox_book_adkAmount.DrawMode = DrawMode.OwnerDrawVariable;
			InstanceManager.mainForm.listBox_book_adkAmount.ItemHeight = itemHieght;
			InstanceManager.mainForm.listBox_book_adkAmount.Enabled = false;

			InstanceManager.mainForm.listBox_book_quoteUp.DrawItem += this.ListBox_DrawItem;
			InstanceManager.mainForm.listBox_book_quoteUp.DrawMode = DrawMode.OwnerDrawVariable;
			InstanceManager.mainForm.listBox_book_quoteUp.ItemHeight = itemHieght;
			InstanceManager.mainForm.listBox_book_quoteUp.Enabled = false;

			InstanceManager.mainForm.listBox_book_quoteDown.DrawItem += this.ListBox_DrawItem;
			InstanceManager.mainForm.listBox_book_quoteDown.DrawMode = DrawMode.OwnerDrawVariable;
			InstanceManager.mainForm.listBox_book_quoteDown.ItemHeight = itemHieght;
			InstanceManager.mainForm.listBox_book_quoteDown.Enabled = false;


			InstanceManager.mainForm.listView_book_contract.HeaderStyle = ColumnHeaderStyle.None;


			InstanceManager.mainForm.listView_book_contract.View = View.Details;
			InstanceManager.mainForm.listView_book_contract.Columns.Add("체결가");
			InstanceManager.mainForm.listView_book_contract.Columns[0].Width = (int)(InstanceManager.mainForm.listView_book_contract.Width / 2.3);
			InstanceManager.mainForm.listView_book_contract.Columns.Add("체결량");
			InstanceManager.mainForm.listView_book_contract.Columns[1].Width = (int)(InstanceManager.mainForm.listView_book_contract.Width / 2.3);
			InstanceManager.mainForm.listView_book_contract.Columns[1].TextAlign = HorizontalAlignment.Right;

			biddingEntityArray = new BiddingEntityObject[Bid_Range];

		}


		internal void RequestBook(itemInfo item)
		{
			if (item.itemCode.Length > 0)
			{
				Console.WriteLine("호가창 조회 함수 실행");
				nowBookItem = item;
				nowBookItemCode = item.itemCode;

				Task task = new Task(() =>
				{
					Console.WriteLine("this");
					InstanceManager.OpenAPI.SetInputValue("종목코드", item.itemCode);
					InstanceManager.OpenAPI.CommRqData("주식기본정보요청", "opt10001", 0, InstanceManager.Functions.GetScreenNum());
				});
				InstanceManager.trRequestManager.RequestTrData(task);


				//Task task = new Task(() =>
				//{
					InstanceManager.OpenAPI.SetInputValue("종목코드", item.itemCode);
					InstanceManager.OpenAPI.CommRqData("주식호가요청", "OPT10004", 0, InstanceManager.Functions.GetScreenNum());
				//});
				//trRequestManager.RequestTrData(task);

			}
		}

		// 주식 호가요청 데이타 받기
		internal void ResponsBookData(_DKHOpenAPIEvents_OnReceiveTrDataEvent e)
		{
			if (nowBookItem == null)
				return;

			if (e.sRQName == "주식호가요청")
			{
				InstanceManager.mainForm.listBox_book_adkAmount.Items.Clear();
				InstanceManager.mainForm.listBox_book_bidAmount.Items.Clear();
				InstanceManager.mainForm.listBox_book_quoteUp.Items.Clear();
				InstanceManager.mainForm.listBox_book_quoteDown.Items.Clear();
				InstanceManager.mainForm.listView_book_contract.Items.Clear();

				for (int i = 0; i < 10; i++)
				{
					if (i == 9)
					{
						InstanceManager.mainForm.listBox_book_quoteUp.Items.Add(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "매도최우선호가").Trim());
						InstanceManager.mainForm.listBox_book_adkAmount.Items.Add(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "매도최우선잔량").Trim());
					}
					else
					{
						InstanceManager.mainForm.listBox_book_quoteUp.Items.Add(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "매도" + (10 - i) + "차선호가").Trim());
						if (i == 4)
							InstanceManager.mainForm.listBox_book_adkAmount.Items.Add(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "매도6우선잔량").Trim());
						else
							InstanceManager.mainForm.listBox_book_adkAmount.Items.Add(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "매도" + (10 - i) + "차선잔량").Trim());
					}
				}

				for (int i = 0; i < 10; i++)
				{
					if (i == 0)
					{
						InstanceManager.mainForm.listBox_book_quoteDown.Items.Add(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "매수최우선호가").Trim());
						InstanceManager.mainForm.listBox_book_bidAmount.Items.Add(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "매수최우선잔량").Trim());
					}
					else
					{
						if (i == 5)
						{
							InstanceManager.mainForm.listBox_book_quoteDown.Items.Add(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "매수6우선호가").Trim());
							InstanceManager.mainForm.listBox_book_bidAmount.Items.Add(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "매수6우선잔량").Trim());
						}
						else
						{
							InstanceManager.mainForm.listBox_book_quoteDown.Items.Add(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "매수" + (i + 1) + "차선호가").Trim());
							InstanceManager.mainForm.listBox_book_bidAmount.Items.Add(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "매수" + (i + 1) + "차선잔량").Trim());
						}
					}
				}

				nowBookItem.총매도잔량 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총매도잔량").Trim();
				nowBookItem.총매수잔량 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총매수잔량").Trim();

				InstanceManager.OpenAPI.SetInputValue("종목코드", nowBookItemCode);
				InstanceManager.OpenAPI.CommRqData("체결정보요청", "OPT10003", 0, "9999");
			}

			isReady = true;
		}

		// 체결 정보 받음
		public void ResponsContractInfo(_DKHOpenAPIEvents_OnReceiveTrDataEvent e)
		{
			if (e.sRQName == "체결정보요청")
			{
				int nCnt = InstanceManager.OpenAPI.GetRepeatCnt(e.sTrCode, e.sRQName);
				for (int nIdx = 0; nIdx < nCnt; nIdx++)
				{
					ListViewItem listViewItem = new ListViewItem(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, nIdx, "현재가").Trim().Replace("+", "").Replace("-", ""));
					listViewItem.SubItems.Add(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, nIdx, "체결거래량").Trim());
					listViewItem.UseItemStyleForSubItems = false;

					if (nowBookItem.기준가 == null)
						return;
					
					if (int.Parse(listViewItem.SubItems[0].Text) > Math.Abs(int.Parse(nowBookItem.기준가)))
						listViewItem.SubItems[0].ForeColor = Color.Red;
					else if (int.Parse(listViewItem.SubItems[0].Text) == Math.Abs(int.Parse(nowBookItem.기준가)))
						listViewItem.SubItems[0].ForeColor = Color.Black;
					else if (int.Parse(listViewItem.SubItems[0].Text) < Math.Abs(int.Parse(nowBookItem.기준가)))
						listViewItem.SubItems[0].ForeColor = Color.Blue;

					if (int.Parse(listViewItem.SubItems[1].Text) > 0)
						listViewItem.SubItems[1].ForeColor = Color.Red;
					else if (int.Parse(listViewItem.SubItems[1].Text) < 0)
						listViewItem.SubItems[1].ForeColor = Color.Blue;

					if (Math.Abs(int.Parse(listViewItem.SubItems[0].Text) * int.Parse(listViewItem.SubItems[1].Text)) >= 100000000)
						listViewItem.SubItems[1].BackColor = Color.LightYellow;

					InstanceManager.mainForm.listView_book_contract.Items.Add(listViewItem);

				}

				SetTotalAmount();
				SetBookBasicInfo();
			}
		}

		// 실시간 호가잔량 받음
		internal void ResponsBookRealData(_DKHOpenAPIEvents_OnReceiveRealDataEvent e)
		{
			if (nowBookItem == null)
				return;
			if (nowBookItemCode != e.sRealKey)
				return;

			if (e.sRealType == "주식호가잔량")
			{
				maxAmount = 0;
				for (int i = 0; i < 10; i++)
				{
					biddingEntityArray[i] = new BiddingEntityObject()
					{
						호가 = InstanceManager.OpenAPI.GetCommRealData(e.sRealType, 50 - i).Trim(),
						잔량 = InstanceManager.OpenAPI.GetCommRealData(e.sRealType, 70 - i).Trim(),
						잔량대비 = InstanceManager.OpenAPI.GetCommRealData(e.sRealType, 90 - i).Trim(),
					};
					//Console.WriteLine( "상승호가 : "+ OpenAPI.GetCommRealData(e.sRealType, 50 - i).Trim());

					biddingEntityArray[i + 10] = new BiddingEntityObject()
					{
						호가 = InstanceManager.OpenAPI.GetCommRealData(e.sRealType, 51 + i).Trim(),
						잔량 = InstanceManager.OpenAPI.GetCommRealData(e.sRealType, 71 + i).Trim(),
						잔량대비 = InstanceManager.OpenAPI.GetCommRealData(e.sRealType, 91 + i).Trim(),
					};
					//Console.WriteLine("하락호가 : " + OpenAPI.GetCommRealData(e.sRealType, 51 + i).Trim());

					int sellAmount = int.Parse(InstanceManager.OpenAPI.GetCommRealData(e.sRealType, 70 - i).Trim());
					int buyAmount = int.Parse(InstanceManager.OpenAPI.GetCommRealData(e.sRealType, 71 + i).Trim());

					if (maxAmount < sellAmount)
						maxAmount = sellAmount;
					if (maxAmount < buyAmount)
						maxAmount = buyAmount;
				}

				for (int i = 0; i < biddingEntityArray.Length; i++)
				{
					if (i < 10)
					{
						InstanceManager.mainForm.listBox_book_adkAmount.Items[i] = biddingEntityArray[i].잔량;
						InstanceManager.mainForm.listBox_book_quoteUp.Items[i] = biddingEntityArray[i].호가;
					}
					else
					{
						InstanceManager.mainForm.listBox_book_bidAmount.Items[i-10] = biddingEntityArray[i].잔량;
						InstanceManager.mainForm.listBox_book_quoteDown.Items[i-10] = biddingEntityArray[i].호가;
					}
				}

				SetTotalAmount();
				SetBookBasicInfo();

			}
			else if (e.sRealType == "주식체결")
			{

				String contractPrice = InstanceManager.OpenAPI.GetCommRealData(e.sRealType, 10).Trim();
				if (InstanceManager.mainForm.listBox_book_quoteUp.Items.IndexOf(contractPrice) > 0)
					InstanceManager.mainForm.listBox_book_quoteUp.Items[InstanceManager.mainForm.listBox_book_quoteUp.Items.IndexOf(contractPrice)] = "!" + contractPrice;
				else if (InstanceManager.mainForm.listBox_book_quoteDown.Items.IndexOf(contractPrice) > 0)
					InstanceManager.mainForm.listBox_book_quoteDown.Items[InstanceManager.mainForm.listBox_book_quoteDown.Items.IndexOf(contractPrice)] = "!" + contractPrice;

				//contractPrice = contractPrice.Replace("+", "").Replace("-", "");
				string contractVolume = InstanceManager.OpenAPI.GetCommRealData(e.sRealType, 15).Trim();

				ListViewItem listViewItem = new ListViewItem(contractPrice);
				listViewItem.SubItems.Add(contractVolume);
				listViewItem.UseItemStyleForSubItems = false;

				if (nowBookItem.기준가 == null)
					return;

				if (int.Parse(listViewItem.SubItems[0].Text) > Math.Abs(int.Parse(nowBookItem.기준가)))
					listViewItem.SubItems[0].ForeColor = Color.Red;
				else if (int.Parse(listViewItem.SubItems[0].Text) == Math.Abs(int.Parse(nowBookItem.기준가)))
					listViewItem.SubItems[0].ForeColor = Color.Black;
				else if (int.Parse(listViewItem.SubItems[0].Text) < Math.Abs(int.Parse(nowBookItem.기준가)))
					listViewItem.SubItems[0].ForeColor = Color.Blue;

				if (int.Parse(listViewItem.SubItems[1].Text) > 0)
					listViewItem.SubItems[1].ForeColor = Color.Red;
				else if (int.Parse(listViewItem.SubItems[1].Text) < 0)
					listViewItem.SubItems[1].ForeColor = Color.Blue;

				if (Math.Abs(int.Parse(listViewItem.SubItems[0].Text) * int.Parse(listViewItem.SubItems[1].Text)) >= 100000000)
					listViewItem.SubItems[1].BackColor = Color.Yellow;

				InstanceManager.mainForm.listView_book_contract.Items.Insert(0, listViewItem);
				//mainForm.listView_book_contract.Items.Insert(0, contractPrice);
				InstanceManager.mainForm.listView_book_contract.Items.RemoveAt(InstanceManager.mainForm.listView_book_contract.Items.Count - 1);

				//priceRateLabel.Text = OpenAPI.GetCommRealData(e.sRealType, 12).Trim() + "%";
				//tradeAmountLabel.Text = OpenAPI.GetCommRealData(e.sRealType, 13).Trim();
			}

		}

		//호가창 아래 그리드
		private void SetTotalAmount()
		{
			if (int.Parse (nowBookItem.총매도잔량) >= 0 && int.Parse(nowBookItem.총매수잔량) >= 0)
			{
				InstanceManager.mainForm.lb_book_총매도잔량.Text = nowBookItem.총매도잔량;
				InstanceManager.mainForm.lb_book_총매수잔량.Text = nowBookItem.총매수잔량;
				InstanceManager.mainForm.lb_book_총잔량차이.Text = Math.Abs(int.Parse(nowBookItem.총매도잔량) - int.Parse(nowBookItem.총매수잔량)).ToString();
				if (int.Parse(nowBookItem.총매도잔량) > int.Parse(nowBookItem.총매수잔량))
					InstanceManager.mainForm.lb_book_총잔량차이.ForeColor = Color.Blue;
				else if (int.Parse(nowBookItem.총매도잔량) < int.Parse(nowBookItem.총매수잔량))
					InstanceManager.mainForm.lb_book_총잔량차이.ForeColor = Color.Red;
				else
					InstanceManager.mainForm.lb_book_총잔량차이.ForeColor = Color.Black;
			}
		}

		// 호가창 위 그리드
		private void SetBookBasicInfo()
		{
			InstanceManager.mainForm.lb_book_nowPrice.Text = nowBookItem.현재가;
			if (int.Parse(nowBookItem.현재가) > 0)
				InstanceManager.mainForm.lb_book_nowPrice.ForeColor = Color.Red;
			else if (int.Parse(nowBookItem.현재가) < 0)
				InstanceManager.mainForm.lb_book_nowPrice.ForeColor = Color.Blue;

			InstanceManager.mainForm.lb_book_전일대비.Text = nowBookItem.전일대비;
			if (int.Parse(nowBookItem.현재가) > 0)
				InstanceManager.mainForm.lb_book_전일대비.ForeColor = Color.Red;
			else if (int.Parse(nowBookItem.전일대비) < 0)
				InstanceManager.mainForm.lb_book_전일대비.ForeColor = Color.Blue;

			InstanceManager.mainForm.lb_book_등락률.Text = nowBookItem.등락률;
			if (double.Parse(nowBookItem.등락률) > 0)
			{
				InstanceManager.mainForm.lb_book_등락률.Text = "▲ " + nowBookItem.등락률;
				InstanceManager.mainForm.lb_book_등락률.ForeColor = Color.Red;
			}
			else if (double.Parse(nowBookItem.등락률) < 0)
			{
				InstanceManager.mainForm.lb_book_등락률.Text = "▼ " + nowBookItem.등락률;
				InstanceManager.mainForm.lb_book_등락률.ForeColor = Color.Blue;
			}

			InstanceManager.mainForm.lb_book_volume.Text = nowBookItem.누적거래량;
		}


		private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (sender.Equals(InstanceManager.mainForm.listBox_book_quoteUp))
			{
				try
				{
					//if (e.Index < 10)
						e.Graphics.FillRectangle(Brushes.LightSteelBlue, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
					//else
						//e.Graphics.FillRectangle(Brushes.LightPink, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));

				
					String value = InstanceManager.mainForm.listBox_book_quoteUp.Items[e.Index].ToString();
					if (value[0] == '!')
					{
						value = value.Replace("!", "");
						contractPrice = value;
					}

					if (value.Equals(contractPrice))
						e.Graphics.DrawRectangle(new Pen(Brushes.Red), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));

					Brush brush = Brushes.Black;

					if (value[0] == '+')
						brush = Brushes.Red;
					else
						brush = Brushes.Blue;

					//Font의 Height를 더한 만큼 좌표를 변경합니다.
					int x = e.Bounds.X + e.Font.Height / 4;
					int y = e.Bounds.Y + e.Font.Height / 4;

					if (!value.Equals("-0"))
						e.Graphics.DrawString(value.Replace("+", "").Replace("-", ""), e.Font, brush, x, y, StringFormat.GenericDefault);
					e.DrawFocusRectangle();
				}
				catch (Exception exception)
				{
					Console.WriteLine(exception.Message.ToString());
				}
			}
			else if (sender.Equals(InstanceManager.mainForm.listBox_book_quoteDown))
			{
				try
				{
					//if (e.Index < 10)
						//e.Graphics.FillRectangle(Brushes.LightSteelBlue, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
					//else
						e.Graphics.FillRectangle(Brushes.LightPink, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));


					String value = InstanceManager.mainForm.listBox_book_quoteDown.Items[e.Index].ToString();
					if (value[0] == '!')
					{
						value = value.Replace("!", "");
						contractPrice = value;
					}

					if (value.Equals(contractPrice))
						e.Graphics.DrawRectangle(new Pen(Brushes.Red), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));

					Brush brush = Brushes.Black;

					if (value[0] == '+')
						brush = Brushes.Red;
					else
						brush = Brushes.Blue;

					//Font의 Height를 더한 만큼 좌표를 변경합니다.
					int x = e.Bounds.X + e.Font.Height / 4;
					int y = e.Bounds.Y + e.Font.Height / 4;

					if (!value.Equals("-0"))
						e.Graphics.DrawString(value.Replace("+", "").Replace("-", ""), e.Font, brush, x, y, StringFormat.GenericDefault);
					e.DrawFocusRectangle();
				}
				catch (Exception exception)
				{
					Console.WriteLine(exception.Message.ToString());
				}
			}

			else if (sender.Equals(InstanceManager.mainForm.listBox_book_adkAmount))
			{
				try
				{
					if (biddingEntityArray[e.Index] != null && !biddingEntityArray[e.Index].잔량.Equals("0"))
					{
						if (maxAmount > 0)
						{
							int rectWidth = e.Bounds.Width * int.Parse(InstanceManager.mainForm.listBox_book_adkAmount.Items[e.Index].ToString()) / maxAmount;
							e.Graphics.FillRectangle(Brushes.LightSkyBlue, new Rectangle(e.Bounds.X + e.Bounds.Width - rectWidth, e.Bounds.Y + 1, rectWidth, e.Bounds.Height - 2));
						}
					}

					//Font의 Height를 더한 만큼 좌표를 변경합니다.
					int x = e.Bounds.X + e.Font.Height / 4 + e.Bounds.Width / 2;
					int y = e.Bounds.Y + e.Font.Height / 4;

					e.Graphics.DrawString(InstanceManager.mainForm.listBox_book_adkAmount.Items[e.Index].ToString(),
						e.Font, Brushes.Black, x, y, StringFormat.GenericDefault);

					if (biddingEntityArray[e.Index] != null && !biddingEntityArray[e.Index].잔량대비.Equals("0"))
					{
						x = e.Bounds.X + e.Font.Height / 2;
						Brush brush;
						if (biddingEntityArray[e.Index].잔량대비[0] == '+')
							brush = Brushes.Red;
						else
							brush = Brushes.Blue;
						e.Graphics.DrawString(biddingEntityArray[e.Index].잔량대비,
						   e.Font, brush, x, y, StringFormat.GenericDefault);
					}
				}
				catch (Exception exception)
				{
					Console.WriteLine(exception.Message.ToString());
				}
			}
			else if (sender.Equals(InstanceManager.mainForm.listBox_book_bidAmount))
			{
				try
				{
					if (biddingEntityArray[e.Index] != null && !InstanceManager.mainForm.listBox_book_bidAmount.Items[e.Index].ToString().Equals("0"))
					{
						if (maxAmount > 0)
						{
							int rectWidth = e.Bounds.Width * int.Parse(InstanceManager.mainForm.listBox_book_bidAmount.Items[e.Index].ToString()) / maxAmount;
							e.Graphics.FillRectangle(Brushes.PaleVioletRed, new Rectangle(e.Bounds.X, e.Bounds.Y + 1, rectWidth, e.Bounds.Height - 2));
						}
					}

					//Font의 Height를 더한 만큼 좌표를 변경합니다.
					int x = e.Bounds.X + e.Font.Height / 4;
					int y = e.Bounds.Y + e.Font.Height / 4;

					e.Graphics.DrawString(InstanceManager.mainForm.listBox_book_bidAmount.Items[e.Index].ToString(),
						e.Font, Brushes.Black, x, y, StringFormat.GenericDefault);
					//e.DrawFocusRectangle();

					if (biddingEntityArray[e.Index] != null && !biddingEntityArray[e.Index].잔량대비.Equals("0"))
					{
						x = e.Bounds.X + e.Font.Height / 2 + e.Bounds.Width / 2;
						Brush brush;
						if (biddingEntityArray[e.Index].잔량대비[0] == '+')
							brush = Brushes.Red;
						else
							brush = Brushes.Blue;
						e.Graphics.DrawString(biddingEntityArray[e.Index].잔량대비,
						   e.Font, brush, x, y, StringFormat.GenericDefault);
						//e.DrawFocusRectangle();
					}
				}
				catch (Exception exception)
				{
					Console.WriteLine(exception.Message.ToString());
				}
			}


		}


		public class BiddingEntityObject
		{
			public String 호가 { get; set; }
			public String 잔량 { get; set; }
			public String 잔량대비 { get; set; }

		}
	}
}
