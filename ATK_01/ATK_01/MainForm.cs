using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATK_01
{
    public partial class MainForm : Form
    {
        public static MainForm mainForm; //공용으로 쓰기위한 선언
        public MainForm()
        {
            mainForm = this;            //공용으로 쓰기위한 선언
            InitializeComponent();

            //InstanceManager instanceManager = new InstanceManager(); //인스턴스 매니저 생성
            InitializeInstance();
        }

        //인스턴스 초기화
		private void InitializeInstance()
		{
            Console.WriteLine(InstanceManager.mainForm.ClientSize);
			InstanceManager.config.GetType();
            InstanceManager.Functions.GetType();
            InstanceManager.userInfo.GetType();
            InstanceManager.trRequestManager.GetType();
            InstanceManager.formEventManager.GetType();
            InstanceManager.loginManager.GetType();
            InstanceManager.onReceive.GetType();
            InstanceManager.balanceList.GetType();
            InstanceManager.balanceManager.GetType();
            InstanceManager.itemInfoList.GetType();
            InstanceManager.SearchItemList.GetType();
            InstanceManager.SelectedItemList.GetType();
            InstanceManager.BuyedItemList.GetType();
            InstanceManager.itemManager.GetType();
            InstanceManager.bootDataManager.GetType();

            InstanceManager.conditions.GetType();
            InstanceManager.conditionComboBoxList.GetType();
            InstanceManager.conditionDataGridViews.GetType();
            InstanceManager.conditionManager.GetType();
            InstanceManager.tradeManager.GetType();
            InstanceManager.ordersList.GetType();
            InstanceManager.orderManager.GetType();
            InstanceManager.chartManager.GetType();
            InstanceManager.bookWindowManager.GetType();

		}
	}
}
