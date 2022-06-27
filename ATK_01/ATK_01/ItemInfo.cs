using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATK_01
{
    public class itemInfo
    {
        public string itemName;
        public string itemCode;
        public string 시장구분;
        public string 현재가;
        public string 기준가;
        public string 시가;
        public string 고가;
        public string 저가;
        public string 신용비율;
        public string 등락률;
        public string 상한가;
        public string 하한가;
        public string 전일대비;
        public string 전일대비기호;
        public string 거래량;
        public string 누적거래량;
        public string 체결시간;
        public string 최우선매도호가;
        public string 최우선매수호가;
        public string 체결강도;
        public string VI발동구분;
        public string 총매도잔량;
        public string 총매수잔량;

        public int 점수 = 0;
        public bool 일일포착여부 = false;
        public bool 포착여부 = false;
        public bool 후보여부 = false;
        public bool 주문시도여부 = false;
        public bool 주문요청여부 = false;
        public bool 주문여부 = false;
        public bool 구매여부 = false;
        public bool 주식기본정보요청여부 = false;
        public bool 시세표성정보요청여부 = false;
        public DateTime 포착시간;
        public DateTime last포착시간;
        public List<DataGridView> 포착조건식그리드;
        public bool isFocusItem = false;

        //매매를 했을 경우
        public bool isTrade = false;
        public double 평가손익 = 0;
        public double 수익률 = 0.0;
        public int 총매입금액 = 0;
        

        public itemInfo(string code, string name)
        {
            itemName = name;
            itemCode = code;
            포착조건식그리드 = new List<DataGridView>();
        }
    }
}
