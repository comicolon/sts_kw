using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATK_01
{
	public class Orders
	{
		public string itemCode;		//종목코드
		public string orderNum;		//주문번호
		public string account;      //주문계좌
		public string orderState;	//주문상태
		public bool isContractPart = false;			//일부체결 여부
		public bool isContract = false;     //체결여부
		public string itemName = "";	//종목명
		public string orderCnt = "";	//주문수량
		public string orderPrice = "";	//주문가격
		public string orderCntNot = ""; //미체결수량
		public string contractPriceSum = ""; //체결누계금액
		public string orgOrderNum = "";		//원주문번호
		public string orderDiv = "";        // 1.매도 2.매수
		public string orderTime = "";		// 주문/체결 시간
		public string orderTypeGubun = "";	// 주문구분
		public string contractPrice = "";	// 체결가
		public string contractCnt = "";		// 체결량
		public string screenNum = "";       // 화면번호
		public bool isCancle = false;

		public Orders(string itemCode, string orderNum)
		{
			this.itemCode = itemCode;
			this.orderNum = orderNum;
		}
	}
}
