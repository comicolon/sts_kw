using AxKHOpenAPILib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATK_01
{

	public class ConditionManager
	{
		
		public ConditionManager()
		{
			SetConditionComboBoxArray();
			SetConditionGridViewArray();

		}

		//조건 검색 레이블의 배열을 만들어준다.
		private void SetConditionComboBoxArray()
		{
			//////////////하드코딩//////////////
			InstanceManager.conditionComboBoxList[0] = MainForm.mainForm.comboBox_condition1;
			InstanceManager.conditionComboBoxList[1] = MainForm.mainForm.comboBox_condition2;
			InstanceManager.conditionComboBoxList[2] = MainForm.mainForm.comboBox_condition3;
		}

		//조건검색 그리드 뷰의 배열을 만들어준다
		private void SetConditionGridViewArray()
		{
			/////////////하드코딩//////////////
			InstanceManager.conditionDataGridViews[0] = MainForm.mainForm.con1dataGridView;
			InstanceManager.conditionDataGridViews[1] = MainForm.mainForm.con2dataGridView;
			InstanceManager.conditionDataGridViews[2] = MainForm.mainForm.con3dataGridView;
		}

		//실시간 조건식의 내용을 처리해준다
		public void ProcRealCondition(_DKHOpenAPIEvents_OnReceiveRealConditionEvent e)
		{
			string conditionName = e.strConditionName;
			string conditionIndex = e.strConditionIndex;
			string codeList = e.sTrCode; //편입 이탈 종목 코드

			string type = e.strType; // 편입 I , 이탈 D
			if (type.Equals("I"))
			{
				string name = InstanceManager.OpenAPI.GetMasterCodeName(codeList);
				ShowConditionSearchItem("in", conditionName, codeList);
			}
			else if (type.Equals("D"))
			{
				string name = InstanceManager.OpenAPI.GetMasterCodeName(codeList);
				ShowConditionSearchItem("out", conditionName, codeList);
			}

		}

		// tr요청한 조건식을 처리해준다
		internal void SetTrCondition(_DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
		{
			string conditionName = e.strConditionName;
			int conditionIndex = e.nIndex;
			string codeList = e.strCodeList;
			string[] codeArray = codeList.Split(';');
			string[] procCodeArray = new string[codeArray.Length - 1];

			// 받아온 종목코드 가공
			for (int i = 0; i < codeArray.Length; i++)
			{
				if(codeArray[i].Length > 0)
				{
					procCodeArray[i] = codeArray[i]; 
				}
			}
			
			// 각 조건식 별로 종목을 받아 저장한다
			for (int i = 0; i < procCodeArray.Length; i++)
			{
				Condition selectedCondition = null;
				for (int j = 0; j < InstanceManager.conditions.Count; j++)
				{
					if (InstanceManager.conditions[j].Name == conditionName)
						selectedCondition = InstanceManager.conditions[j];
				}
				selectedCondition.itemCode.Add(procCodeArray[i]);
				ShowConditionSearchItem("in", selectedCondition.Name, procCodeArray[i]);          //종목 리스트에 넣으면서 아이템 보여주기 호출
			}
		}

		//조건검색식에 들어온 종목을 보여주거나 빼준다.
		public void ShowConditionSearchItem (string inOut , string conditionName, string itemCode)
		{
			string itemName = "";
			DataGridView SearchedDataGridView = null;
			itemInfo item = InstanceManager.itemInfoList.Find(obj => obj.itemCode == itemCode);

			//nsole.WriteLine(item.itemName);

			for (int i = 0; i < Config.CONDITION_USE_NUM; i++)
			{
				for (int j = 0; j < InstanceManager.conditions.Count; j++)
				{
					if (conditionName == InstanceManager.conditions[j].Name)
						SearchedDataGridView = InstanceManager.conditions[j].dataGridView;

					if (InstanceManager.conditions[j].Name == conditionName)
					{
						itemName = InstanceManager.OpenAPI.GetMasterCodeName(itemCode);
					}
				}
			}

			if (inOut == "in")		//종목추가의 경우
			{
				//종목리스트에서 종목을 얻어와 종목의 그리드 리스트에 발견 그리드를 넣어준다.
				//item.포착조건식그리드.Add(SearchedDataGridView);
				
				item.포착조건식그리드.Add(SearchedDataGridView);

				SearchedDataGridView.Rows.Add(itemName);
				//실시간 조회 요청
				//balanceManager.SetRealBalanceItem(itemCode);

				InstanceManager.OpenAPI.SetRealReg(Functions.functions.GetScreenNumReal(), itemCode,
					"9001;" +               //종목코드
					"302;" +                //종목명
					"10;" +                 //현재가
					"11;" +                 //전일대비
					"25;" +                 //전일대비 기호
					"12;" +                 //등락율
					"13;" +                 //누적거래량
					"15" +                  //거래량
					"305;" +                //상한가
					"306;" +                //하한가
					"20;" +                 //체결시간
					"27;" +                 //(최우선)매도호가
					"28;" +                 //(최우선)매수호가
					"228;" +                //체결강도
					"9068",                 //VI발동구분(1:정적, 2:동적, 3:동적+정적)
					"1");

				InstanceManager.itemManager.InItem(item);
			}
			else if (inOut == "out")//종목 삭제의 경우
			{
				if (SearchedDataGridView == null)
					return;

				//조건검색 리스트에서 삭제
				for (int i = 0; i < SearchedDataGridView.Rows.Count; i++)
				{
					if (SearchedDataGridView.Rows[i].Cells[0].FormattedValue.ToString() == itemName)
					{
						SearchedDataGridView.Rows.Remove(SearchedDataGridView.Rows[i]);
					}
				}

				InstanceManager.itemManager.OutItem(item);
			}
		}

		//콤보박스 선택에 따라 조건식을 세팅함
		internal void SetSelectCondition(ComboBox comboBox)
		{
			
			string conditionName = comboBox.Text;
			for (int i = 0; i < InstanceManager.conditions.Count; i++)
			{
				if (InstanceManager.conditions[i].Name == conditionName)
				{
					InstanceManager.conditions[i].isSelected = true;
					InstanceManager.conditions[i].comboBox = comboBox;
					int comboBoxNum = Array.IndexOf(InstanceManager.conditionComboBoxList, comboBox);
					InstanceManager.conditions[i].ComboBoxNum = comboBoxNum;
					InstanceManager.conditions[i].GridNum = comboBoxNum;
					InstanceManager.conditions[i].dataGridView = InstanceManager.conditionDataGridViews[InstanceManager.conditions[i].GridNum];

					Console.WriteLine("활성조건식 : " + InstanceManager.conditions[i].Name);
				}
			}

			for (int i = 0; i < InstanceManager.conditions.Count; i++)			// 이전의 조건식을 찾아 꺼준다.
			{
				if (InstanceManager.conditions[i].Name != conditionName && InstanceManager.conditions[i].comboBox == comboBox)
				{
					InstanceManager.conditions[i].isSelected = false;
					InstanceManager.conditions[i].ComboBoxNum = -1;
					InstanceManager.conditions[i].comboBox = null;
					InstanceManager.conditions[i].GridNum = -1;
					InstanceManager.conditions[i].dataGridView = null;

					Console.WriteLine("비활성조건식 : " + InstanceManager.conditions[i].Name);

				}
			}
		}

		//조건식 검색 요청  
		public void GetCondition()
		{
			for (int i = 0; i < InstanceManager.conditionDataGridViews.Length; i++)
			{
				InstanceManager.conditionDataGridViews[i].Rows.Clear();
			}
			InstanceManager.SearchItemList.Clear();

			for (int i = 0; i < InstanceManager.conditions.Count; i++)
			{
				string conditionName = InstanceManager.conditions[i].Name;

				Condition condition = InstanceManager.conditions.Find(obj => obj.Name.Equals(conditionName));
				if (condition != null && condition.isSelected == true)
				{
					int conditionIndex = condition.Index;
					string screenNum = InstanceManager.Functions.GetScreenNum();
					int result = InstanceManager.OpenAPI.SendCondition(screenNum, conditionName, conditionIndex, 1);
					if (result == 1)
					{
						Console.WriteLine("요청성공" + condition.Name);
						condition.screenNum = screenNum;
					}
					else if (result != 1)
						Console.WriteLine("요청실패" + condition.Name);
				}
			}

			for (int i = 0; i < InstanceManager.conditions.Count; i++)
			{
				if (InstanceManager.conditions[i].isSelected == false)
				{
					InstanceManager.OpenAPI.SendConditionStop(InstanceManager.conditions[i].screenNum, InstanceManager.conditions[i].Name, InstanceManager.conditions[i].Index);
				}
			}
		}
	}
}
