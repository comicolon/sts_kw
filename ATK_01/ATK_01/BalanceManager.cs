using AxKHOpenAPILib;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace ATK_01
{
	public class BalanceManager
	{
		public BalanceManager()
		{
			InstanceManager.mainForm.possessionDataGridView.ClearSelection();
		}

		internal void ResponsBalance(_DKHOpenAPIEvents_OnReceiveTrDataEvent e)
		{
			if (e.sRQName == "계좌평가잔고내역")
			{
				string itemCodeList = "";

				//싱글데이터 출력
				int 예수금 = int.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "추정예탁자산"));
				int 총평가금 = int.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총평가금액"));
				int 총매입금액 = int.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총매입금액"));
				int 총평가손익금액 = int.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총평가손익금액"));
				double 총수익률 = double.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총수익률(%)"));

				InstanceManager.mainForm.lb_예수금.Text = 예수금.ToString();
				InstanceManager.mainForm.lb_총평가금.Text = 총평가금.ToString();
				InstanceManager.mainForm.lb_총매입금.Text = 총매입금액.ToString();
				InstanceManager.mainForm.lb_총손익금.Text = 총평가손익금액.ToString();
				InstanceManager.mainForm.lb_수익률.Text = 총수익률.ToString();

				InstanceManager.userInfo.예수금 = 예수금.ToString();
				InstanceManager.userInfo.총매입금 = 총매입금액.ToString();
				InstanceManager.userInfo.총평가금 = 총평가금.ToString();
				InstanceManager.userInfo.총평가손익금액 = 총평가손익금액.ToString();
				InstanceManager.userInfo.총수익률 = 총수익률.ToString();

				InstanceManager.mainForm.possessionDataGridView.Rows.Clear();
				//개별 종목을 추출해준다
				int rqCnt = InstanceManager.OpenAPI.GetRepeatCnt(e.sTrCode, e.sRecordName);
				InstanceManager.balanceList.Clear();

				for (int i = 0; i < rqCnt; i++)
				{
					string itemCode = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRecordName, i, "종목번호").Trim().Substring(1);
					string 종목명 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRecordName, i, "종목명").Trim();
					int 평가손익 = int.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRecordName, i, "평가손익"));
					double 수익률 = double.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRecordName, i, "수익률(%)"));
					int 매입가 = int.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRecordName, i, "매입가"));				//평균 매입가
					int 보유수량 = int.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRecordName, i, "보유수량"));
					int nowPrice = int.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRecordName, i, "현재가"));
					int buyPriceTotal = int.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRecordName, i, "매입금액"));
					int buyPriceEv = int.Parse(InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRecordName, i, "평가금액"));

					Console.WriteLine("code : " + itemCode + " name : " + 종목명 + " 평가손익 : " + 평가손익 + " 수익률 : " + 수익률 + " 매입가 : " +매입가 + 
						" 보유수량 : " + 보유수량 + " nowPrice : " + nowPrice + " buyPriceTotal : " + buyPriceTotal + " buyPriceEv : " +buyPriceEv );

					//보유 종목 리스트 생성
					Balances balance = new Balances(InstanceManager.mainForm.accountComboBox.Text.Trim(), itemCode);
					balance.종목명 = 종목명;
					balance.평가손익 = 평가손익.ToString();
					balance.수익률 = 수익률.ToString();
					balance.평균매입가 = 매입가.ToString();
					balance.보유수량 = 보유수량.ToString();
					balance.nowPrice = nowPrice.ToString();
					balance.buyPriceTotal = buyPriceTotal.ToString();
					balance.buyPriceEv = buyPriceEv.ToString();

					InstanceManager.balanceList.Add(balance);

					itemCodeList += itemCode + ";";

					//아이템 인포에서 처리
					itemInfo item = InstanceManager.itemInfoList.Find(obj => obj.itemCode == itemCode);
					item.현재가 = nowPrice.ToString();
					item.구매여부 = true;
					Task task = new Task(() =>
					{
						InstanceManager.OpenAPI.SetInputValue("종목코드", itemCode);
						InstanceManager.OpenAPI.CommRqData("주식기본정보요청", "opt10001", 0, InstanceManager.Functions.GetScreenNum());
					});
					InstanceManager.trRequestManager.RequestTrData(task);
					AddItemBalanceGrid(balance);
				}

				Console.WriteLine("보유종목수 : " + InstanceManager.balanceList.Count);
				SetRealBalanceItem(itemCodeList);
				SetBalanceInfo();
			}
		}


		//보유종목 실시간 조회 등록
		public void SetRealBalanceItem(string itemCodeList)
		{
			//보유잔고 조회 스크린 넘버는 5001로 고정
			int res = InstanceManager.OpenAPI.SetRealReg("5001", itemCodeList,
					"9001;" +				//종목코드
					"302;" +				//종목명
					"10;" +					//현재가
					"11;" +					//전일대비
					"25;" +					//전일대비 기호
					"12;" +					//등락율
					"13;" +					//누적거래량
					"15" +					//거래량
					"305;" +				//상한가
					"306;" +				//하한가
					"20;" +					//체결시간
					"27;" +					//(최우선)매도호가
					"28;" +					//(최우선)매수호가
					"228;" +				//체결강도
					"9068",                 //VI발동구분(1:정적, 2:동적, 3:동적+정적)
					"1");
		
		}

		//잔고가 생길 경우 리시브 데이터 처리
		public void ResponsBalance(itemInfo item, _DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
		{
			double _평가손익 = 0.0;
			double _수익률 = 0.0;

			string account = InstanceManager.OpenAPI.GetChejanData(9201).Trim();    //계좌번호
            string 예수금 = InstanceManager.OpenAPI.GetChejanData(951).Trim();     //예수금
			string itemCode = InstanceManager.OpenAPI.GetChejanData(9001).Trim().Substring(1);   //종목코드
			string itemName = InstanceManager.OpenAPI.GetChejanData(302).Trim();    //종목명
			string nowPrice = Math.Abs(int.Parse(InstanceManager.OpenAPI.GetChejanData(10).Trim())).ToString();     // 현재가
			string haveCnt = InstanceManager.OpenAPI.GetChejanData(930).Trim();     //보유수량
			string buyPrice = InstanceManager.OpenAPI.GetChejanData(931).Trim();    //매입단가
			string totalBuyPrice = InstanceManager.OpenAPI.GetChejanData(932).Trim();    //총매입가
			string orderDiv = InstanceManager.OpenAPI.GetChejanData(946).Trim();        //1. 매도 2.매수

			//Console.WriteLine(nowPrice);
			//Console.WriteLine(buyPrice);
			//Console.WriteLine(totalBuyPrice);
			
			Balances balance = InstanceManager.balanceList.Find(obj => obj.itemCode == itemCode);

			if (balance == null)
			{
				balance = new Balances(account, itemCode);
				InstanceManager.balanceList.Add(balance);
			}

			balance.종목명 = itemName;
			balance.nowPrice = nowPrice;
			balance.보유수량 = haveCnt;
			balance.매입단가.Add(buyPrice);

			double 매입단가합 = 0.0;
			for (int i = 0; i < balance.매입단가.Count; i++)
			{
				매입단가합 += int.Parse(balance.매입단가[i]);
			}
			balance.평균매입가 = (매입단가합 / balance.매입단가.Count).ToString();

			balance.보유수량 = haveCnt;
			balance.nowPrice = nowPrice;
			balance.buyPriceTotal = totalBuyPrice;
			balance.buyPriceEv = (int.Parse(nowPrice) * int.Parse(haveCnt)).ToString();
			_평가손익 = InstanceManager.Functions.Get평가손익(item, balance);
			_수익률 = InstanceManager.Functions.Get수익률(_평가손익, balance);
			balance.평가손익 = _평가손익.ToString();
			balance.수익률 = _수익률.ToString();


			InstanceManager.BuyedItemList.Add(item);
			AddItemBalanceGrid(balance);

			item.isTrade = true;
			item.평가손익 += _평가손익;
			item.총매입금액 += int.Parse(totalBuyPrice);

			if (orderDiv == "1" && balance.보유수량 == "0") //매도이면서 보유수량이 0이 된다면
			{
				InstanceManager.balanceManager.OutItemBalanceGrid(balance); // 그리드에서 삭제
				InstanceManager.balanceList.Remove(balance);        // 보유리스트에서 삭제
				InstanceManager.BuyedItemList.Remove(item);
			}
			if(balance.보유수량 == "0")				
			{
				InstanceManager.balanceManager.OutItemBalanceGrid(balance); // 그리드에서 삭제
				InstanceManager.balanceList.Remove(balance);        // 보유리스트에서 삭제
				InstanceManager.BuyedItemList.Remove(item);
			}

		}


		//보유 종목을 업데이트 해준다.
		public void UpdateBalance(itemInfo item, Balances balance, _DKHOpenAPIEvents_OnReceiveRealDataEvent e)
		{
			string realTyep = e.sRealType; // 실시간 종류
			double _평가손익 = 0.0;
			double _수익률 = 0.0;

			if (realTyep.Equals("주식시세"))
			{
				
			}
			else if (realTyep.Equals("주식체결"))
			{
				_평가손익 = InstanceManager.Functions.Get평가손익(item, balance);
				_수익률 = InstanceManager.Functions.Get수익률(_평가손익, balance);
				balance.평가손익 = _평가손익.ToString();
				balance.수익률 = _수익률.ToString();
				balance.등락률 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 12).Trim();
				balance.nowPrice = Math.Abs(int.Parse(InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 10).Trim())).ToString();
				balance.buyPriceEv = Math.Abs((int.Parse(InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 10).Trim()) * int.Parse( balance.보유수량))).ToString();
			
			}
			else if (realTyep.Equals("주식호가잔량"))
			{
			
			}
			else if (realTyep.Equals("주식종목정보"))                 // 실시간 등록 필요
			{
				
			}
			else if (realTyep.Equals("VI발동/해제"))                    // 실시간 등록 필요
			{
				
			}

			//Console.WriteLine("_평가손익 : " +_평가손익+ "_수익률 : " +_수익률);

			//balance.매입가 = OpenAPI.GetCommRealData(e.sRealKey, 931).Trim();
			//balance.보유수량 = OpenAPI.GetCommRealData(e.sRealKey, 930).Trim();
			//balance.buyPriceTotal = OpenAPI.GetCommRealData(e.sRealKey, 932).Trim();

			CheckStopTrailing(balance, _수익률, item);
			CheckBalanceToSell(balance, _수익률, item);
			UpdatePossessionGrid(item, balance);
			SetBalanceInfo();
		}

		// 스탑 트레일링 기준 검사
		private void CheckStopTrailing (Balances balance, double 수익률, itemInfo item)
		{
			//수익률 기준 업그레이드
			if (수익률 >= Config.TRAILING_LOSS_START_CRITERIA)
			{
				balance.stopTrailingMod = 1;
				balance.trailingLosss = 수익률 - Config.TRAILING_LOSS;
			}
			if (수익률 - Config.TRAILING_LOSS > balance.trailingLosss)
			{
				balance.trailingLosss = 수익률 - Config.TRAILING_LOSS;
			}
			
			
		}

		// 매도 조건에 해당되는지 검사
		private void CheckBalanceToSell(Balances balance, double 수익률, itemInfo item)
		{
			if (수익률 == 0)
				return;

			int result = 0;
			// 수익률이 매도매수 조건에 해당된다면
			if (InstanceManager.balanceList.Contains(balance))
			{
				if (item.상한가 != null)
				{
					if (balance.nowPrice == item.상한가.Substring(1))				// 상한가일 경우 자동으로 매도
					{
						if (item.주문요청여부 == false && item.주문여부 == false)
						{
							Console.WriteLine("신규매도====11" + balance.itemCode);
							item.주문시도여부 = true;
							result = InstanceManager.tradeManager.SellItem(item, "신규매도");
						}
					}
				}

				if (item.점수 <= Config.BALANCE_SELL_POINT_CRITERIA)          // 자동매도 점수 이하일 경우
				{
					if (item.주문요청여부 == false && item.주문여부 == false)
					{
						Console.WriteLine("신규매도====22" + balance.itemCode);
						item.주문시도여부 = true;
						result = InstanceManager.tradeManager.SellItem(item, "신규매도");
					}
				}

				if (balance.stopTrailingMod == 0)			// 기본
				{
					if (수익률 >= Config.PROFIT_LOSS || 수익률 <= Config.STOP_LOSS)
					{
						if (item.주문요청여부 == false && item.주문여부 == false)
						{
							Console.WriteLine("신규매도====33" + balance.종목명);
							item.주문시도여부 = true;
							result = InstanceManager.tradeManager.SellItem(item, "신규매도");
						}
					}
				}
				else if (balance.stopTrailingMod == 1)		// 트레일링 로스
				{
					if (수익률 >= Config.PROFIT_LOSS_MAX || 수익률 <= balance.trailingLosss)
					{
						Console.WriteLine("수익률 : " + 수익률);
						Console.WriteLine("발란스트레일링로스 : " + balance.trailingLosss);
						if (item.주문요청여부 == false && item.주문여부 == false)
						{
							Console.WriteLine("신규매도====44" + balance.종목명);
							item.주문시도여부 = true;
							result = InstanceManager.tradeManager.SellItem(item, "신규매도");
						}
					}
				}
				else if (balance.stopTrailingMod == 1)		// 트레일링 로스 지만 수익률이 기본보다 높고 점수가 기준보다 낮으면. 매도
				{
					if (수익률 >= Config.PROFIT_LOSS && item.점수 < Config.BALANCE_PROFIT_LOSS_CRITERIA)
					{
						if (수익률 >= Config.PROFIT_LOSS_MAX || 수익률 <= balance.trailingLosss)
						{
							if (item.주문요청여부 == false && item.주문여부 == false)
							{
								Console.WriteLine("신규매도====55" + balance.itemCode);
								item.주문시도여부 = true;
								result = InstanceManager.tradeManager.SellItem(item, "신규매도");
							}
						}
					}
				}
			}

			if (result == 0)
				item.주문시도여부 = false;
		}


		// 보유종목 그리드 추가
		public void AddItemBalanceGrid(Balances balance)
		{
			bool isBalance = false;
			for (int i = 0; i < InstanceManager.mainForm.possessionDataGridView.Rows.Count; i++)		// 이미 종목이 있는지 검사
			{
				if (InstanceManager.mainForm.possessionDataGridView.Rows[i].Cells[0].Value.ToString() == balance.종목명)
					isBalance = true;
			}

			if (isBalance == true)
				return;
			else
			{
				DataGridView grid = InstanceManager.mainForm.possessionDataGridView;
				string itemName = InstanceManager.OpenAPI.GetMasterCodeName(balance.itemCode);
				itemInfo item = InstanceManager.itemInfoList.Find(obj => obj.itemCode == balance.itemCode);

				int rowNum = grid.Rows.Add(itemName, 
								balance.평가손익, 
								balance.수익률, 
								balance.등락률,
								"즉시매도",
								item.점수,
								balance.보유수량, 
								balance.평균매입가, 
								balance.nowPrice, 
								balance.buyPriceTotal, 
								balance.buyPriceEv);
			}
			
		}

		// 보유종목 그리드 업데이트
		public void UpdatePossessionGrid(itemInfo item, Balances balance)
		{
			DataGridView grid = InstanceManager.mainForm.possessionDataGridView;
			for (int i = 0; i < grid.Rows.Count; i++)
			{
				if (grid.Rows[i].Cells[0].Value.ToString() == item.itemName)
				{
					grid.Rows[i].Cells[1].Value = balance.평가손익;
					grid.Rows[i].Cells[2].Value = balance.수익률;
					grid.Rows[i].Cells[3].Value = balance.등락률;
					grid.Rows[i].Cells[5].Value = item.점수;
					grid.Rows[i].Cells[6].Value = balance.보유수량;
					grid.Rows[i].Cells[7].Value = balance.평균매입가;
					grid.Rows[i].Cells[8].Value = balance.nowPrice;
					grid.Rows[i].Cells[9].Value = balance.buyPriceTotal;
					grid.Rows[i].Cells[10].Value = balance.buyPriceEv;

				}
			}
		}

		//보유종목 그리드에서 삭제한다
		public void OutItemBalanceGrid(Balances balance)
		{
			string itemName = InstanceManager.OpenAPI.GetMasterCodeName(balance.itemCode);

			for (int i = 0; i < InstanceManager.mainForm.possessionDataGridView.Rows.Count; i++)
			{
				if (InstanceManager.mainForm.possessionDataGridView.Rows[i].Cells[0].Value.ToString() == itemName)
				{
					InstanceManager.mainForm.possessionDataGridView.Rows.Remove(InstanceManager.mainForm.possessionDataGridView.Rows[i]);
				}
			}
		}

		// 사용자 기본 자산 정보를 갱신한다.
		private void SetBalanceInfo()
		{
			double 총평가손익 = 0;
			double 총수익률 = 0;
			int 총손익 = 0;
			double 실현손익 = 0;
			int 실현손익총매입금 = 0;
			double 실현손익률 = 0.0;
			int 총매입금 = 0;
			int 총평가금 = 0;

			for (int i = 0; i < InstanceManager.balanceList.Count; i++)
			{
				총평가손익 += double.Parse(InstanceManager.balanceList[i].평가손익);
				총매입금 += int.Parse(InstanceManager.balanceList[i].buyPriceTotal);
				총평가금 += int.Parse(InstanceManager.balanceList[i].buyPriceEv);
			}

			총수익률 = Math.Round(총평가손익 / 총평가금 * 100, 2);

			InstanceManager.userInfo.총수익률 = 총수익률.ToString();
			InstanceManager.userInfo.총매입금 = 총매입금.ToString();
			InstanceManager.userInfo.총평가금 = 총평가금.ToString();
			InstanceManager.userInfo.총평가손익금액 = 총평가손익.ToString();

			InstanceManager.mainForm.lb_예수금.Text = InstanceManager.userInfo.예수금;
			InstanceManager.mainForm.lb_수익률.Text = InstanceManager.userInfo.총수익률;
			InstanceManager.mainForm.lb_총손익금.Text = InstanceManager.userInfo.총평가손익금액;
			InstanceManager.mainForm.lb_총매입금.Text = InstanceManager.userInfo.총매입금;
			InstanceManager.mainForm.lb_총평가금.Text = InstanceManager.userInfo.총평가금;

			//실현손익 업데이트
			for (int i = 0; i < InstanceManager.itemInfoList.Count; i++)
			{
				if (InstanceManager.itemInfoList[i].isTrade == true && InstanceManager.itemInfoList[i].구매여부 == false)
				{
					실현손익 += (int)InstanceManager.itemInfoList[i].평가손익;
					실현손익총매입금 += InstanceManager.itemInfoList[i].총매입금액;
				}
			}

			실현손익률 = Math.Round(실현손익 / 실현손익총매입금 * 100, 2);

			InstanceManager.userInfo.실현손익 = 실현손익.ToString();
			InstanceManager.userInfo.실현손익률 = 실현손익률.ToString();

		}
	}
}
