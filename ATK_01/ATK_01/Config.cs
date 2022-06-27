using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATK_01
{
    public class Config
    {
        public static string VERSION = "0.1.02";     // 버전
        public static bool IS_TRADE_NOW = false;    // 현재 거래가 진행중인가?
        //수수료 및 세금
        public static double TRADE_TAX = 0.23;      //매도 세금
        public static double TRADE_FEE = 0.015;     //매수 매도 수수료
        public static double TRADE_FEE_IMI = 0.35;   //모의투자 매수 매도 수수료
       
        public static int CONDITION_USE_NUM = 3;            //사용 조건검색식 갯수
        //검색종목 점수 관련
        public static int IN_ITEM_SECOND_ADD_POINT = 5;       //검색종목 초당 더해주는 점수
        public static int IN_ITEM_BIG_BUY_ADD_POINT = 7;        //검색종목 대량매수 증가 점수
        public static int IN_ITEM_BIG_SELL_DEDUCT_POINT = 7;    //검색종목 대량매도 차감 점수
        public static int IN_ITEM_POINT_MAX = 100;  //검색 종목 점수 최대
        public static int ITEM_POINT_MIN = -200;    // 검색 종목 점수 최하
        //후보종목 점수 관련
        public static int SELECT_ITEM_SECOND_ADD_POINT = 5;    //후보 종목 초당 더해주는 점수
        public static int SELECT_ITEM_SECOND_DEDUCT_POINT = 5;      // 후보종목 초당 차감 점수

        //검색 후보 구매 종목 모두 
        public static int SELECT_ITEM_BIG_BUY_ADD_POINT = 7;        //후보종목 대량매수 증가 점수
        public static int SELECT_ITEM_BIG_SELL_DEDUCT_POINT = 7;    //후보종목 대량매도 차감 점수

        public static int TOTAL_BOOK_RATIO_ASK_ASEND_2 = 1;         // 매도매수 비율 매도우세 2
        public static int TOTAL_BOOK_RATIO_ASK_ASEND_3 = 2;
        public static int TOTAL_BOOK_RATIO_ASK_ASEND_4 = 3;
        public static int TOTAL_BOOK_RATIO_ASK_ASEND_5 = 4;
        public static int TOTAL_BOOK_RATIO_ASK_ASEND_6 = 5;
        public static int TOTAL_BOOK_RATIO_ASK_ASEND_7 = 6;
        public static int TOTAL_BOOK_RATIO_ASK_ASEND_8 = 7;

        public static int TOTAL_BOOK_RATIO_BID_ASEND_2 = 1;         // 매도매수 비율  매수우세 2
        public static int TOTAL_BOOK_RATIO_BID_ASEND_3 = 2;
        public static int TOTAL_BOOK_RATIO_BID_ASEND_4 = 3;
        public static int TOTAL_BOOK_RATIO_BID_ASEND_5 = 4;
        public static int TOTAL_BOOK_RATIO_BID_ASEND_6 = 5;
        public static int TOTAL_BOOK_RATIO_BID_ASEND_7 = 6;
        public static int TOTAL_BOOK_RATIO_BID_ASEND_8 = 7;

        public static int ITEM_BUY_POINT = 150;                     // 사는 주식 점수
        public static int BALANCE_PROFIT_LOSS_CRITERIA = 120;             // 보유종목 익절 OR 트레일링로스 기준 점수
        public static int SELECT_POINT_MAX = 500;                   //후보 종목 점수 최대
        public static int BALANCE_SELL_POINT_CRITERIA = -150;       // 자동 매도 시작 점수
        //주문시 주문조건
        public static long TOTAL_DEPOSIT = 0; //예수금
        public static int  ORDER_COUNT_MAX = 3;     //최대 주문수
        public static long BUY_AMOUNT_ONCE = 250000;    // 주문당 거래금액
        public static string TRADE_TYPE_CODE_BUY = "지정가";    // 매수 거래 타입 (기본 지정가)
        public static string TRADE_TYPE_CODE_SELL = "시장가";   // 매도 거래 타입 (기본 시장가)
        public static string TRADE_ASK_PRICE = "현재가";   //매도호가
        public static string TRADE_BID_PRICE = "현재가";   //매수호가
        //매수매도관련
        public static double STOP_LOSS = -2.1;           //기본 손절기준
        public static double PROFIT_LOSS = 3.3;         //기본 익절기준
        public static double TRAILING_LOSS_START_CRITERIA = 2.5;    // 트레일링 로스 변환 기준
        public static double TRAILING_LOSS = 2.1;
        public static double PROFIT_LOSS_MAX = 9.5;           // 트레일링 로스 최대 익절기준
        //대량거래 기준
        public static int BIG_BUY_CRITERIA = 50000000;        // 대량 매수 기준
        public static int BIG_SELL_CRITERIA = -50000000;         // 대량 매도 기준
        //차트 관련
        public static int MIN_CHART_NUM_LIMIT = 100;        // 분봉차트 보여주는 봉 갯수

       public Config()
        {

        }

    }
}
