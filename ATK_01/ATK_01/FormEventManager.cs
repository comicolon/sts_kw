using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ATK_01
{
    public class FormEventManager
    {
        public bool is실현손익률 = false;
        public FormEventManager()
        {
            SetMainTitleText();

            //툴스트립
            InstanceManager.mainForm.LoginToolStripMenuItem.Click += ToolStripMenuItem_Click;
            InstanceManager.mainForm.전략설정ToolStripMenuItem.Click += ToolStripMenuItem_Click;

            //버튼
            InstanceManager.mainForm.requestAssetsButton.Click += Button_Click;
            InstanceManager.mainForm.Testbutton.Click += Button_Click;
            InstanceManager.mainForm.tradeStartButton.Click += Button_Click;
            InstanceManager.mainForm.tradeStopButton.Click += Button_Click;
            InstanceManager.mainForm.button_conditionSearchStart.Click += Button_Click;
            InstanceManager.mainForm.button_조회.Click += Button_Click;

            //콤보박스
            InstanceManager.mainForm.매도ComboBox.SelectedValueChanged += ComboBox_Changed;
            InstanceManager.mainForm.매수ComboBox.SelectedValueChanged += ComboBox_Changed;
            InstanceManager.mainForm.매도거래타입ComboBox.SelectedValueChanged += ComboBox_Changed;
            InstanceManager.mainForm.매수거래타입ComboBox.SelectedValueChanged += ComboBox_Changed;

            InstanceManager.mainForm.comboBox_condition1.SelectedValueChanged += ComboBox_Changed;
            InstanceManager.mainForm.comboBox_condition2.SelectedValueChanged += ComboBox_Changed;
            InstanceManager.mainForm.comboBox_condition3.SelectedValueChanged += ComboBox_Changed;

            //그리드 셀 클릭
            InstanceManager.mainForm.possessionDataGridView.CellClick += GridView_Click;
            InstanceManager.mainForm.selectedDataGridView.CellClick += GridView_Click;
            InstanceManager.mainForm.con1dataGridView.CellClick += GridView_Click;
            InstanceManager.mainForm.con2dataGridView.CellClick += GridView_Click;
            InstanceManager.mainForm.con3dataGridView.CellClick += GridView_Click;
            InstanceManager.mainForm.order_GridView.CellClick += GridView_Click;

            //차트 줌인 줌아웃 이동
            InstanceManager.mainForm.firstChart.AxisViewChanged += Chart_AxisViewChanged;

            //라벨 클릭
            InstanceManager.mainForm.lb_실현손익.Click += Label_Clisk;

            //주문 그리드 체크박스
            InstanceManager.mainForm.order_GridView.CellPainting += GridView_CellPainting;

        }

		private void GridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
            //if (sender.Equals(mainForm.order_GridView))
                //orderManager.InitOrderGrid(sender, e);
		}

		private void Label_Clisk(object sender, EventArgs e)
		{
            if (sender.Equals(InstanceManager.mainForm.lb_실현손익))
			{
                if (is실현손익률 == true)
				{
                    InstanceManager.mainForm.lb_실현손익.Text = InstanceManager.userInfo.실현손익;
                    InstanceManager.mainForm.lb_실현손익title.Text = "실현손익";
                    is실현손익률 = false;
				}
                else if (is실현손익률 == false)
				{
                    InstanceManager.mainForm.lb_실현손익.Text = InstanceManager.userInfo.실현손익률;
                    InstanceManager.mainForm.lb_실현손익title.Text = "실현손익률";
                    is실현손익률 = true;
				}

			}
		}

		private void Chart_AxisViewChanged(object sender, ViewEventArgs e)
		{
            if (sender.Equals(InstanceManager.mainForm.firstChart))
                InstanceManager.chartManager.DrawChangedChart(e);
		}

		//그리드를 클릭할시에
		private void GridView_Click(object sender, DataGridViewCellEventArgs e)
		{
            //그리드의 종목명을 클릭할시에 처리
            string itemName = "";
            if (sender.Equals(InstanceManager.mainForm.possessionDataGridView))
			{
                itemName = InstanceManager.mainForm.possessionDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            else if (sender.Equals(InstanceManager.mainForm.selectedDataGridView))
			{
                itemName = InstanceManager.mainForm.selectedDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
			}
            else if (sender.Equals(InstanceManager.mainForm.con1dataGridView))
            {
                itemName = InstanceManager.mainForm.con1dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            else if (sender.Equals(InstanceManager.mainForm.con2dataGridView))
            {
                itemName = InstanceManager.mainForm.con2dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            else if (sender.Equals(InstanceManager.mainForm.con3dataGridView))
            {
                itemName = InstanceManager.mainForm.con3dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            }

            if (itemName == null || itemName == "")
                return;

            if(itemName != "")
			{
                itemInfo item = InstanceManager.itemInfoList.Find(obj => obj.itemName == itemName);
                Balances balance = InstanceManager.balanceList.Find(obj => obj.itemCode == item.itemCode);
                string itemCode = item.itemCode;
                InstanceManager.bookWindowManager.biddingEntityArray = new BookWindowManager.BiddingEntityObject[InstanceManager.bookWindowManager.Bid_Range];

                InstanceManager.chartManager.nowChartItem = item;
                InstanceManager.chartManager.nowChartItemCode = itemCode;
                InstanceManager.chartManager.RequestChartMin(itemCode, "3");
                InstanceManager.bookWindowManager.RequestBook(item);

                //============= 디버깅용
                InstanceManager.mainForm.lb_주문시도.Text = item.주문요청여부.ToString();
                InstanceManager.mainForm.lb_주문요청.Text = item.주문요청여부.ToString();
                InstanceManager.mainForm.lb_주문여부.Text = item.주문여부.ToString();
                InstanceManager.mainForm.lb_구매여부.Text = item.구매여부.ToString();
                InstanceManager.mainForm.lb_후보여부.Text = item.후보여부.ToString();
                if (balance != null)
                    InstanceManager.mainForm.lb_트레일링로스.Text = balance.trailingLosss.ToString();

                

                //================ 디버깅용


                if (sender.Equals(InstanceManager.mainForm.possessionDataGridView) && e.ColumnIndex == 4)
                    InstanceManager.tradeManager.SellItem(item, "신규매도");

                if (sender.Equals(InstanceManager.mainForm.selectedDataGridView) && e.ColumnIndex == 4)
                    InstanceManager.tradeManager.BuyItem(item, "신규매수");
			}
            else if (itemName == "")
			{
                if (sender.Equals(InstanceManager.mainForm.order_GridView) && e.ColumnIndex ==7)
				{
                    InstanceManager.orderManager.CancelOrder(InstanceManager.mainForm.order_GridView.Rows[e.RowIndex].Cells[8].Value.ToString());
				}
			}

		}

		private void ComboBox_Changed(object sender, EventArgs e)
		{
            //매도 매수 호가 선택 콤보박스
			if (sender.Equals(InstanceManager.mainForm.매도ComboBox))
			{
                Config.TRADE_ASK_PRICE = InstanceManager.mainForm.매도ComboBox.Text;
			}
            else if (sender.Equals(InstanceManager.mainForm.매수ComboBox))
			{
                Config.TRADE_BID_PRICE = InstanceManager.mainForm.매수ComboBox.Text;
            }

            //매수 매도 거래 유형 선택 콤보박스
            if (sender.Equals(InstanceManager.mainForm.매도거래타입ComboBox))
			{
                Config.TRADE_TYPE_CODE_SELL = InstanceManager.mainForm.매도거래타입ComboBox.Text;
			}
            else if (sender.Equals(InstanceManager.mainForm.매도거래타입ComboBox))
            {
                Config.TRADE_TYPE_CODE_BUY = InstanceManager.mainForm.매수거래타입ComboBox.Text;
            }

            if (sender.Equals(InstanceManager.mainForm.comboBox_condition1))
			{
                ComboBox comboBox = InstanceManager.mainForm.comboBox_condition1;
                InstanceManager.conditionManager.SetSelectCondition(comboBox);
			}
            else if (sender.Equals(InstanceManager.mainForm.comboBox_condition2))
			{
                ComboBox comboBox = InstanceManager.mainForm.comboBox_condition2;
                InstanceManager.conditionManager.SetSelectCondition(comboBox);
			}
            else if (sender.Equals(InstanceManager.mainForm.comboBox_condition3))
			{
                ComboBox comboBox = InstanceManager.mainForm.comboBox_condition3;
                InstanceManager.conditionManager.SetSelectCondition(comboBox);
			}
        }

        //일반버튼 이벤트
        public void Button_Click(object sender, EventArgs e)
        {
            //자산조회 버튼 클릭의 경우
            if (sender.Equals(MainForm.mainForm.requestAssetsButton))
            {
                InstanceManager.Functions.GetBalanceInfo();
            }
            else if (sender.Equals(InstanceManager.mainForm.Testbutton))
			{
				Console.WriteLine("보유종목 수 : " + InstanceManager.balanceList.Count);
				Console.WriteLine("주문 수 : " + InstanceManager.orderManager.onOrderCnt);

            }
            else if (sender.Equals(InstanceManager.mainForm.tradeStartButton))
			{
                Config.IS_TRADE_NOW = true;
                InstanceManager.mainForm.tradeStartButton.BackColor = Color.DarkSeaGreen;
			}
            else if (sender.Equals(InstanceManager.mainForm.tradeStopButton))
			{
                Config.IS_TRADE_NOW = false;
                InstanceManager.mainForm.tradeStartButton.BackColor = Color.SlateGray;
			}
            else if (sender.Equals(InstanceManager.mainForm.button_conditionSearchStart))
			{
                InstanceManager.conditionManager.GetCondition();
			}
            else if (sender.Equals(InstanceManager.mainForm.button_조회))
			{
                itemInfo item = InstanceManager.itemInfoList.Find(obj => obj.itemName == InstanceManager.mainForm.textBox_SearchBox.Text);
                if (item != null)
				{
                    InstanceManager.chartManager.RequestChartMin(item.itemCode, "3");
                    InstanceManager.bookWindowManager.RequestBook(item);
				}
			}
        }

        //툴스트립메뉴 이벤트
        public void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender.Equals(MainForm.mainForm.LoginToolStripMenuItem))
            {
                InstanceManager.loginManager.Login();
            }
            else if (sender.Equals(InstanceManager.mainForm.전략설정ToolStripMenuItem))
			{
                SetupStrategyForm setupStrategyForm = new SetupStrategyForm();
                setupStrategyForm.ShowDialog();
			}
        }

        //
		private void RadioButton_Click(object sender, EventArgs e)
		{
        
		}

       private void SetMainTitleText()
		{
            InstanceManager.mainForm.Text = InstanceManager.mainForm.Text + " " + Config.VERSION;
		}
    }
}
