using AxKHOpenAPILib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;


namespace ATK_01
{
	public class OrderManager
	{
		public int onOrderCnt = 0;
		public int offOrderCnt = 0;

		public OrderManager()
		{
			Timer OrderCheckTimer = new System.Windows.Forms.Timer();   // 오더체크 타이머
			OrderCheckTimer.Interval = 400;
			OrderCheckTimer.Tick += new EventHandler(CheckOrder);
			OrderCheckTimer.Start();
		}

		

		// 미체결 주문 수 계산
		public void SetOderCnt()
		{
			for (int i = 0; i < InstanceManager.ordersList.Count; i++)
			{
				if (InstanceManager.ordersList[i].orderCntNot == "")
					continue;

				if (int.Parse(InstanceManager.ordersList[i].orderCntNot) > 0 && InstanceManager.ordersList[i].isContract == true)
				{
					onOrderCnt++;
				}
				
			}
		}

		// 그리드 체크박스 인잇			당분간 사용 안함
		internal void InitOrderGrid(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (e.ColumnIndex == 0 && e.RowIndex == -1)
			{
				e.PaintBackground(e.ClipBounds, false);
				Point pt = e.CellBounds.Location; // where you want the bitmap in the cell

				int nChkBoxWidth = 15;
				int nChkBoxHeight = 15;
				int offsetx = (e.CellBounds.Width - nChkBoxWidth) / 2;
				int offsety = (e.CellBounds.Height - nChkBoxHeight) / 2;

				pt.X = offsetx;
				pt.Y = offsety;

				CheckBox cb = new CheckBox();
				cb.Size = new Size(nChkBoxWidth, nChkBoxHeight);
				cb.Location = pt;
				cb.LocationChanged += new EventHandler(gvSheetListCheckBox_CheckedChanged);

				((DataGridView)sender).Controls.Add(cb);

				e.Handled = true;
			}
		}

		// 그리드 체크 박스용			당분간 사용 안함
		private void gvSheetListCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			foreach(DataGridViewRow r in InstanceManager.mainForm.order_GridView.Rows)
			{
				r.Cells["colCheck"].Value = ((CheckBox)sender).Checked;
			}
		}

		internal void SetOrderData(_DKHOpenAPIEvents_OnReceiveChejanDataEvent e, itemInfo item)
		{
			Orders order = null;

			if (e.sGubun.Equals("0"))   //접수 또는 체결
			{

				string account = InstanceManager.OpenAPI.GetChejanData(9201).Trim();      //계좌번호
				string orderNumber = InstanceManager.OpenAPI.GetChejanData(9203).Trim();  //주문번호
				string orderState = InstanceManager.OpenAPI.GetChejanData(913).Trim(); // 접수 또는 체결을 구분하는 인자값
				string itemCode = InstanceManager.OpenAPI.GetChejanData(9001).Trim().Substring(1);  // 종목코드
				string itemName = InstanceManager.OpenAPI.GetChejanData(302).Trim();   //종목명
				string orderCnt = InstanceManager.OpenAPI.GetChejanData(900).Trim();   //주문수량
				string orderPrice = InstanceManager.OpenAPI.GetChejanData(901).Trim(); //주문가격
				string orderCntNot = InstanceManager.OpenAPI.GetChejanData(902).Trim();    //미체결수량
				string contractPriceSum = InstanceManager.OpenAPI.GetChejanData(903).Trim();   //체결누계금액
				string orgOrderNum = InstanceManager.OpenAPI.GetChejanData(904).Trim();        //원주문번호
				string orderTypeGubun = InstanceManager.OpenAPI.GetChejanData(905).Trim();		// 주문 구분
				string orderDiv = InstanceManager.OpenAPI.GetChejanData(907).Trim();       // 1.매도 2. 매수
				string orderTime = InstanceManager.OpenAPI.GetChejanData(908).Trim();		//주문/ 체결 시간
				string contractPrice = InstanceManager.OpenAPI.GetChejanData(910).Trim();  //체결가
				string contractCnt = InstanceManager.OpenAPI.GetChejanData(911).Trim();    //체결량
				string screenNum = InstanceManager.OpenAPI.GetChejanData(920).Trim();      //화면번호

				Console.WriteLine("orderTypeGubun : " + orderTypeGubun);

				if (orderState.Equals("접수"))
				{
					order = InstanceManager.ordersList.Find(obj => obj.orderNum == orderNumber);
					if (order == null)
						order = new Orders(itemCode, orderNumber);     //새로운 오더 생성 

					order.account = account;
					order.itemName = itemName;
					order.orderState = orderState;
					order.orderCnt = orderCnt;
					order.orderPrice = orderPrice;
					order.orderCntNot = orderCntNot;
					order.orgOrderNum = orgOrderNum;
					order.orderTypeGubun = orderTypeGubun;
					order.orderDiv = orderDiv;
					order.orderTime = orderTime;
					order.screenNum = screenNum;

					InstanceManager.ordersList.Add(order);

					SetInOrderGridView(order);
					UpdateOrderGridView(order);			// 주문취소시 업데이트
				}
				else if (orderState.Equals("체결"))
				{
					order = InstanceManager.ordersList.Find(obj => obj.orderNum == orderNumber);
					if (order != null)
					{
						order.orderState = orderState;
						order.orderCntNot = orderCntNot;
						order.contractPriceSum = contractPriceSum;
						order.contractPrice = contractPrice;
						order.contractCnt = contractCnt;
						order.orderTypeGubun = orderTypeGubun;

						UpdateOrderGridView(order);
					}
				}
				else if (orderState.Equals("확인"))
				{
					order = InstanceManager.ordersList.Find(obj => obj.orderNum == orderNumber);
					if (order != null)
					{
						order.orderState = orderState;
						order.orderTypeGubun = orderTypeGubun;
						order.orderCntNot = contractCnt;
					}

					UpdateOrderGridView(order);
				}
			}

		}

