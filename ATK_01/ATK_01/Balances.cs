using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATK_01
{
	public class Balances
	{
		public string account = "";		//보유계좌
		public string itemCode = "";	//종목코드
		public string 종목명 = "";
		public string 평가손익 = "";
		public string 수익률 = "";
		public string 등락률 = "";
		public List<string> 매입단가 = new List<string>();
		public string 평균매입가 = "";		//평균매입가
		public string 보유수량 = "";
		public string nowPrice = "";	//현재가
		public string buyPriceTotal = "";	//총매입금액
		public string buyPriceEv = "";  //총평가금액

		//스탑트레일링 설정
		public int stopTrailingMod = 0;			//트레일링 로스 여부 0.기본 1.트레일링 로스 적용
		public double trailingLosss = 0.1;

		public Balances(string account, string itemCode)
		{
			this.account = account;
			this.itemCode = itemCode;
		}
	}
}
