using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ATK_01
{
    //인스턴스 매니저 생성 여러개 만들지 못함
    public static class InstanceManager
    {
        public static readonly AxKHOpenAPILib.AxKHOpenAPI OpenAPI = MainForm.mainForm.axKHOpenAPI1;
        
        public static MainForm mainForm = MainForm.mainForm;
        public static Config config = new Config(); // config 
		public static Functions Functions = new Functions(); //함수 
        public static UserInfo userInfo = new UserInfo();   //유저인포

        public static TrRequestManager trRequestManager = new TrRequestManager(); // TR 리퀘스트 전용 매니저
		public static FormEventManager formEventManager = new FormEventManager(); //폼 이벤트
        public static LoginManager loginManager = new LoginManager(); //로그인 매니저
        public static OnReceive onReceive = new OnReceive(); // onreceive 전담 매니저
        
        public static List<Balances> balanceList = new List<Balances>(); //보유종목 리스트
        public static BalanceManager balanceManager = new BalanceManager();     //잔고 매니저

        public static List<itemInfo> itemInfoList = new List<itemInfo>(); // 종목리스트
        public static List<itemInfo> SearchItemList = new List<itemInfo>(); // 포착 종목 리스트
        public static List<itemInfo> SelectedItemList = new List<itemInfo>(); // 후보 종목 리스트
        public static List<itemInfo> BuyedItemList = new List<itemInfo>();    // 구매 종목 리스트
        public static ItemManager itemManager = new ItemManager();             //아이템 매니저
        public static BootDataManager bootDataManager = new BootDataManager();     //실행시 데이터 매니저

        //조건식 관련
        public static List<Condition> conditions = new List<Condition>();                           //사용자 조건식 리스트
        public static ComboBox[] conditionComboBoxList = new ComboBox[Config.CONDITION_USE_NUM];                 // 조건검색 레이블 배열
        public static DataGridView[] conditionDataGridViews = new DataGridView[Config.CONDITION_USE_NUM];//조건검색 그리드뷰 배열
        public static ConditionManager conditionManager = new ConditionManager(); // 컨디션 매니저

        public static TradeManager tradeManager = new TradeManager();       // 트레이드 매니저
        public static List<Orders> ordersList = new List<Orders>(); // 주문 리스트

        public static OrderManager orderManager = new OrderManager();       //오더 매니저
        public static ChartManager chartManager = new ChartManager();       // 차트 매니저
        public static BookWindowManager bookWindowManager = new BookWindowManager();        //호가창 매니저

        
    }
}
