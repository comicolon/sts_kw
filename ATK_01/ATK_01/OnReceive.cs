using AxKHOpenAPILib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATK_01
{
	public class OnReceive
	{
        private readonly AxKHOpenAPILib.AxKHOpenAPI OpenAPI = MainForm.mainForm.axKHOpenAPI1;

		public OnReceive()
		{
			OpenAPI.OnReceiveTrData += api_OnReceiveTrData;					// tr 데이터 받기
			OpenAPI.OnReceiveTrCondition += api_OnReceiveTrCondition;		// 검색종목 요청 받기
			OpenAPI.OnReceiveRealCondition += api_OnReceiveRealCondition;	// 검색종목 요청 실시간 받기
			OpenAPI.OnReceiveRealData += api_onReceiveRealData;				// 실시간 종목 상태 받기
			OpenAPI.OnReceiveMsg += api_OnReceiveMsg;						// 주문요청시 메세지
			OpenAPI.OnReceiveChejanData += api_OnReceiveChejanData;			// 주문 요청시 결과값 받기

		}

		//TR 데이터 요청시 받는 메소드
		private void api_OnReceiveTrData(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e)
		{
			if (e.sRQName == "계좌평가잔고내역")
				InstanceManager.balanceManager.ResponsBalance(e);
			else if (e.sRQName == "주식호가요청")
			{
				InstanceManager.bookWindowManager.ResponsBookData(e);
			}
			else if (e.sRQName == "주식분봉차트조회요청")
				InstanceManager.chartManager.ResponsChartData(e);
			else if (e.sRQName == "주식기본정보요청")
				InstanceManager.itemManager.ProcTrItemData(e);
			else if (e.sRQName == "체결정보요청")
				InstanceManager.bookWindowManager.ResponsContractInfo(e);
			else if (e.sRecordName == "시세표성정보요청")
				InstanceManager.itemManager.ProcTrItemData(e);
		}

		private void api_OnReceiveTrCondition (object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
		{
			InstanceManager.conditionManager.SetTrCondition(e);
		}

		private void api_OnReceiveRealCondition(object sender, _DKHOpenAPIEvents_OnReceiveRealConditionEvent e)
		{
			InstanceManager.conditionManager.ProcRealCondition(e);
		}

		private void api_onReceiveRealData(object sender, _DKHOpenAPIEvents_OnReceiveRealDataEvent e)
		{
			if ((e.sRealType == "주식호가잔량" || e.sRealType == "주식체결") && InstanceManager.bookWindowManager.isReady == true)
			{
				InstanceManager.bookWindowManager.ResponsBookRealData(e);
			}
			InstanceManager.itemManager.ProcRealItemData(e);
		}

		private void api_OnReceiveMsg(object sender, _DKHOpenAPIEvents_OnReceiveMsgEvent e)
		{
			InstanceManager.tradeManager.OnReceiveMsg(e);
		}

		//주문접수시 한번 호출되고 체결 될때마다 0과 1을 구분값으로 두번씩 호출된다.
		private void api_OnReceiveChejanData(object sender, _DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
		{
			InstanceManager.tradeManager.ProcChejanData(e);
		}
	}
}
