using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ATK_01
{

	public class ItemManager
	{
		private string tr시세표성정보요청코드 = "";

		delegate void Dele_SetSelectedItem(string itemCode);
		delegate void Dele_OutSelectedItem(string itemCode);
		
		Queue<BigBuySell> bigBuySellQueue = new Queue<BigBuySell>();		//대량거래시에 함수가 사용하는 큐
		
		public ItemManager()
		{
			Thread pointWorder = new Thread(new ThreadStart(Run));
			pointWorder.IsBackground = true;
			pointWorder.Start();

			Timer showPointTimer = new System.Windows.Forms.Timer();		// 그리드를 갱신하는 타이머
			showPointTimer.Interval = 300;      //0.3초
			showPointTimer.Tick += new EventHandler(ShwoInfoOnGrid);
			showPointTimer.Start();

		}

		public class BigBuySell
		{
			public itemInfo item;
			public string tradeNum;
			public BigBuySell(itemInfo item, string tradeNum)
			{
				this.item = item;
				this.tradeNum = tradeNum;
			}
		}

		

		//TR데이터를 처리해준다
		public void ProcTrItemData(AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
		{
		
			if (e.sRQName == "주식기본정보요청")
			{
				string itemCode = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "종목코드").Trim();
				string nowPrice = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "현재가").Trim();
				string 기준가 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "기준가").Trim();
				string 시가 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "시가").Trim();
				string 고가 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "고가").Trim();
				string 저가 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "저가").Trim();
				string 신용비율 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "신용비율").Trim();
				string 등락률 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "등락율").Trim();
				string 상한가 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRecordName, 0, "상한가").Trim();
				string 하한가 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRecordName, 0, "하한가").Trim();
				string 누적거래량 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRecordName, 0, "거래량").Trim();
				string 전일대비 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRecordName, 0, "전일대비").Trim();

				itemInfo item = InstanceManager.itemInfoList.Find(obj => obj.itemCode == itemCode);
				if (item != null)
				{
					item.현재가 = nowPrice;
					item.기준가 = 기준가;
					item.기준가 = 시가;
					item.기준가 = 고가;
					item.기준가 = 저가;
					item.신용비율 = 신용비율;
					item.등락률 = 등락률;
					item.상한가 = 상한가;
					item.하한가 = 하한가;
					item.누적거래량 = 누적거래량;
					item.전일대비 = 전일대비;

					Console.WriteLine("종목명 : " +item.itemName+ " 기준가 : " + 기준가 + " 시가 : " + 시가 + " 고가 : " + 고가 + " 저가 : " + 저가);
				
					if(InstanceManager.balanceList.Count > 0)		// 등락률을 보유종목에 추가한다
					{
						Balances balance = InstanceManager.balanceList.Find(obj => obj.itemCode == itemCode);
						if (balance != null)
						{
							balance.등락률 = 등락률;
							InstanceManager.balanceManager.UpdatePossessionGrid(item, balance);
						}
					}
				}

				//Console.WriteLine("현재가 : "+nowPrice+" 등락률 : " + 등락률+" 상한가 : " + 상한가 + " 하한가 : " + 하한가);
			}
			else if (e.sRQName == "시세표성정보요청") 
			{
				itemInfo item = InstanceManager.itemInfoList.Find(obj => obj.itemCode == tr시세표성정보요청코드);
				item.총매도잔량 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총매도잔량").Trim();
				item.총매수잔량 = InstanceManager.OpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "총매수잔량").Trim();
			}
		}

		//실시간 데이터를 처리해준다.
		public void ProcRealItemData(AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e)
		{
			string itemCode = e.sRealKey;	// 종목코드
			string realTyep = e.sRealType; // 실시간 종류

			if (itemCode == "09")			//이유는 모르지만 아이템 코드가 이렇게 들어올 때가 있음
				return;

			itemInfo item = InstanceManager.itemInfoList.Find(obj => obj.itemCode == itemCode);
			Balances balance = InstanceManager.balanceList.Find(obj => obj.itemCode == item.itemCode);

			//Console.WriteLine(item.itemName);

			if (realTyep.Equals("주식시세"))
			{
				item.현재가 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 10).Trim(); //현재가
				item.전일대비 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 11).Trim(); //전일대비
				item.등락률 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 12).Trim(); //등락률
				item.누적거래량 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 13).Trim(); //누적거래량
				item.전일대비기호 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 25).Trim(); // 전일대비 기호
				item.최우선매도호가 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 27).Trim(); //최우선매도호가
				item.최우선매수호가 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 28).Trim(); //최우선매수호가
			}
			else if (realTyep.Equals("주식체결"))
			{
				item.체결시간 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 20).Trim(); //체결시간
				item.현재가 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 10).Trim(); //현재가
				item.전일대비 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 11).Trim(); //전일대비
				item.등락률 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 12).Trim(); //등락률
				item.누적거래량 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 13).Trim(); //누적거래량
				item.거래량 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 15).Trim(); //거래량
				item.전일대비기호 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 25).Trim(); // 전일대비 기호
				item.최우선매도호가 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 27).Trim(); //최우선매도호가
				item.최우선매수호가 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 28).Trim(); //최우선매수호가
				item.체결강도 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 228).Trim();		//체결강도
			}
			else if (realTyep.Equals("주식호가잔량"))
			{
				item.총매도잔량 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 121).Trim();
				item.총매수잔량 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 125).Trim();
			}
			else if (realTyep.Equals("주식종목정보"))					// 실시간 등록 필요
			{
				item.상한가 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 305).Trim(); //상한가
				item.하한가 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 306).Trim(); //하한가
			}
			else if (realTyep.Equals("VI발동/해제"))					// 실시간 등록 필요
			{
				item.VI발동구분 = InstanceManager.OpenAPI.GetCommRealData(e.sRealKey, 9068).Trim();
			}

			// 대량 매수매도가 일어날 시에
			if (item.거래량 != null)
			{
				if (int.Parse (item.거래량)  * int.Parse( item.현재가) >= Config.BIG_BUY_CRITERIA || int.Parse(item.거래량) * int.Parse(item.현재가) <= Config.BIG_SELL_CRITERIA)
				{
					Console.WriteLine("대량거래 : " + int.Parse(item.거래량) * int.Parse(item.현재가) + " " + item.itemName);
					BigBuySell bigBuySell = new BigBuySell(item, item.거래량);
					bigBuySellQueue.Enqueue(bigBuySell);
				}
			}

			if (balance != null)			// 보유 종목이 있을 경우 보유종목 업데이트
			{
				if (item.itemCode == balance.itemCode)
				{
					InstanceManager.balanceManager.UpdateBalance(item, balance, e);
				}
			}
		}

		//포착 종목 리스트에 추가한다
		public void InItem (itemInfo item)
		{
			InstanceManager.SearchItemList.Add(item);
			
			tr시세표성정보요청코드 = item.itemCode;

			if (item.포착여부 == false && item.주식기본정보요청여부 == false && item.시세표성정보요청여부 == false)
			{
				Task task = new Task(() =>
				{
					InstanceManager.OpenAPI.SetInputValue("종목코드", item.itemCode);
					InstanceManager.OpenAPI.CommRqData("주식기본정보요청", "OPT10001", 0, InstanceManager.Functions.GetScreenNum());
					item.주식기본정보요청여부 = true;
				});
				InstanceManager.trRequestManager.RequestTrData(task);

				Task task2 = new Task(() =>
				{
					InstanceManager.OpenAPI.SetInputValue("종목코드", item.itemCode);
					InstanceManager.OpenAPI.CommRqData("시세표성정보요청", "OPT10007", 0, InstanceManager.Functions.GetScreenNum());
					item.시세표성정보요청여부 = true;
				});
				InstanceManager.trRequestManager.RequestTrData(task2);
			}

			item.포착시간 = DateTime.Now;
			item.일일포착여부 = true;
			item.포착여부 = true;
		}

		// 포착 종목 리스트에서 삭제한다
		public void OutItem (itemInfo item)
		{
			InstanceManager.SearchItemList.Remove(item);
			item.포착시간 = DateTime.MinValue;
			item.last포착시간 = DateTime.MinValue;
			//item.점수 = 0;
			item.포착여부 = false;
			
		}

		public void OutItemRealRemove(itemInfo item)
		{
			if (item.포착여부 == false && InstanceManager.Functions.GetDiffTime(item.last포착시간) > 120)
			{
				// 실시간 데이터 등록 해제
				if (item.후보여부 == false && item.구매여부 == false && item != InstanceManager.chartManager.nowChartItem && item != InstanceManager.bookWindowManager.nowBookItem)
				{
					InstanceManager.OpenAPI.SetRealRemove("ALL", item.itemCode);
					item.시세표성정보요청여부 = false;
					item.주식기본정보요청여부 = false;
				}
			}
		}

		//점수 워커
		void Run()
		{
			
			while (true)
			{
				//포착종목 검색
				if (InstanceManager.SearchItemList.Count > 0)
				{
					for (int i = 0; i < InstanceManager.SearchItemList.Count; i++)
					{
						//검색종목 1초간 평가 (유지시간, 총매수매도비율)
						double duration = InstanceManager.Functions.GetDiffTimeItem(InstanceManager.SearchItemList[i]);
						if (duration >= 1.0)
						{
							InstanceManager.SearchItemList[i].점수 += Config.IN_ITEM_SECOND_ADD_POINT;
							if (InstanceManager.SearchItemList[i].점수 >= Config.SELECT_POINT_MAX)
								InstanceManager.SearchItemList[i].점수 = Config.SELECT_POINT_MAX;

							SetPointByTotalBookRatio(InstanceManager.SearchItemList[i]);
						}
						
						//점수가 넘어가면 후보군으로 올려준다
						if (InstanceManager.SearchItemList[i].점수 >= Config.IN_ITEM_POINT_MAX)
						{
							if (InstanceManager.SearchItemList[i].후보여부 != true)
							{
								InstanceManager.SearchItemList[i].후보여부 = true;
								InSelectedItem(InstanceManager.SearchItemList[i].itemCode);
							}
						}
					}
				}

				// 후보종목 검색 점수관리
				if (InstanceManager.SelectedItemList.Count > 0)
				{
					for (int i = 0; i < InstanceManager.SelectedItemList.Count; i++)
					{
						double duration = InstanceManager.Functions.GetDiffTimeItem(InstanceManager.SelectedItemList[i]);
						if (duration >= 1.0)
						{
							if (!InstanceManager.SearchItemList.Contains(InstanceManager.SelectedItemList[i]))		// 포착 종목 리스트에 후보종목이 없으면
							{
								InstanceManager.SelectedItemList[i].점수 -= Config.SELECT_ITEM_SECOND_DEDUCT_POINT;
							}

							SetPointByTotalBookRatio(InstanceManager.SelectedItemList[i]);
						}
					}
				}

				// 매수종목 검색
				if (InstanceManager.BuyedItemList.Count > 0)
				{
					for (int i = 0; i < InstanceManager.BuyedItemList.Count; i++)
					{
						double duration = InstanceManager.Functions.GetDiffTimeItem(InstanceManager.BuyedItemList[i]);
						if (duration >= 1.0)
						{
							SetPointByTotalBookRatio(InstanceManager.BuyedItemList[i]);
						}
					}
				}

				//대량 매수매도시에 함수 호출
				if (bigBuySellQueue.Count > 0)
				{
					BigBuySell bigBuySell = bigBuySellQueue.Dequeue();
					if (bigBuySell != null)
					{
						SetPintByBigBuySell(bigBuySell.item, bigBuySell.tradeNum);
					}
				}

				//후보 종목 검색
				if (InstanceManager.SelectedItemList.Count > 0)
				{
					DataGridView grid = InstanceManager.mainForm.selectedDataGridView;

					for (int i = 0; i < InstanceManager.SelectedItemList.Count; i++)
					{
						// 후보종목의 요건이 매수해도 된다면
						if (InstanceManager.balanceList.Count < Config.ORDER_COUNT_MAX && InstanceManager.SelectedItemList[i].점수 >= Config.ITEM_BUY_POINT)		// 매수 주문 요청
						{
							if(InstanceManager.SelectedItemList[i].주문요청여부 == false && InstanceManager.SelectedItemList[i].주문여부 == false && InstanceManager.SelectedItemList[i].구매여부 ==false && InstanceManager.SelectedItemList[i].주문시도여부 == false)
							{
								InstanceManager.orderManager.SetOderCnt();		// 주문갯수 계산
								if ((InstanceManager.balanceList.Count + InstanceManager.orderManager.onOrderCnt) < Config.ORDER_COUNT_MAX)		//한도계수 이하일때
								{
									if(InstanceManager.SelectedItemList[i].체결강도 != "")		// vi 발동시에는 체결강도가 넘어오지 않는다. vi를 피하기 위함
									{
										InstanceManager.SelectedItemList[i].주문시도여부 = true;                              // 당분간 수동 매수
										int result = InstanceManager.tradeManager.BuyItem(InstanceManager.SelectedItemList[i], "신규매수");
										if (result == 0)
											InstanceManager.SelectedItemList[i].주문시도여부 = false;
									}
								}
								Thread.Sleep(100);		// 동시에 매수되는것 방지
							}
						}
						else if (InstanceManager.SelectedItemList[i].점수 < Config.IN_ITEM_POINT_MAX) // 후보군에서 삭제
						{
							InstanceManager.SelectedItemList[i].후보여부 = false;
							OutSelectedItem(InstanceManager.SelectedItemList[i].itemCode);
						}
					}
				}

				for (int i = 0; i < InstanceManager.itemInfoList.Count; i++)
				{
					if (InstanceManager.itemInfoList[i].일일포착여부 == true)
						OutItemRealRemove(InstanceManager.itemInfoList[i]);
				}

				Thread.Sleep(5);
			}
		}

		// 후보군 종목 세팅
		private void InSelectedItem(string itemCode)
		{

			itemInfo item = InstanceManager.SearchItemList.Find(obj => obj.itemCode == itemCode);
			if(item != null)
			{
				InstanceManager.SelectedItemList.Add(item);
				item.후보여부 = true;
				DataGridView gridView = InstanceManager.mainForm.selectedDataGridView;
			
				if (gridView.InvokeRequired)
				{
					Dele_SetSelectedItem call = new Dele_SetSelectedItem(InSelectedItem);
					gridView.Invoke(call, itemCode);
				}
				else
				{
					gridView.Rows.Add(item.itemName, item.현재가, item.등락률, item.점수, "즉시매수");
				}
			}

			//기본정보요청을 통해 상한가 하한가를 가져온다.
			Task task = new Task(() =>
			{
				InstanceManager.OpenAPI.SetInputValue("종목코드", itemCode);
				InstanceManager.OpenAPI.CommRqData("주식기본정보요청", "opt10001", 0, InstanceManager.Functions.GetScreenNum());
			});
			InstanceManager.trRequestManager.RequestTrData(task);
		}
		
		// 후보군 종목 삭제
		private void OutSelectedItem (string itemCode)
		{
			itemInfo item = InstanceManager.SelectedItemList.Find(obj => obj.itemCode == itemCode);
			if (item != null)
			{
				item.후보여부 = false;
				InstanceManager.SelectedItemList.Remove(item);
				DataGridView gridView = InstanceManager.mainForm.selectedDataGridView;
				string name = InstanceManager.OpenAPI.GetMasterCodeName(itemCode);

				if (gridView.InvokeRequired)
				{
					Dele_OutSelectedItem call = new Dele_OutSelectedItem(OutSelectedItem);
					gridView.Invoke(call, itemCode);
				}
				else
				{
					for (int i = 0; i < gridView.Rows.Count; i++)
					{
						if(gridView.Rows[i].Cells[0].FormattedValue.ToString() == name)
						{
							gridView.Rows.Remove(gridView.Rows[i]);
						}
					}
				}
			}
		}

		// 대량 매수 매도가 일어날 시에 종목 점수를 더해주거나 빼준다
		private void SetPintByBigBuySell(itemInfo item, string _tradeNum)
		{
			int tradeNum = int.Parse(_tradeNum);
			
			if (tradeNum > 0)		// 대량 매수
			{
				if (InstanceManager.SelectedItemList.Contains(item))		// 후보종목의 경우
				{
					item.점수 += Config.SELECT_ITEM_BIG_BUY_ADD_POINT;
					if (item.점수 >= Config.SELECT_POINT_MAX)
						item.점수 = Config.SELECT_POINT_MAX;
				}
				else
				{
					item.점수 += Config.IN_ITEM_BIG_BUY_ADD_POINT;
					if (item.점수 >= Config.SELECT_POINT_MAX)
						item.점수 = Config.SELECT_POINT_MAX;
				}
			}
			else if (tradeNum < 0)		// 대량 매도
			{
				if (InstanceManager.SelectedItemList.Contains(item))		// 후보종목의 경우
				{
					item.점수 -= Config.SELECT_ITEM_BIG_SELL_DEDUCT_POINT;
					if (item.점수 < Config.ITEM_POINT_MIN)
						item.점수 = Config.ITEM_POINT_MIN;
				}
				else
				{
					item.점수 -= Config.IN_ITEM_BIG_SELL_DEDUCT_POINT;
					if (item.점수 < Config.ITEM_POINT_MIN)
						item.점수 = Config.ITEM_POINT_MIN;
				}
			}
		}

		// 호가창의 비율에 따라서 점수를 가감한다
		private void SetPointByTotalBookRatio(itemInfo item)
		{
			if (item == null)
				return;

			if (item.총매도잔량 != null && item.총매수잔량 != null)
			{
				double 매도총잔량 = double.Parse(item.총매도잔량);
				double 매수총잔량 = double.Parse(item.총매수잔량);
				double 매도매수비율 = 매도총잔량 / 매수총잔량;
				double 매수매도비율 = 매수총잔량 / 매도총잔량;

				if (매도총잔량 > 매수총잔량)								// 매도 물량이 많을때
				{
					if (Math.Truncate(매도매수비율) == 2)
						item.점수 += Config.TOTAL_BOOK_RATIO_ASK_ASEND_2;
					else if (Math.Truncate(매도매수비율) == 3)
						item.점수 += Config.TOTAL_BOOK_RATIO_ASK_ASEND_3;
					else if (Math.Truncate(매도매수비율) == 4)
						item.점수 += Config.TOTAL_BOOK_RATIO_ASK_ASEND_4;
					else if (Math.Truncate(매도매수비율) == 5)
						item.점수 += Config.TOTAL_BOOK_RATIO_ASK_ASEND_5;
					else if (Math.Truncate(매도매수비율) == 6)
						item.점수 += Config.TOTAL_BOOK_RATIO_ASK_ASEND_6;
					else if (Math.Truncate(매도매수비율) == 7)
						item.점수 += Config.TOTAL_BOOK_RATIO_ASK_ASEND_7;
					else if (Math.Truncate(매도매수비율) >= 8)
						item.점수 += Config.TOTAL_BOOK_RATIO_ASK_ASEND_8;

					if (item.점수 >= Config.SELECT_POINT_MAX)
						item.점수 = Config.SELECT_POINT_MAX;
				}
				else if (매수총잔량 < 매도총잔량)                            // 매수 물량이 많을때
				{
					if (Math.Truncate(매수매도비율) == 2)
						item.점수 -= Config.TOTAL_BOOK_RATIO_BID_ASEND_2;
					else if (Math.Truncate(매수매도비율) == 3)
						item.점수 -= Config.TOTAL_BOOK_RATIO_BID_ASEND_3;
					else if (Math.Truncate(매수매도비율) == 4)
						item.점수 -= Config.TOTAL_BOOK_RATIO_BID_ASEND_4;
					else if (Math.Truncate(매수매도비율) == 5)
						item.점수 -= Config.TOTAL_BOOK_RATIO_BID_ASEND_5;
					else if (Math.Truncate(매수매도비율) == 6)
						item.점수 -= Config.TOTAL_BOOK_RATIO_BID_ASEND_6;
					else if (Math.Truncate(매수매도비율) == 7)
						item.점수 -= Config.TOTAL_BOOK_RATIO_BID_ASEND_7;
					else if (Math.Truncate(매수매도비율) >= 8)
						item.점수 -= Config.TOTAL_BOOK_RATIO_BID_ASEND_8;

					if (item.점수 <= Config.ITEM_POINT_MIN)
						item.점수 = Config.ITEM_POINT_MIN;
				}
			}
			
		}


		//그리드에 정보를 표시해준다.
		public void ShwoInfoOnGrid(object sender, EventArgs e)
		{
			//후보종목 리스트 그리드
			if (InstanceManager.SelectedItemList.Count > 0)
			{
				DataGridView grid = InstanceManager.mainForm.selectedDataGridView;

				for (int i = 0; i < InstanceManager.SelectedItemList.Count; i++)
				{
					for (int j = 0; j < grid.Rows.Count; j++)
					{
						if (InstanceManager.SelectedItemList[i].itemName == grid.Rows[j].Cells[0].Value.ToString())
						{ 
							grid.Rows[j].Cells[1].Value = InstanceManager.SelectedItemList[i].현재가;
							grid.Rows[j].Cells[2].Value = InstanceManager.SelectedItemList[i].등락률;
							grid.Rows[j].Cells[3].Value = InstanceManager.SelectedItemList[i].점수;
						}
					}
				}
			}

			// 조건검색 종목 리스트 그리드
			if (InstanceManager.SearchItemList.Count > 0)
			{
				for (int i = 0; i < InstanceManager.SearchItemList.Count; i++)
				{
					for (int j = 0; j < InstanceManager.SearchItemList[i].포착조건식그리드.Count; j++)
					{
						DataGridView grid = InstanceManager.SearchItemList[i].포착조건식그리드[j];
						if (grid != null)
						{
							for (int k = 0; k < grid.Rows.Count; k++)                                   
							{
								if (grid.Rows[k].Cells[0].Value.ToString() == InstanceManager.SearchItemList[i].itemName)
								{
									grid.Rows[k].Cells[1].Value = InstanceManager.SearchItemList[i].등락률;
									grid.Rows[k].Cells[2].Value = InstanceManager.SearchItemList[i].점수;
								}
							}
						}
					}
				}
		
			}

		}		// 매소드 끝

	}
}

