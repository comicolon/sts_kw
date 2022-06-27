using AxKHOpenAPILib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATK_01
{
	public class TradeManager
	{
        public TradeManager()
		{

		}

		// 종목 매수
		public int BuyItem(itemInfo item, string orderType)
		{
            if (Config.IS_TRADE_NOW == false)
			{
                Console.WriteLine("매수주문 요청 실패");
                return 0;
			}

            string itemCode = item.itemCode;
            string accountNum = InstanceManager.userInfo.USER_ACCOUNT[0];
            int orderTypeNum = InstanceManager.Functions.OrderTypeCode(orderType);
            string tradingType = "";
            string bitPrice = Config.TRADE_BID_PRICE;

            if (orderTypeNum == 1)
                tradingType = InstanceManager.Functions.TradingTypeCode(Config.TRADE_TYPE_CODE_BUY);

            int price = 0;
            if (tradingType == "00" || tradingType == "05" || tradingType == "10" || tradingType == "20")
                price = InstanceManager.Functions.GetPrice(item, orderType, bitPrice);
            else
                price = 0;

            int quantity = 0;
             quantity = InstanceManager.Functions.GetQuantity( price, item );

            Console.WriteLine("aaccountNum : " + accountNum + " orderTypeNum : " + orderTypeNum + " itemCode : " + itemCode + " quantity : " + quantity + " price : " + price + " tradingTyep : " + tradingType);

            string OrgOrderNo = "";

            //주식 주문
            int orderResult = InstanceManager.OpenAPI.SendOrder("주식매수주문", //사용자 구분명
                InstanceManager.Functions.GetScreenNum(),                   //화면번호
                accountNum,                                 //계좌번호
                orderTypeNum,                               //주문유형
                itemCode,                                   //종목코드
                quantity,                                   //주문수량
                price,                                      //주문가격
                tradingType,                                //거래구분
                OrgOrderNo                                  //원주문번호 //신규주문에는 공백, 정정(취소)주문할 원주문번호를 입력합니다.
                );

            if(orderResult == 0) // 주문 요청 성공
			{
                item.주문요청여부 = true;
                Orders order = new Orders(itemCode, "");
                return 1;
			}
            else
			{
                //주문 실패
                Console.WriteLine("매수주문 요청 실패");
                return 0;
			}
		}

        //종목 매도
        public int SellItem(itemInfo item , string orderType)
		{
            if (Config.IS_TRADE_NOW == false)
			{
                Console.WriteLine("매도주문요청 실패");
                return 0;
			}

            Balances balance = InstanceManager.balanceList.Find(obj => obj.itemCode == item.itemCode);

            string itemCode = item.itemCode;
            string accountNum = InstanceManager.mainForm.accountComboBox.Text;
            int orderTypeNum = InstanceManager.Functions.OrderTypeCode(orderType);
            string tradingType = "";
            string bitPrice = Config.TRADE_ASK_PRICE;

            if (orderTypeNum == 2)
                tradingType = InstanceManager.Functions.TradingTypeCode( Config.TRADE_TYPE_CODE_SELL);

            int price = 0;
            if (tradingType == "00" || tradingType == "05" || tradingType == "10" || tradingType == "20")
                price = InstanceManager.Functions.GetPrice(item, orderType, bitPrice);
            else
                price = 0;

            int quantity = 0;
            //if (price != 0)
            //    quantity = Functions.GetQuantity(price, item);
            quantity = int.Parse( balance.보유수량);

            string OrgOrderNo = "";

            //주식 주문
            int orderResult = InstanceManager.OpenAPI.SendOrder("주식매도주문", //사용자 구분명
               InstanceManager.Functions.GetScreenNum(),                   //화면번호
                accountNum,                                 //계좌번호
                orderTypeNum,                               //주문유형
                itemCode,                                   //종목코드
                quantity,                                   //주문수량
                price,                                      //주문가격
                tradingType,                                //거래구분
                OrgOrderNo                                  //원주문번호 //신규주문에는 공백, 정정(취소)주문할 원주문번호를 입력합니다.
                );

            if (orderResult == 0) // 주문 요청 성공
            {
                item.주문요청여부 = true;
                Orders order = new Orders(itemCode, "");
                return 1;
            }
            else
            {
				//주문 실패
				Console.WriteLine("매도주문요청 실패");
                return 0;
            }


        }

        //온리시브 메세지 (주문요청 확인용)
		internal void OnReceiveMsg(_DKHOpenAPIEvents_OnReceiveMsgEvent e)
		{
            string msg = e.sMsg;
            Console.WriteLine(msg);
            
            string rqName = e.sRQName;
            string screenNumber = e.sScrNo;
            string trCode = e.sTrCode;
            //Console.WriteLine(trCode);
        }

        //d온리시브체잔 데이터 처리
		internal void ProcChejanData(_DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
		{

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
                string contractPrice = InstanceManager.OpenAPI.GetChejanData(910).Trim();  //체결가
                string contractCnt = InstanceManager.OpenAPI.GetChejanData(911).Trim();    //체결량
                string screenNum = InstanceManager.OpenAPI.GetChejanData(920).Trim();      //화면번호

                itemInfo item = InstanceManager.itemInfoList.Find(obj => obj.itemCode == itemCode);

                InstanceManager.orderManager.SetOrderData(e, item);

                if (orderState.Equals("접수"))
				{
                    item.주문여부 = true;
                    item.주문시도여부 = false;
                    item.주문요청여부 = false;
				}
                else if (orderState.Equals("체결"))
				{
                    Orders order = InstanceManager.ordersList.Find(obj => obj.orderNum == orderNumber);
                    if (order != null)
					{
                        if (int.Parse(orderCntNot) == 0 || orderCntNot == "")
					    {
                            order.isContractPart = false;
                            order.isContract = true;
					    }
                        else if (int.Parse(contractCnt) > 0)
					    {
                            order.isContractPart = true;
                            order.isContract = false;
                            item.구매여부 = true;
					    }


                        if (orderDiv == "1" && orderCntNot == "0")       //매도체결이 모두 되었을 경우
                        {
                            item.구매여부 = false;
                            item.주문여부 = false;
                            item.점수 = Config.IN_ITEM_POINT_MAX;
                        }

                        else if (orderDiv == "2" && orderCntNot == "0") // 매수체결이 모두 되었을 경우
                        {
                            item.주문여부 = false;
                            item.구매여부 = true;
                        }
					}
				}
                else if (orderState.Equals("확인"))
				{
                    Orders order = InstanceManager.ordersList.Find(obj => obj.orderNum == orderNumber);
                    if (order != null)
					{
                        if (order.orderState == "확인" && (order.orderTypeGubun == "매수취소" || order.orderTypeGubun == "매도취소") && order.orderCntNot == "0")
						{
                            item.주문여부 = false;
                            
						}
                    }
                }

            }

            else if (e.sGubun.Equals("1")) // 잔고
			{

                string itemCode = InstanceManager.OpenAPI.GetChejanData(9001).Trim().Substring(1);  // 종목코드
                itemInfo item = InstanceManager.itemInfoList.Find(obj => obj.itemCode == itemCode);

                InstanceManager.balanceManager.ResponsBalance(item, e);

                //string 손익률 = OpenAPI.GetChejanData(8019).Trim();     //손익율
                //userInfo.예수금 = 예수금;
                

			}
            else if (e.sGubun.Equals("4")) //파생
			{

			}
		}
	}
}
