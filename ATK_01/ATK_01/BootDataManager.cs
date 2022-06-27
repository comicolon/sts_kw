using System;
using System.Drawing;
using System.Windows.Forms;
using AxKHOpenAPILib;


namespace ATK_01
{
	public class BootDataManager
	{
		public BootDataManager()
		{
			InstanceManager.OpenAPI.OnReceiveConditionVer += api_OnReceiveConditionVer;
		}

		public void LoginSucces()
		{
			requestUserInfo();          // 유저정보
			requestItemCodeList();		//종목 리스트
			RequestConditionList();     //조건식 리스트
			SetTradeTypeInForm();       //거래 유형을 불러와 세팅
			SetTradeQuoteInForm();      //거래 호가를 불러와 세팅
			InstanceManager.Functions.GetBalanceInfo(); //보유종목 인포 요청
			SetSearchBoxSource();       //서치박스 자동완성 소스 세팅
			InstanceManager.mainForm.tradeStartButton.Enabled = true;
			InstanceManager.mainForm.tradeStartButton.BackColor = Color.DarkRed; 
		}

		
		//유저 정보를 불러온다.
		private void requestUserInfo()
		{
			string name = InstanceManager.OpenAPI.GetLoginInfo("USER_NAME");
			InstanceManager.userInfo.USER_NAME = name;

			string id = InstanceManager.OpenAPI.GetLoginInfo("USER_ID");
			InstanceManager.userInfo.USER_ID = id;

			//계좌번호
			string account = InstanceManager.OpenAPI.GetLoginInfo("ACCLIST");
			string[] accountArray = account.Split(';');
			InstanceManager.userInfo.USER_ACCOUNT = new string[accountArray.Length]; // 계좌번호 배열 초기화

			for (int i = 0; i < accountArray.Length; i++)
			{
				if (accountArray[i].Length > 0 && accountArray[i] != null)
				{
					InstanceManager.userInfo.USER_ACCOUNT[i] = accountArray[i];
					MainForm.mainForm.accountComboBox.Items.Add(accountArray[i]);
				}
			}
			InstanceManager.mainForm.accountComboBox.SelectedIndex = 0; // 가장 처음값으로 세팅

			//서버구분
			string serverGubun = InstanceManager.OpenAPI.GetLoginInfo("GetServerGubun"); // 1 : 모의투자 , 나머지 : 실서버
			InstanceManager.userInfo.SERVER_GUBUN = serverGubun;
		}

		//종목리스트를 불러온다.
		private void requestItemCodeList()
		{
			for (int i = 0; i < 2; i++)
			{
				string market = "0";
				if (i == 0)
					market = "0";
				else if (i == 1)
					market = "10";
				
				string itemCodeList = InstanceManager.OpenAPI.GetCodeListByMarket(market);
				string[] itemCodeArray = itemCodeList.Split(';');

				for (int j = 0; j < itemCodeArray.Length; j++)
				{
					string itemName = InstanceManager.OpenAPI.GetMasterCodeName(itemCodeArray[j]);

					itemInfo item = new itemInfo(itemCodeArray[j], itemName);
					if (market == "0")
						item.시장구분 = "0";
					else if (market == "10")
						item.시장구분 = "10";
					InstanceManager.itemInfoList.Add(item);
				}
			}
		}

		//조건식 리스트를 불러온다.
		private void RequestConditionList()
		{
			InstanceManager.OpenAPI.GetConditionLoad(); //사용자 조건식 요청

		}

		//api_OnReceiveConditionVer
		//컨디션 리스트를 가공해주고 컨디션 레이블을 설정해준다.
		private void api_OnReceiveConditionVer(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
		{
			string conditionList = InstanceManager.OpenAPI.GetConditionNameList();

			string[] conditionArray = conditionList.Split(';');

			//스트링으로 들어온 조건식 리스트를 가공해서 컨디션 객체 리스트로 만들어준다
			for (int i = 0; i < conditionArray.Length; i++)
			//for (int i = 0; i < 3; i++)
			{
				if (conditionArray[i].Length > 0)
				{
					string[] condition = conditionArray[i].Split('^');

					string index = condition[0];
					string name = condition[1];

					Condition conditionObjects = new Condition(int.Parse(index), name);
					InstanceManager.conditions.Add(conditionObjects);

					InstanceManager.mainForm.comboBox_condition1.Items.Add(name);
					InstanceManager.mainForm.comboBox_condition2.Items.Add(name);
					InstanceManager.mainForm.comboBox_condition3.Items.Add(name);
				}
			}

		}

		//거래 유형을 불러와 세팅한다.
		private void SetTradeTypeInForm()
		{
			InstanceManager.mainForm.매도거래타입ComboBox.Text = Config.TRADE_TYPE_CODE_SELL;
			InstanceManager.mainForm.매수거래타입ComboBox.Text = Config.TRADE_TYPE_CODE_BUY;
		}

		//거래호가를 불러와 세팅한다
		private void SetTradeQuoteInForm()
		{
			InstanceManager.mainForm.매도ComboBox.Text = Config.TRADE_ASK_PRICE;
			InstanceManager.mainForm.매수ComboBox.Text = Config.TRADE_BID_PRICE;
		}

		private void SetSearchBoxSource()
		{
			AutoCompleteStringCollection source = new AutoCompleteStringCollection();
			for (int i = 0; i < InstanceManager.itemInfoList.Count; i++)
				source.Add(InstanceManager.itemInfoList[i].itemName);
			InstanceManager.mainForm.textBox_SearchBox.AutoCompleteCustomSource = source;
		}
	}
}