		// 오더 그리드뷰 추가
		public void SetInOrderGridView(Orders order)
		{
			if (order == null)
				return;

			DataGridView grid = InstanceManager.mainForm.order_GridView;
		
			grid.Rows.Add(false,
				(order.orderDiv == "1") ? "매도" : "매수",
				order.itemName,
				order.orderTypeGubun,
				order.orderPrice,
				order.orderCnt,
				order.orderCntNot,
				"취소",
				order.orderNum);

		}

		// 오더 그리드뷰 업데이트
		private void UpdateOrderGridView(Orders order)
		{
			if (order == null)
				return;

			string cancleOrderNum = "";
			if (order.orderTypeGubun == "매수취소" || order.orderTypeGubun == "매도취소")
			{
				order.isCancle = true;
			}

			if (order.orderState == "확인" && order.isCancle == true)
			{
				cancleOrderNum = order.orderNum;
			}

			for (int i = 0; i < InstanceManager.mainForm.order_GridView.Rows.Count; i++)
			{
				if (InstanceManager.mainForm.order_GridView.Rows[i].Cells[8].Value.ToString() == cancleOrderNum)
				{
					InstanceManager.mainForm.order_GridView.Rows.Remove(InstanceManager.mainForm.order_GridView.Rows[i]);
				}
			}
		}

		// 주문취소 처리
		internal void CancelOrder(string orderNum)
		{
			if (orderNum == "" || orderNum == null)
				return;

			Orders order = InstanceManager.ordersList.Find(obj => obj.orderNum == orderNum);
			int orderTypeNum = 0;

			if (order.orderDiv == "1")
				orderTypeNum = 4;
			else if (order.orderDiv == "2")
				orderTypeNum = 3;

			int orderResult = InstanceManager.OpenAPI.SendOrder("주식취소주문",
				InstanceManager.Functions.GetScreenNum(),
				InstanceManager.mainForm.accountComboBox.Text,
				orderTypeNum,
				order.itemCode,
				0,
				0,
				"00",
				order.orderNum
				);

			if (orderResult == 0)
			{
				Console.WriteLine("취소요청 성공");
			}
			else
			{
				Console.WriteLine("취소요청 실패");
			}


		}

		// 오더 체크 함수
		private void CheckOrder(object sender, EventArgs e)
		{
			SetOderCnt();
			if (onOrderCnt == 0)
				return;

			for (int i = 0; i < InstanceManager.ordersList.Count; i++)
			{
				if (InstanceManager.ordersList[i].orderCntNot == "")
					continue;

				if (int.Parse(InstanceManager.ordersList[i].orderCntNot) > 0 && (InstanceManager.ordersList[i].orderState == "접수" || InstanceManager.ordersList[i].orderState == "체결"))
				{
					string orderTimeString = InstanceManager.ordersList[i].orderTime.Substring(0, 2) + ":" +
						InstanceManager.ordersList[i].orderTime.Substring(2, 2) + ":" +
						InstanceManager.ordersList[i].orderTime.Substring(4, 2);

					DateTime orderTime = Convert.ToDateTime(orderTimeString);

					if (InstanceManager.Functions.GetDiffTime(orderTime) >= 60)
					{
						CancelOrder(InstanceManager.ordersList[i].orderNum);
					}
				}
			}

		}
	}
}
