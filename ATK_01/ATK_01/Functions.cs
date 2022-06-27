using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATK_01
{
	public class Functions
	{
		private readonly AxKHOpenAPILib.AxKHOpenAPI OpenAPI = MainForm.mainForm.axKHOpenAPI1;

		public int screenNum = 1001;
		public int screenNumReal = 5002;
		public int realNumPerScreenNum = 1;
		public int realNumPerScreenNumMax = 100;

		public static Functions functions;
		public Functions()
		{
			functions = this;
		}

		public void GetBalanceInfo()
		{
			Task task = new Task(() =>
			{
				InstanceManager.mainForm.accountComboBox.Invoke(new Action(delegate () {
					string accountNUm = MainForm.mainForm.accountComboBox.Text;
					OpenAPI.SetInputValue("계좌번호", accountNUm);
					OpenAPI.SetInputValue("비밀번호", "0000");
					OpenAPI.SetInputValue("비밀번호입력매체구분", "00");
					OpenAPI.SetInputValue("조회구분", "2");

					OpenAPI.CommRqData("계좌평가잔고내역", "opw00018", 0, functions.GetScreenNum());
				}));
			});

			InstanceManager.trRequestManager.RequestTrData(task);
		}

		// 화면번호를 반환
		public string GetScreenNum()
		{
			if (screenNum >= 5000)
				screenNum = 1000;

			screenNum++;
			return screenNum.ToString();
		}

		//실시간 조회 화면 번호를 반환
		public string GetScreenNumReal()
		{
			if(realNumPerScreenNum < realNumPerScreenNumMax)
			{
				realNumPerScreenNum++;
			}
			else if (realNumPerScreenNum >= realNumPerScreenNumMax)
			{
				realNumPerScreenNum = 1;
				screenNumReal++;
			}
				return screenNumReal.ToString();
		}

		//주문 유형을 선택
		public int OrderTypeCode(string orderType)
		{
			switch (orderType)
			{
				case "신규매수":
					return 1;
				case "신규매도":
					return 2;
				case "매수취소":
					return 3;
				case "매도취소":
					return 4;
				case "매수정정":
					return 5;
				case "매도정정":
					return 6;
				default:
					return -1;

			}
		}

		//거래 유형을 선택
		public string TradingTypeCode(string tradingType)
		{
			switch (tradingType)
			{
				case "지정가":
					return "00";
				case "시장가":
					return "03";
				case "조건부지정가":
					return "05";
				case "최유리지정가":
					return "06";
				case "최우선지정가":
					return "07";
				case "지정가IOC":
					return "10";
				case "시장가IOC":
					return "13";
				case "최유리IOC":
					return "16";
				case "지정가FOK":
					return "20";
				case "시장가FOK":
					return "23";
				case "최유리FOK":
					return "26";
				case "장전시간외종가":
					return "61";
				case "시간외단일가매매":
					return "62";
				case "장후시간외종가":
					return "81";
				default:
					return "";
			}
		}



		//매도 매수 호가 구분을 int형으로 반환해준다
		public int GetQuoteNum (string quotePrice)
		{
			switch (quotePrice)
			{
				case "매도1호가": return 1;
				case "매도2호가": return 2;
				case "매도3호가": return 3;
				case "매도4호가": return 4;
				case "매도5호가": return 5;
				case "매도6호가": return 6;
				case "매도7호가": return 7;
				case "매도8호가": return 8;
				case "매도9호가": return 9;
				case "매도10호가": return 10;
				case "상한가": return 30;

				case "매수1호가": return -1;
				case "매수2호가": return -2;
				case "매수3호가": return -3;
				case "매수4호가": return -4;
				case "매수5호가": return -5;
				case "매수6호가": return -6;
				case "매수7호가": return -7;
				case "매수8호가": return -8;
				case "매수9호가": return -9;
				case "매수10호가": return -10;
				case "하한가": return -30;

				default: return 0;
			}
		}

		// 주문 수량을 정한다
		internal int GetQuantity(int price, itemInfo item)
		{
			if (price == 0)
				return (int)Config.BUY_AMOUNT_ONCE / int.Parse( item.현재가);

			int quantity = (int)Config.BUY_AMOUNT_ONCE / price;

			return quantity;
		}

		// 주문가격을 정한다
		internal int GetPrice(itemInfo item, string orderType, string quotePrice)
		{
			int price = 0;
			int nowPrice = int.Parse(item.현재가);
			if (orderType == "신규매수" || orderType == "신규매도" || orderType == "매수정정" || orderType == "매도정정")
				if (quotePrice == "현재가")
					return nowPrice;
				else 
					price = GetQuotePrice(item, orderType, quotePrice);

			return price;
		}

		//호가 주문의 경우 호가를 반환해준다
		private int GetQuotePrice(itemInfo item, string orderType, string quotePrice)
		{
			int price = 0;
			int quotePriceNum = GetQuoteNum(quotePrice);
			int coefficient = 0;
			int 최우선매도호가 = int.Parse(item.최우선매도호가);
			int 최우선매수호가 = int.Parse(item.최우선매수호가);
			string market = item.시장구분;

			if (quotePriceNum > 0 && quotePriceNum <= 10)
			{
				price = 최우선매도호가;
				for (int i = 0; i < quotePriceNum; i++)
				{
					coefficient = GetCoefficient(price, market, i);
					price += coefficient; 
				}					
			}
			else if (quotePriceNum < 0 && quotePriceNum >= -10)
			{
				price = 최우선매수호가;
				for (int i = 0; i > quotePriceNum; i--)
				{
					coefficient = GetCoefficient(price, market, i);
					price -= coefficient;
				}
			}
			
			return price;
		}

		//구간별 코스피 코스닥 틱가격
		private int GetCoefficient(int price, string market, int 매도매수)
		{
			int coefficient = 0;
			if (price > 0 && price < 1000)
			{
				coefficient = 1;
			}
			else if (price >= 1000 && price < 5000)
			{
				coefficient = 5;
			}
			else if (price == 1000 && 매도매수 < 0)
				coefficient = 1;
			else if (price >= 5000 && price < 10000)
			{
				coefficient = 10;
			}
			else if (price == 5000 && 매도매수 < 0)
				coefficient = 5;
			else if (price >= 10000 && price < 50000)
			{
				coefficient = 50;
			}
			else if (price == 10000 && 매도매수 < 0)
				coefficient = 10;
			else if (price >= 50000 && price < 100000)
			{
				coefficient = 100;
			}
			else if (price == 50000 && 매도매수 < 0)
				coefficient = 50;
			else if (price >= 100000 && price < 500000)
			{
				if (market == "0")
				{
					coefficient = 500;
					if (price == 100000 && 매도매수 < 0)
						coefficient = 100;
				}
				else if (market == "10")
				{
					coefficient = 100;
				}
			}
			else if (price >= 500000)
			{
				if (market == "0")
				{
					coefficient = 1000;
					if (price == 500000 && 매도매수 < 0)
						coefficient = 500;
				}
				else if (market == "10")
				{
					coefficient = 100;
				}
			}
			return coefficient;
		}

		//종목의 시간차이를 반환해준다
		public double GetDiffTimeItem(itemInfo item)
		{
			double duration = 0.0;
			
			if (item.last포착시간 == DateTime.MinValue)
				item.last포착시간 = item.포착시간;

			TimeSpan timeSpan = DateTime.Now - item.last포착시간;
			duration = timeSpan.TotalSeconds;

			if (duration >= 1.0)
			{
				item.last포착시간 = DateTime.Now;
			}

			return duration;
		}

		//평가손익 계산함수
		public double Get평가손익(itemInfo item, Balances balance)
		{

			double 평가손익 = 0.0;
			double 평균매입가 = Math.Truncate(double.Parse(balance.평균매입가));
			double 현재가 = Math.Abs(double.Parse(item.현재가));
			int 보유수량 = int.Parse(balance.보유수량);
			int 총매입가 = int.Parse(balance.buyPriceTotal);
			int 총평가금 = int.Parse(balance.buyPriceEv);

			if (InstanceManager.userInfo.SERVER_GUBUN != "1")
			{
				평가손익 = 총평가금 - 총매입가
					- (Math.Truncate(평균매입가 * 보유수량 * Config.TRADE_FEE/ 100 / 10) * 10) 
					- (Math.Truncate(총매입가 * Config.TRADE_FEE / 100 / 10) * 10) 
					- (Math.Round(총매입가 * Config.TRADE_TAX / 100));
			}
			else if (InstanceManager.userInfo.SERVER_GUBUN == "1")
			{
				평가손익 = 총평가금 - 총매입가
					- (Math.Truncate(평균매입가 * 보유수량 * Config.TRADE_FEE_IMI/ 100 / 10) * 10)
					- (Math.Truncate(총매입가 * Config.TRADE_FEE_IMI / 100 / 10) * 10)
					- (Math.Round(총매입가 * Config.TRADE_TAX / 100));
			}
			return 평가손익;
		}

		//수익률 계산 함수
		public double Get수익률(double 평가손익, Balances balance)
		{
			double 수익률 = 0.0;
			수익률 = Math.Round(평가손익 / double.Parse(balance.buyPriceTotal) * 100, 2);
			return 수익률;
		}

		// 조회 시간 타이머 초단위 반환
		public double GetDiffTime(DateTime preTime)
		{
			double diffTime = 0.0f;
			TimeSpan timeSpan = DateTime.Now - preTime;
			diffTime = timeSpan.TotalSeconds;
			return diffTime;
		}

	}
}
