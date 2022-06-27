
using System.Drawing;

namespace ATK_01
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        public void InitializeComponent()
        {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.LoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.전략설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lb_수익률 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lb_총손익금 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lb_총매입금 = new System.Windows.Forms.Label();
			this.lb_총평가금 = new System.Windows.Forms.Label();
			this.lb_예수금 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lb_실현손익title = new System.Windows.Forms.Label();
			this.lb_실현손익 = new System.Windows.Forms.Label();
			this.requestAssetsButton = new System.Windows.Forms.Button();
			this.accountComboBox = new System.Windows.Forms.ComboBox();
			this.possessionDataGridView = new System.Windows.Forms.DataGridView();
			this.종목명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.평가손익 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.수익률 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.등락률 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.즉시매도 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.점수 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.보유수량 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.매입가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.현재가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.총매입가액 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.총평가금액 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1 = new System.Windows.Forms.Panel();
			this.comboBox_condition1 = new System.Windows.Forms.ComboBox();
			this.con1dataGridView = new System.Windows.Forms.DataGridView();
			this.con1_종목명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.con1_등락률 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.con1_점수 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel2 = new System.Windows.Forms.Panel();
			this.comboBox_condition3 = new System.Windows.Forms.ComboBox();
			this.con3dataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.con2dataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel3 = new System.Windows.Forms.Panel();
			this.comboBox_condition2 = new System.Windows.Forms.ComboBox();
			this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
			this.selectedDataGridView = new System.Windows.Forms.DataGridView();
			this.slt_종목명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.slt_현재가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.slt_등락률 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.slt_점수 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.slt_즉시매수 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.매수구분GroupBox = new System.Windows.Forms.GroupBox();
			this.매수거래타입ComboBox = new System.Windows.Forms.ComboBox();
			this.매수ComboBox = new System.Windows.Forms.ComboBox();
			this.매도구분GroupBox = new System.Windows.Forms.GroupBox();
			this.매도거래타입ComboBox = new System.Windows.Forms.ComboBox();
			this.매도ComboBox = new System.Windows.Forms.ComboBox();
			this.Testbutton = new System.Windows.Forms.Button();
			this.firstChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tradeStopButton = new System.Windows.Forms.Button();
			this.tradeStartButton = new System.Windows.Forms.Button();
			this.lb_book_nowPrice = new System.Windows.Forms.Label();
			this.lb_book_전일대비 = new System.Windows.Forms.Label();
			this.lb_book_등락률 = new System.Windows.Forms.Label();
			this.lb_book_volume = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.listView_book_contract = new System.Windows.Forms.ListView();
			this.listBox_book_quoteDown = new System.Windows.Forms.ListBox();
			this.listBox_book_quoteUp = new System.Windows.Forms.ListBox();
			this.listBox_book_bidAmount = new System.Windows.Forms.ListBox();
			this.listBox_book_itemInfo = new System.Windows.Forms.ListBox();
			this.listBox_book_adkAmount = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.lb_book_총매도잔량 = new System.Windows.Forms.Label();
			this.lb_book_총매수잔량 = new System.Windows.Forms.Label();
			this.lb_book_총잔량차이 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.lb_주문시도 = new System.Windows.Forms.Label();
			this.lb_주문요청 = new System.Windows.Forms.Label();
			this.lb_주문여부 = new System.Windows.Forms.Label();
			this.lb_구매여부 = new System.Windows.Forms.Label();
			this.lb_후보여부 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage_balance = new System.Windows.Forms.TabPage();
			this.tabPage_notContractOrder = new System.Windows.Forms.TabPage();
			this.order_GridView = new System.Windows.Forms.DataGridView();
			this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.on_주문 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.on_종목명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.on_구분 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.on_주문가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.on_주문량 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.on_미체결 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.on_즉시취소 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.on_주문번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button_conditionSearchStart = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.lb_트레일링로스 = new System.Windows.Forms.Label();
			this.button_조회 = new System.Windows.Forms.Button();
			this.textBox_SearchBox = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.possessionDataGridView)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.con1dataGridView)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.con3dataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.con2dataGridView)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.selectedDataGridView)).BeginInit();
			this.매수구분GroupBox.SuspendLayout();
			this.매도구분GroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.firstChart)).BeginInit();
			this.panel4.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage_balance.SuspendLayout();
			this.tabPage_notContractOrder.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.order_GridView)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoginToolStripMenuItem,
            this.전략설정ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1313, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// LoginToolStripMenuItem
			// 
			this.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem";
			this.LoginToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.LoginToolStripMenuItem.Text = "로그인";
			// 
			// 전략설정ToolStripMenuItem
			// 
			this.전략설정ToolStripMenuItem.Name = "전략설정ToolStripMenuItem";
			this.전략설정ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.전략설정ToolStripMenuItem.Text = "전략설정";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 6;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66583F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66583F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66583F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66583F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66583F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.67083F));
			this.tableLayoutPanel1.Controls.Add(this.lb_수익률, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label8, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.lb_총손익금, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.label7, 4, 1);
			this.tableLayoutPanel1.Controls.Add(this.lb_총매입금, 5, 0);
			this.tableLayoutPanel1.Controls.Add(this.lb_총평가금, 5, 1);
			this.tableLayoutPanel1.Controls.Add(this.lb_예수금, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.lb_실현손익title, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.lb_실현손익, 3, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(686, 27);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(606, 51);
			this.tableLayoutPanel1.TabIndex = 8;
			// 
			// lb_수익률
			// 
			this.lb_수익률.Location = new System.Drawing.Point(104, 26);
			this.lb_수익률.Name = "lb_수익률";
			this.lb_수익률.Size = new System.Drawing.Size(90, 24);
			this.lb_수익률.TabIndex = 9;
			this.lb_수익률.Text = "0";
			this.lb_수익률.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(204, 26);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(90, 24);
			this.label8.TabIndex = 5;
			this.label8.Text = "총손익";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lb_총손익금
			// 
			this.lb_총손익금.Location = new System.Drawing.Point(304, 26);
			this.lb_총손익금.Name = "lb_총손익금";
			this.lb_총손익금.Size = new System.Drawing.Size(91, 24);
			this.lb_총손익금.TabIndex = 7;
			this.lb_총손익금.Text = "0";
			this.lb_총손익금.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(404, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 24);
			this.label4.TabIndex = 1;
			this.label4.Text = "총매입금";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(404, 26);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(90, 24);
			this.label7.TabIndex = 4;
			this.label7.Text = "총평가금";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lb_총매입금
			// 
			this.lb_총매입금.Location = new System.Drawing.Point(504, 1);
			this.lb_총매입금.Name = "lb_총매입금";
			this.lb_총매입금.Size = new System.Drawing.Size(90, 24);
			this.lb_총매입금.TabIndex = 3;
			this.lb_총매입금.Text = "0";
			this.lb_총매입금.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lb_총평가금
			// 
			this.lb_총평가금.Location = new System.Drawing.Point(504, 26);
			this.lb_총평가금.Name = "lb_총평가금";
			this.lb_총평가금.Size = new System.Drawing.Size(91, 24);
			this.lb_총평가금.TabIndex = 6;
			this.lb_총평가금.Text = "0";
			this.lb_총평가금.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lb_예수금
			// 
			this.lb_예수금.Location = new System.Drawing.Point(104, 1);
			this.lb_예수금.Name = "lb_예수금";
			this.lb_예수금.Size = new System.Drawing.Size(90, 24);
			this.lb_예수금.TabIndex = 2;
			this.lb_예수금.Text = "0";
			this.lb_예수금.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 24);
			this.label3.TabIndex = 0;
			this.label3.Text = "예수금";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 24);
			this.label2.TabIndex = 8;
			this.label2.Text = "수익률";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lb_실현손익title
			// 
			this.lb_실현손익title.Location = new System.Drawing.Point(204, 1);
			this.lb_실현손익title.Name = "lb_실현손익title";
			this.lb_실현손익title.Size = new System.Drawing.Size(90, 24);
			this.lb_실현손익title.TabIndex = 0;
			this.lb_실현손익title.Text = "실현손익";
			this.lb_실현손익title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lb_실현손익
			// 
			this.lb_실현손익.Location = new System.Drawing.Point(304, 1);
			this.lb_실현손익.Name = "lb_실현손익";
			this.lb_실현손익.Size = new System.Drawing.Size(93, 24);
			this.lb_실현손익.TabIndex = 10;
			this.lb_실현손익.Text = "0";
			this.lb_실현손익.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// requestAssetsButton
			// 
			this.requestAssetsButton.Location = new System.Drawing.Point(559, 55);
			this.requestAssetsButton.Name = "requestAssetsButton";
			this.requestAssetsButton.Size = new System.Drawing.Size(75, 23);
			this.requestAssetsButton.TabIndex = 9;
			this.requestAssetsButton.Text = "자산조회";
			this.requestAssetsButton.UseVisualStyleBackColor = true;
			// 
			// accountComboBox
			// 
			this.accountComboBox.FormattingEnabled = true;
			this.accountComboBox.Location = new System.Drawing.Point(559, 32);
			this.accountComboBox.Name = "accountComboBox";
			this.accountComboBox.Size = new System.Drawing.Size(121, 20);
			this.accountComboBox.TabIndex = 10;
			// 
			// possessionDataGridView
			// 
			this.possessionDataGridView.AllowUserToAddRows = false;
			this.possessionDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.possessionDataGridView.BackgroundColor = System.Drawing.Color.Gainsboro;
			this.possessionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.possessionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.종목명,
            this.평가손익,
            this.수익률,
            this.등락률,
            this.즉시매도,
            this.점수,
            this.보유수량,
            this.매입가,
            this.현재가,
            this.총매입가액,
            this.총평가금액});
			this.possessionDataGridView.Location = new System.Drawing.Point(1, 0);
			this.possessionDataGridView.MultiSelect = false;
			this.possessionDataGridView.Name = "possessionDataGridView";
			this.possessionDataGridView.ReadOnly = true;
			this.possessionDataGridView.RowHeadersVisible = false;
			this.possessionDataGridView.RowTemplate.Height = 23;
			this.possessionDataGridView.Size = new System.Drawing.Size(733, 109);
			this.possessionDataGridView.TabIndex = 11;
			// 
			// 종목명
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.종목명.DefaultCellStyle = dataGridViewCellStyle1;
			this.종목명.HeaderText = "종목명";
			this.종목명.Name = "종목명";
			this.종목명.ReadOnly = true;
			this.종목명.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.종목명.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// 평가손익
			// 
			this.평가손익.HeaderText = "평가손익";
			this.평가손익.Name = "평가손익";
			this.평가손익.ReadOnly = true;
			this.평가손익.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// 수익률
			// 
			this.수익률.HeaderText = "수익률";
			this.수익률.Name = "수익률";
			this.수익률.ReadOnly = true;
			this.수익률.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.수익률.Width = 70;
			// 
			// 등락률
			// 
			this.등락률.HeaderText = "등락률";
			this.등락률.Name = "등락률";
			this.등락률.ReadOnly = true;
			// 
			// 즉시매도
			// 
			this.즉시매도.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.즉시매도.DefaultCellStyle = dataGridViewCellStyle2;
			this.즉시매도.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.즉시매도.HeaderText = "즉시매도";
			this.즉시매도.Name = "즉시매도";
			this.즉시매도.ReadOnly = true;
			this.즉시매도.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.즉시매도.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.즉시매도.Width = 78;
			// 
			// 점수
			// 
			this.점수.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
			this.점수.DefaultCellStyle = dataGridViewCellStyle3;
			this.점수.HeaderText = "점수";
			this.점수.Name = "점수";
			this.점수.ReadOnly = true;
			this.점수.Width = 54;
			// 
			// 보유수량
			// 
			this.보유수량.HeaderText = "수량";
			this.보유수량.Name = "보유수량";
			this.보유수량.ReadOnly = true;
			this.보유수량.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.보유수량.Width = 60;
			// 
			// 매입가
			// 
			this.매입가.HeaderText = "매입가";
			this.매입가.Name = "매입가";
			this.매입가.ReadOnly = true;
			this.매입가.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// 현재가
			// 
			this.현재가.HeaderText = "현재가";
			this.현재가.Name = "현재가";
			this.현재가.ReadOnly = true;
			this.현재가.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// 총매입가액
			// 
			this.총매입가액.HeaderText = "총매입가액";
			this.총매입가액.Name = "총매입가액";
			this.총매입가액.ReadOnly = true;
			this.총매입가액.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// 총평가금액
			// 
			this.총평가금액.HeaderText = "총평가금액";
			this.총평가금액.Name = "총평가금액";
			this.총평가금액.ReadOnly = true;
			this.총평가금액.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.comboBox_condition1);
			this.panel1.Controls.Add(this.con1dataGridView);
			this.panel1.Location = new System.Drawing.Point(703, 556);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(194, 245);
			this.panel1.TabIndex = 12;
			// 
			// comboBox_condition1
			// 
			this.comboBox_condition1.FormattingEnabled = true;
			this.comboBox_condition1.Location = new System.Drawing.Point(6, 3);
			this.comboBox_condition1.Name = "comboBox_condition1";
			this.comboBox_condition1.Size = new System.Drawing.Size(121, 20);
			this.comboBox_condition1.TabIndex = 2;
			// 
			// con1dataGridView
			// 
			this.con1dataGridView.AllowUserToAddRows = false;
			this.con1dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.con1dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.con1_종목명,
            this.con1_등락률,
            this.con1_점수});
			this.con1dataGridView.Font = new System.Drawing.Font("Tahoma", 7F);
			this.con1dataGridView.Location = new System.Drawing.Point(6, 29);
			this.con1dataGridView.Name = "con1dataGridView";
			this.con1dataGridView.RowHeadersVisible = false;
			this.con1dataGridView.RowTemplate.Height = 23;
			this.con1dataGridView.Size = new System.Drawing.Size(179, 216);
			this.con1dataGridView.TabIndex = 1;
			// 
			// con1_종목명
			// 
			this.con1_종목명.HeaderText = "종목명";
			this.con1_종목명.Name = "con1_종목명";
			this.con1_종목명.ReadOnly = true;
			this.con1_종목명.Width = 65;
			// 
			// con1_등락률
			// 
			this.con1_등락률.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.con1_등락률.HeaderText = "등락률";
			this.con1_등락률.Name = "con1_등락률";
			this.con1_등락률.ReadOnly = true;
			this.con1_등락률.Width = 60;
			// 
			// con1_점수
			// 
			this.con1_점수.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.con1_점수.HeaderText = "점수";
			this.con1_점수.Name = "con1_점수";
			this.con1_점수.ReadOnly = true;
			this.con1_점수.Width = 50;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.comboBox_condition3);
			this.panel2.Controls.Add(this.con3dataGridView);
			this.panel2.Location = new System.Drawing.Point(1092, 556);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(203, 245);
			this.panel2.TabIndex = 13;
			// 
			// comboBox_condition3
			// 
			this.comboBox_condition3.FormattingEnabled = true;
			this.comboBox_condition3.Location = new System.Drawing.Point(11, 3);
			this.comboBox_condition3.Name = "comboBox_condition3";
			this.comboBox_condition3.Size = new System.Drawing.Size(121, 20);
			this.comboBox_condition3.TabIndex = 4;
			// 
			// con3dataGridView
			// 
			this.con3dataGridView.AllowUserToAddRows = false;
			this.con3dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.con3dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
			this.con3dataGridView.Font = new System.Drawing.Font("Tahoma", 7F);
			this.con3dataGridView.Location = new System.Drawing.Point(11, 29);
			this.con3dataGridView.Name = "con3dataGridView";
			this.con3dataGridView.RowHeadersVisible = false;
			this.con3dataGridView.RowTemplate.Height = 23;
			this.con3dataGridView.Size = new System.Drawing.Size(178, 216);
			this.con3dataGridView.TabIndex = 3;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.HeaderText = "종목명";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Width = 65;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.dataGridViewTextBoxColumn5.HeaderText = "등락률";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Width = 60;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.dataGridViewTextBoxColumn6.HeaderText = "점수";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Width = 50;
			// 
			// con2dataGridView
			// 
			this.con2dataGridView.AllowUserToAddRows = false;
			this.con2dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.con2dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
			this.con2dataGridView.Font = new System.Drawing.Font("Tahoma", 7F);
			this.con2dataGridView.Location = new System.Drawing.Point(4, 29);
			this.con2dataGridView.Name = "con2dataGridView";
			this.con2dataGridView.RowHeadersVisible = false;
			this.con2dataGridView.RowTemplate.Height = 23;
			this.con2dataGridView.Size = new System.Drawing.Size(179, 216);
			this.con2dataGridView.TabIndex = 2;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "종목명";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 65;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.dataGridViewTextBoxColumn2.HeaderText = "등락률";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 60;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.dataGridViewTextBoxColumn3.HeaderText = "점수";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Width = 50;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.comboBox_condition2);
			this.panel3.Controls.Add(this.con2dataGridView);
			this.panel3.Location = new System.Drawing.Point(903, 556);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(183, 245);
			this.panel3.TabIndex = 14;
			// 
			// comboBox_condition2
			// 
			this.comboBox_condition2.FormattingEnabled = true;
			this.comboBox_condition2.Location = new System.Drawing.Point(4, 3);
			this.comboBox_condition2.Name = "comboBox_condition2";
			this.comboBox_condition2.Size = new System.Drawing.Size(121, 20);
			this.comboBox_condition2.TabIndex = 3;
			// 
			// axKHOpenAPI1
			// 
			this.axKHOpenAPI1.Enabled = true;
			this.axKHOpenAPI1.Location = new System.Drawing.Point(1213, 0);
			this.axKHOpenAPI1.Name = "axKHOpenAPI1";
			this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
			this.axKHOpenAPI1.Size = new System.Drawing.Size(100, 50);
			this.axKHOpenAPI1.TabIndex = 1;
			// 
			// selectedDataGridView
			// 
			this.selectedDataGridView.AllowUserToAddRows = false;
			this.selectedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.selectedDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.slt_종목명,
            this.slt_현재가,
            this.slt_등락률,
            this.slt_점수,
            this.slt_즉시매수});
			this.selectedDataGridView.Location = new System.Drawing.Point(306, 570);
			this.selectedDataGridView.Name = "selectedDataGridView";
			this.selectedDataGridView.RowHeadersVisible = false;
			this.selectedDataGridView.RowTemplate.Height = 23;
			this.selectedDataGridView.Size = new System.Drawing.Size(391, 231);
			this.selectedDataGridView.TabIndex = 16;
			// 
			// slt_종목명
			// 
			this.slt_종목명.HeaderText = "종목명";
			this.slt_종목명.Name = "slt_종목명";
			this.slt_종목명.ReadOnly = true;
			this.slt_종목명.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// slt_현재가
			// 
			this.slt_현재가.HeaderText = "현재가";
			this.slt_현재가.Name = "slt_현재가";
			this.slt_현재가.ReadOnly = true;
			this.slt_현재가.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.slt_현재가.Width = 80;
			// 
			// slt_등락률
			// 
			this.slt_등락률.HeaderText = "등락률";
			this.slt_등락률.Name = "slt_등락률";
			this.slt_등락률.ReadOnly = true;
			this.slt_등락률.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.slt_등락률.Width = 70;
			// 
			// slt_점수
			// 
			this.slt_점수.HeaderText = "점수";
			this.slt_점수.Name = "slt_점수";
			this.slt_점수.ReadOnly = true;
			this.slt_점수.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.slt_점수.Width = 60;
			// 
			// slt_즉시매수
			// 
			this.slt_즉시매수.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.Khaki;
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
			this.slt_즉시매수.DefaultCellStyle = dataGridViewCellStyle4;
			this.slt_즉시매수.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.slt_즉시매수.HeaderText = "즉시매수";
			this.slt_즉시매수.Name = "slt_즉시매수";
			this.slt_즉시매수.ReadOnly = true;
			this.slt_즉시매수.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.slt_즉시매수.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.slt_즉시매수.Width = 78;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(487, 555);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 17;
			this.label1.Text = "후보종목";
			// 
			// 매수구분GroupBox
			// 
			this.매수구분GroupBox.Controls.Add(this.매수거래타입ComboBox);
			this.매수구분GroupBox.Controls.Add(this.매수ComboBox);
			this.매수구분GroupBox.Location = new System.Drawing.Point(188, 704);
			this.매수구분GroupBox.Name = "매수구분GroupBox";
			this.매수구분GroupBox.Size = new System.Drawing.Size(112, 97);
			this.매수구분GroupBox.TabIndex = 20;
			this.매수구분GroupBox.TabStop = false;
			this.매수구분GroupBox.Text = "매수구분";
			// 
			// 매수거래타입ComboBox
			// 
			this.매수거래타입ComboBox.FormattingEnabled = true;
			this.매수거래타입ComboBox.Items.AddRange(new object[] {
            "지정가",
            "시장가",
            "조건부지정가",
            "최유리지정가",
            "최우선지정가",
            "지정가IOC",
            "시장가IOC",
            "최유리IOC",
            "지정가FOK",
            "시장가FOK",
            "최유리FOK",
            "장전시간외종가",
            "시간외단일가매매",
            "장후시간외종가"});
			this.매수거래타입ComboBox.Location = new System.Drawing.Point(7, 20);
			this.매수거래타입ComboBox.MaxDropDownItems = 12;
			this.매수거래타입ComboBox.Name = "매수거래타입ComboBox";
			this.매수거래타입ComboBox.Size = new System.Drawing.Size(99, 20);
			this.매수거래타입ComboBox.TabIndex = 23;
			// 
			// 매수ComboBox
			// 
			this.매수ComboBox.FormattingEnabled = true;
			this.매수ComboBox.Items.AddRange(new object[] {
            "현재가",
            "매수1호가",
            "매수2호가",
            "매수3호가",
            "매수4호가",
            "매수5호가",
            "매수6호가",
            "매수7호가",
            "매수8호가",
            "매수9호가",
            "매수10호가",
            "하한가"});
			this.매수ComboBox.Location = new System.Drawing.Point(7, 65);
			this.매수ComboBox.MaxDropDownItems = 12;
			this.매수ComboBox.Name = "매수ComboBox";
			this.매수ComboBox.Size = new System.Drawing.Size(99, 20);
			this.매수ComboBox.TabIndex = 20;
			this.매수ComboBox.Text = "현재가";
			// 
			// 매도구분GroupBox
			// 
			this.매도구분GroupBox.Controls.Add(this.매도거래타입ComboBox);
			this.매도구분GroupBox.Controls.Add(this.매도ComboBox);
			this.매도구분GroupBox.Location = new System.Drawing.Point(188, 571);
			this.매도구분GroupBox.Name = "매도구분GroupBox";
			this.매도구분GroupBox.Size = new System.Drawing.Size(112, 90);
			this.매도구분GroupBox.TabIndex = 21;
			this.매도구분GroupBox.TabStop = false;
			this.매도구분GroupBox.Text = "매도구분";
			// 
			// 매도거래타입ComboBox
			// 
			this.매도거래타입ComboBox.FormattingEnabled = true;
			this.매도거래타입ComboBox.Items.AddRange(new object[] {
            "지정가",
            "시장가",
            "조건부지정가",
            "최유리지정가",
            "최우선지정가",
            "지정가IOC",
            "시장가IOC",
            "최유리IOC",
            "지정가FOK",
            "시장가FOK",
            "최유리FOK",
            "장전시간외종가",
            "시간외단일가매매",
            "장후시간외종가"});
			this.매도거래타입ComboBox.Location = new System.Drawing.Point(7, 20);
			this.매도거래타입ComboBox.MaxDropDownItems = 12;
			this.매도거래타입ComboBox.Name = "매도거래타입ComboBox";
			this.매도거래타입ComboBox.Size = new System.Drawing.Size(99, 20);
			this.매도거래타입ComboBox.TabIndex = 22;
			// 
			// 매도ComboBox
			// 
			this.매도ComboBox.FormattingEnabled = true;
			this.매도ComboBox.Items.AddRange(new object[] {
            "현재가",
            "매도1호가",
            "매도2호가",
            "매도3호가",
            "매도4호가",
            "매도5호가",
            "매도6호가",
            "매도7호가",
            "매도8호가",
            "매도9호가",
            "매도10호가",
            "상한가"});
			this.매도ComboBox.Location = new System.Drawing.Point(7, 64);
			this.매도ComboBox.MaxDropDownItems = 12;
			this.매도ComboBox.Name = "매도ComboBox";
			this.매도ComboBox.Size = new System.Drawing.Size(99, 20);
			this.매도ComboBox.TabIndex = 21;
			this.매도ComboBox.Text = "현재가";
			// 
			// Testbutton
			// 
			this.Testbutton.Location = new System.Drawing.Point(1173, 319);
			this.Testbutton.Name = "Testbutton";
			this.Testbutton.Size = new System.Drawing.Size(75, 23);
			this.Testbutton.TabIndex = 22;
			this.Testbutton.Text = "button1";
			this.Testbutton.UseVisualStyleBackColor = true;
			// 
			// firstChart
			// 
			this.firstChart.BackColor = System.Drawing.Color.Lavender;
			this.firstChart.BackImageTransparentColor = System.Drawing.Color.Black;
			chartArea1.AxisX.InterlacedColor = System.Drawing.Color.Transparent;
			chartArea1.AxisX.IsReversed = true;
			chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisY.IsStartedFromZero = false;
			chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisY.ScaleView.Zoomable = false;
			chartArea1.BackColor = System.Drawing.Color.WhiteSmoke;
			chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
			chartArea1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
			chartArea1.BorderColor = System.Drawing.Color.Transparent;
			chartArea1.CursorX.IsUserEnabled = true;
			chartArea1.CursorX.IsUserSelectionEnabled = true;
			chartArea1.Name = "priceChartArea";
			chartArea1.Position.Auto = false;
			chartArea1.Position.Height = 70F;
			chartArea1.Position.Width = 100F;
			chartArea1.Position.Y = 2F;
			chartArea1.ShadowColor = System.Drawing.Color.White;
			chartArea2.AlignWithChartArea = "priceChartArea";
			chartArea2.AxisX.IsReversed = true;
			chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisY.ScaleView.Zoomable = false;
			chartArea2.Name = "volumeChartArea";
			chartArea2.Position.Auto = false;
			chartArea2.Position.Height = 30F;
			chartArea2.Position.Width = 100F;
			chartArea2.Position.Y = 70F;
			this.firstChart.ChartAreas.Add(chartArea1);
			this.firstChart.ChartAreas.Add(chartArea2);
			this.firstChart.Location = new System.Drawing.Point(13, 85);
			this.firstChart.Name = "firstChart";
			series1.ChartArea = "priceChartArea";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
			series1.CustomProperties = "LabelValueType=Open";
			series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			series1.Name = "Series1";
			series1.YValuesPerPoint = 4;
			series2.ChartArea = "volumeChartArea";
			series2.Name = "Series2";
			this.firstChart.Series.Add(series1);
			this.firstChart.Series.Add(series2);
			this.firstChart.Size = new System.Drawing.Size(540, 467);
			this.firstChart.TabIndex = 23;
			this.firstChart.Text = "chart1";
			title1.BackColor = System.Drawing.Color.Transparent;
			title1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
			title1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			title1.ForeColor = System.Drawing.Color.DimGray;
			title1.Name = "chartTitle";
			title1.Position.Auto = false;
			title1.Position.Height = 4F;
			title1.Position.Width = 20F;
			this.firstChart.Titles.Add(title1);
			// 
			// tradeStopButton
			// 
			this.tradeStopButton.BackColor = System.Drawing.SystemColors.Control;
			this.tradeStopButton.Location = new System.Drawing.Point(489, 32);
			this.tradeStopButton.Name = "tradeStopButton";
			this.tradeStopButton.Size = new System.Drawing.Size(64, 46);
			this.tradeStopButton.TabIndex = 24;
			this.tradeStopButton.Text = "매매정지";
			this.tradeStopButton.UseVisualStyleBackColor = false;
			// 
			// tradeStartButton
			// 
			this.tradeStartButton.BackColor = System.Drawing.SystemColors.Control;
			this.tradeStartButton.Enabled = false;
			this.tradeStartButton.Location = new System.Drawing.Point(419, 32);
			this.tradeStartButton.Name = "tradeStartButton";
			this.tradeStartButton.Size = new System.Drawing.Size(64, 46);
			this.tradeStartButton.TabIndex = 25;
			this.tradeStartButton.Text = "매매시작";
			this.tradeStartButton.UseVisualStyleBackColor = false;
			// 
			// lb_book_nowPrice
			// 
			this.lb_book_nowPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lb_book_nowPrice.AutoSize = true;
			this.lb_book_nowPrice.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_book_nowPrice.Location = new System.Drawing.Point(3, 0);
			this.lb_book_nowPrice.Name = "lb_book_nowPrice";
			this.lb_book_nowPrice.Size = new System.Drawing.Size(99, 27);
			this.lb_book_nowPrice.TabIndex = 0;
			this.lb_book_nowPrice.Text = "현재가";
			this.lb_book_nowPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lb_book_전일대비
			// 
			this.lb_book_전일대비.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lb_book_전일대비.AutoSize = true;
			this.lb_book_전일대비.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_book_전일대비.Location = new System.Drawing.Point(108, 0);
			this.lb_book_전일대비.Name = "lb_book_전일대비";
			this.lb_book_전일대비.Size = new System.Drawing.Size(99, 27);
			this.lb_book_전일대비.TabIndex = 1;
			this.lb_book_전일대비.Text = "전일대비";
			this.lb_book_전일대비.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lb_book_등락률
			// 
			this.lb_book_등락률.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lb_book_등락률.AutoSize = true;
			this.lb_book_등락률.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_book_등락률.Location = new System.Drawing.Point(213, 0);
			this.lb_book_등락률.Name = "lb_book_등락률";
			this.lb_book_등락률.Size = new System.Drawing.Size(99, 27);
			this.lb_book_등락률.TabIndex = 2;
			this.lb_book_등락률.Text = "등락률";
			this.lb_book_등락률.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lb_book_volume
			// 
			this.lb_book_volume.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lb_book_volume.AutoSize = true;
			this.lb_book_volume.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_book_volume.Location = new System.Drawing.Point(318, 0);
			this.lb_book_volume.Name = "lb_book_volume";
			this.lb_book_volume.Size = new System.Drawing.Size(99, 27);
			this.lb_book_volume.TabIndex = 3;
			this.lb_book_volume.Text = "거래량";
			this.lb_book_volume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.listView_book_contract);
			this.panel4.Controls.Add(this.listBox_book_quoteDown);
			this.panel4.Controls.Add(this.listBox_book_quoteUp);
			this.panel4.Controls.Add(this.listBox_book_bidAmount);
			this.panel4.Controls.Add(this.listBox_book_itemInfo);
			this.panel4.Controls.Add(this.listBox_book_adkAmount);
			this.panel4.Controls.Add(this.tableLayoutPanel2);
			this.panel4.Location = new System.Drawing.Point(564, 232);
			this.panel4.Margin = new System.Windows.Forms.Padding(0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(420, 317);
			this.panel4.TabIndex = 26;
			// 
			// listView_book_contract
			// 
			this.listView_book_contract.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.listView_book_contract.HideSelection = false;
			this.listView_book_contract.Location = new System.Drawing.Point(0, 164);
			this.listView_book_contract.Margin = new System.Windows.Forms.Padding(0);
			this.listView_book_contract.Name = "listView_book_contract";
			this.listView_book_contract.Size = new System.Drawing.Size(170, 136);
			this.listView_book_contract.TabIndex = 8;
			this.listView_book_contract.UseCompatibleStateImageBehavior = false;
			// 
			// listBox_book_quoteDown
			// 
			this.listBox_book_quoteDown.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.listBox_book_quoteDown.BackColor = System.Drawing.Color.LightPink;
			this.listBox_book_quoteDown.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.listBox_book_quoteDown.FormattingEnabled = true;
			this.listBox_book_quoteDown.ItemHeight = 12;
			this.listBox_book_quoteDown.Location = new System.Drawing.Point(170, 164);
			this.listBox_book_quoteDown.Margin = new System.Windows.Forms.Padding(0);
			this.listBox_book_quoteDown.Name = "listBox_book_quoteDown";
			this.listBox_book_quoteDown.Size = new System.Drawing.Size(80, 136);
			this.listBox_book_quoteDown.TabIndex = 7;
			// 
			// listBox_book_quoteUp
			// 
			this.listBox_book_quoteUp.AllowDrop = true;
			this.listBox_book_quoteUp.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.listBox_book_quoteUp.BackColor = System.Drawing.Color.LightSteelBlue;
			this.listBox_book_quoteUp.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.listBox_book_quoteUp.FormattingEnabled = true;
			this.listBox_book_quoteUp.ItemHeight = 12;
			this.listBox_book_quoteUp.Location = new System.Drawing.Point(170, 28);
			this.listBox_book_quoteUp.Margin = new System.Windows.Forms.Padding(0);
			this.listBox_book_quoteUp.Name = "listBox_book_quoteUp";
			this.listBox_book_quoteUp.Size = new System.Drawing.Size(80, 136);
			this.listBox_book_quoteUp.TabIndex = 6;
			// 
			// listBox_book_bidAmount
			// 
			this.listBox_book_bidAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.listBox_book_bidAmount.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.listBox_book_bidAmount.FormattingEnabled = true;
			this.listBox_book_bidAmount.ItemHeight = 12;
			this.listBox_book_bidAmount.Location = new System.Drawing.Point(250, 164);
			this.listBox_book_bidAmount.Margin = new System.Windows.Forms.Padding(0);
			this.listBox_book_bidAmount.Name = "listBox_book_bidAmount";
			this.listBox_book_bidAmount.Size = new System.Drawing.Size(170, 136);
			this.listBox_book_bidAmount.TabIndex = 5;
			// 
			// listBox_book_itemInfo
			// 
			this.listBox_book_itemInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.listBox_book_itemInfo.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.listBox_book_itemInfo.FormattingEnabled = true;
			this.listBox_book_itemInfo.ItemHeight = 12;
			this.listBox_book_itemInfo.Location = new System.Drawing.Point(250, 28);
			this.listBox_book_itemInfo.Margin = new System.Windows.Forms.Padding(0);
			this.listBox_book_itemInfo.Name = "listBox_book_itemInfo";
			this.listBox_book_itemInfo.Size = new System.Drawing.Size(170, 136);
			this.listBox_book_itemInfo.TabIndex = 4;
			// 
			// listBox_book_adkAmount
			// 
			this.listBox_book_adkAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.listBox_book_adkAmount.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.listBox_book_adkAmount.FormattingEnabled = true;
			this.listBox_book_adkAmount.ItemHeight = 12;
			this.listBox_book_adkAmount.Location = new System.Drawing.Point(0, 28);
			this.listBox_book_adkAmount.Margin = new System.Windows.Forms.Padding(0);
			this.listBox_book_adkAmount.Name = "listBox_book_adkAmount";
			this.listBox_book_adkAmount.Size = new System.Drawing.Size(170, 136);
			this.listBox_book_adkAmount.TabIndex = 2;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.BackColor = System.Drawing.Color.Linen;
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.Controls.Add(this.lb_book_volume, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.lb_book_전일대비, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.lb_book_등락률, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.lb_book_nowPrice, 0, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(420, 27);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel3.BackColor = System.Drawing.Color.OldLace;
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanel3.Controls.Add(this.lb_book_총매도잔량, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.lb_book_총매수잔량, 2, 0);
			this.tableLayoutPanel3.Controls.Add(this.lb_book_총잔량차이, 1, 0);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(564, 531);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(420, 21);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// lb_book_총매도잔량
			// 
			this.lb_book_총매도잔량.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lb_book_총매도잔량.AutoSize = true;
			this.lb_book_총매도잔량.ForeColor = System.Drawing.Color.Blue;
			this.lb_book_총매도잔량.Location = new System.Drawing.Point(100, 4);
			this.lb_book_총매도잔량.Name = "lb_book_총매도잔량";
			this.lb_book_총매도잔량.Size = new System.Drawing.Size(65, 12);
			this.lb_book_총매도잔량.TabIndex = 0;
			this.lb_book_총매도잔량.Text = "총매도잔량";
			// 
			// lb_book_총매수잔량
			// 
			this.lb_book_총매수잔량.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lb_book_총매수잔량.AutoSize = true;
			this.lb_book_총매수잔량.ForeColor = System.Drawing.Color.Red;
			this.lb_book_총매수잔량.Location = new System.Drawing.Point(255, 4);
			this.lb_book_총매수잔량.Name = "lb_book_총매수잔량";
			this.lb_book_총매수잔량.Size = new System.Drawing.Size(65, 12);
			this.lb_book_총매수잔량.TabIndex = 1;
			this.lb_book_총매수잔량.Text = "총매수잔량";
			// 
			// lb_book_총잔량차이
			// 
			this.lb_book_총잔량차이.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lb_book_총잔량차이.AutoSize = true;
			this.lb_book_총잔량차이.Location = new System.Drawing.Point(177, 4);
			this.lb_book_총잔량차이.Margin = new System.Windows.Forms.Padding(0);
			this.lb_book_총잔량차이.Name = "lb_book_총잔량차이";
			this.lb_book_총잔량차이.Size = new System.Drawing.Size(65, 12);
			this.lb_book_총잔량차이.TabIndex = 2;
			this.lb_book_총잔량차이.Text = "총잔량차이";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(1034, 324);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 12);
			this.label5.TabIndex = 27;
			this.label5.Text = "주문시도";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(1036, 349);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 12);
			this.label6.TabIndex = 28;
			this.label6.Text = "주문요청";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(1038, 375);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(53, 12);
			this.label9.TabIndex = 29;
			this.label9.Text = "주문여부";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(1034, 402);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(53, 12);
			this.label10.TabIndex = 30;
			this.label10.Text = "구매여부";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(1038, 431);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(53, 12);
			this.label11.TabIndex = 31;
			this.label11.Text = "후보여부";
			// 
			// lb_주문시도
			// 
			this.lb_주문시도.AutoSize = true;
			this.lb_주문시도.Location = new System.Drawing.Point(1104, 324);
			this.lb_주문시도.Name = "lb_주문시도";
			this.lb_주문시도.Size = new System.Drawing.Size(44, 12);
			this.lb_주문시도.TabIndex = 32;
			this.lb_주문시도.Text = "label12";
			// 
			// lb_주문요청
			// 
			this.lb_주문요청.AutoSize = true;
			this.lb_주문요청.Location = new System.Drawing.Point(1104, 349);
			this.lb_주문요청.Name = "lb_주문요청";
			this.lb_주문요청.Size = new System.Drawing.Size(44, 12);
			this.lb_주문요청.TabIndex = 33;
			this.lb_주문요청.Text = "label13";
			// 
			// lb_주문여부
			// 
			this.lb_주문여부.AutoSize = true;
			this.lb_주문여부.Location = new System.Drawing.Point(1101, 375);
			this.lb_주문여부.Name = "lb_주문여부";
			this.lb_주문여부.Size = new System.Drawing.Size(44, 12);
			this.lb_주문여부.TabIndex = 34;
			this.lb_주문여부.Text = "label14";
			// 
			// lb_구매여부
			// 
			this.lb_구매여부.AutoSize = true;
			this.lb_구매여부.Location = new System.Drawing.Point(1101, 402);
			this.lb_구매여부.Name = "lb_구매여부";
			this.lb_구매여부.Size = new System.Drawing.Size(44, 12);
			this.lb_구매여부.TabIndex = 35;
			this.lb_구매여부.Text = "label15";
			// 
			// lb_후보여부
			// 
			this.lb_후보여부.AutoSize = true;
			this.lb_후보여부.Location = new System.Drawing.Point(1104, 431);
			this.lb_후보여부.Name = "lb_후보여부";
			this.lb_후보여부.Size = new System.Drawing.Size(44, 12);
			this.lb_후보여부.TabIndex = 36;
			this.lb_후보여부.Text = "label16";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage_balance);
			this.tabControl1.Controls.Add(this.tabPage_notContractOrder);
			this.tabControl1.Location = new System.Drawing.Point(560, 85);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(741, 135);
			this.tabControl1.TabIndex = 37;
			// 
			// tabPage_balance
			// 
			this.tabPage_balance.Controls.Add(this.possessionDataGridView);
			this.tabPage_balance.Location = new System.Drawing.Point(4, 22);
			this.tabPage_balance.Name = "tabPage_balance";
			this.tabPage_balance.Size = new System.Drawing.Size(733, 109);
			this.tabPage_balance.TabIndex = 0;
			this.tabPage_balance.Text = "잔고";
			this.tabPage_balance.UseVisualStyleBackColor = true;
			// 
			// tabPage_notContractOrder
			// 
			this.tabPage_notContractOrder.Controls.Add(this.order_GridView);
			this.tabPage_notContractOrder.Location = new System.Drawing.Point(4, 22);
			this.tabPage_notContractOrder.Name = "tabPage_notContractOrder";
			this.tabPage_notContractOrder.Size = new System.Drawing.Size(733, 109);
			this.tabPage_notContractOrder.TabIndex = 1;
			this.tabPage_notContractOrder.Text = "미체결";
			this.tabPage_notContractOrder.UseVisualStyleBackColor = true;
			// 
			// order_GridView
			// 
			this.order_GridView.AllowUserToAddRows = false;
			this.order_GridView.BackgroundColor = System.Drawing.Color.Gainsboro;
			this.order_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.order_GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.on_주문,
            this.on_종목명,
            this.on_구분,
            this.on_주문가,
            this.on_주문량,
            this.on_미체결,
            this.on_즉시취소,
            this.on_주문번호});
			this.order_GridView.Location = new System.Drawing.Point(0, 0);
			this.order_GridView.Margin = new System.Windows.Forms.Padding(0);
			this.order_GridView.Name = "order_GridView";
			this.order_GridView.ReadOnly = true;
			this.order_GridView.RowHeadersVisible = false;
			this.order_GridView.RowTemplate.Height = 23;
			this.order_GridView.Size = new System.Drawing.Size(733, 109);
			this.order_GridView.TabIndex = 0;
			// 
			// colCheck
			// 
			this.colCheck.HeaderText = "";
			this.colCheck.Name = "colCheck";
			this.colCheck.ReadOnly = true;
			this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.colCheck.Width = 50;
			// 
			// on_주문
			// 
			this.on_주문.HeaderText = "주문";
			this.on_주문.Name = "on_주문";
			this.on_주문.ReadOnly = true;
			this.on_주문.Width = 60;
			// 
			// on_종목명
			// 
			this.on_종목명.HeaderText = "종목명";
			this.on_종목명.Name = "on_종목명";
			this.on_종목명.ReadOnly = true;
			// 
			// on_구분
			// 
			this.on_구분.HeaderText = "구분";
			this.on_구분.Name = "on_구분";
			this.on_구분.ReadOnly = true;
			// 
			// on_주문가
			// 
			this.on_주문가.HeaderText = "주문가";
			this.on_주문가.Name = "on_주문가";
			this.on_주문가.ReadOnly = true;
			// 
			// on_주문량
			// 
			this.on_주문량.HeaderText = "주문량";
			this.on_주문량.Name = "on_주문량";
			this.on_주문량.ReadOnly = true;
			// 
			// on_미체결
			// 
			this.on_미체결.HeaderText = "미체결";
			this.on_미체결.Name = "on_미체결";
			this.on_미체결.ReadOnly = true;
			// 
			// on_즉시취소
			// 
			this.on_즉시취소.HeaderText = "즉시취소";
			this.on_즉시취소.Name = "on_즉시취소";
			this.on_즉시취소.ReadOnly = true;
			this.on_즉시취소.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.on_즉시취소.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// on_주문번호
			// 
			this.on_주문번호.HeaderText = "주문번호";
			this.on_주문번호.Name = "on_주문번호";
			this.on_주문번호.ReadOnly = true;
			// 
			// button_conditionSearchStart
			// 
			this.button_conditionSearchStart.BackColor = System.Drawing.Color.YellowGreen;
			this.button_conditionSearchStart.ForeColor = System.Drawing.Color.Maroon;
			this.button_conditionSearchStart.Location = new System.Drawing.Point(338, 32);
			this.button_conditionSearchStart.Name = "button_conditionSearchStart";
			this.button_conditionSearchStart.Size = new System.Drawing.Size(75, 45);
			this.button_conditionSearchStart.TabIndex = 38;
			this.button_conditionSearchStart.Text = "검색시작";
			this.button_conditionSearchStart.UseVisualStyleBackColor = false;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(1040, 447);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(77, 12);
			this.label12.TabIndex = 39;
			this.label12.Text = "트레일링로스";
			// 
			// lb_트레일링로스
			// 
			this.lb_트레일링로스.AutoSize = true;
			this.lb_트레일링로스.Location = new System.Drawing.Point(1124, 447);
			this.lb_트레일링로스.Name = "lb_트레일링로스";
			this.lb_트레일링로스.Size = new System.Drawing.Size(44, 12);
			this.lb_트레일링로스.TabIndex = 40;
			this.lb_트레일링로스.Text = "label13";
			// 
			// button_조회
			// 
			this.button_조회.Location = new System.Drawing.Point(289, 53);
			this.button_조회.Name = "button_조회";
			this.button_조회.Size = new System.Drawing.Size(43, 22);
			this.button_조회.TabIndex = 42;
			this.button_조회.Text = "조회";
			this.button_조회.UseVisualStyleBackColor = true;
			// 
			// textBox_SearchBox
			// 
			this.textBox_SearchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.textBox_SearchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBox_SearchBox.Location = new System.Drawing.Point(161, 53);
			this.textBox_SearchBox.Name = "textBox_SearchBox";
			this.textBox_SearchBox.Size = new System.Drawing.Size(122, 21);
			this.textBox_SearchBox.TabIndex = 43;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1313, 810);
			this.Controls.Add(this.textBox_SearchBox);
			this.Controls.Add(this.button_조회);
			this.Controls.Add(this.lb_트레일링로스);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.button_conditionSearchStart);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.lb_후보여부);
			this.Controls.Add(this.lb_구매여부);
			this.Controls.Add(this.lb_주문여부);
			this.Controls.Add(this.lb_주문요청);
			this.Controls.Add(this.lb_주문시도);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.tableLayoutPanel3);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.tradeStartButton);
			this.Controls.Add(this.tradeStopButton);
			this.Controls.Add(this.firstChart);
			this.Controls.Add(this.Testbutton);
			this.Controls.Add(this.매도구분GroupBox);
			this.Controls.Add(this.매수구분GroupBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.selectedDataGridView);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.accountComboBox);
			this.Controls.Add(this.requestAssetsButton);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.axKHOpenAPI1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "HotTrader";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.possessionDataGridView)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.con1dataGridView)).EndInit();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.con3dataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.con2dataGridView)).EndInit();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.selectedDataGridView)).EndInit();
			this.매수구분GroupBox.ResumeLayout(false);
			this.매도구분GroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.firstChart)).EndInit();
			this.panel4.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage_balance.ResumeLayout(false);
			this.tabPage_notContractOrder.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.order_GridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        public AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI1;
        public System.Windows.Forms.ToolStripMenuItem LoginToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lb_예수금;
        public System.Windows.Forms.Label lb_총매입금;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lb_총평가금;
        public System.Windows.Forms.Label lb_총손익금;
        public System.Windows.Forms.Button requestAssetsButton;
		public System.Windows.Forms.ComboBox accountComboBox;
		public System.Windows.Forms.DataGridView possessionDataGridView;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		public System.Windows.Forms.DataGridView con1dataGridView;
		public System.Windows.Forms.DataGridView con2dataGridView;
		public System.Windows.Forms.DataGridView con3dataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn con2_종목명;
		private System.Windows.Forms.DataGridViewTextBoxColumn con2_등락률;
		private System.Windows.Forms.DataGridViewTextBoxColumn con2_점수;
		private System.Windows.Forms.DataGridViewTextBoxColumn con3_종목명;
		private System.Windows.Forms.DataGridViewTextBoxColumn con3_등락률;
		private System.Windows.Forms.DataGridViewTextBoxColumn con3_점수;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.DataGridView selectedDataGridView;
		private System.Windows.Forms.GroupBox 매수구분GroupBox;
		private System.Windows.Forms.GroupBox 매도구분GroupBox;
		public System.Windows.Forms.ComboBox 매수ComboBox;
		public System.Windows.Forms.ComboBox 매도ComboBox;
		public System.Windows.Forms.ToolStripMenuItem 전략설정ToolStripMenuItem;
		public System.Windows.Forms.ComboBox 매수거래타입ComboBox;
		public System.Windows.Forms.ComboBox 매도거래타입ComboBox;
		public System.Windows.Forms.Button Testbutton;
		public System.Windows.Forms.DataVisualization.Charting.Chart firstChart;
		public System.Windows.Forms.Button tradeStopButton;
		public System.Windows.Forms.Button tradeStartButton;
		public System.Windows.Forms.Label lb_수익률;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridViewTextBoxColumn con1_종목명;
		private System.Windows.Forms.DataGridViewTextBoxColumn con1_등락률;
		private System.Windows.Forms.DataGridViewTextBoxColumn con1_점수;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		public System.Windows.Forms.Label lb_실현손익;
		public System.Windows.Forms.Label lb_실현손익title;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		public System.Windows.Forms.ListBox listBox_book_adkAmount;
		public System.Windows.Forms.ListBox listBox_book_quoteUp;
		public System.Windows.Forms.ListBox listBox_book_bidAmount;
		public System.Windows.Forms.ListBox listBox_book_itemInfo;
		public System.Windows.Forms.ListBox listBox_book_quoteDown;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		public System.Windows.Forms.Label lb_주문시도;
		public System.Windows.Forms.Label lb_주문요청;
		public System.Windows.Forms.Label lb_주문여부;
		public System.Windows.Forms.Label lb_구매여부;
		public System.Windows.Forms.Label lb_후보여부;
		private System.Windows.Forms.DataGridViewTextBoxColumn 종목명;
		private System.Windows.Forms.DataGridViewTextBoxColumn 평가손익;
		private System.Windows.Forms.DataGridViewTextBoxColumn 수익률;
		private System.Windows.Forms.DataGridViewTextBoxColumn 등락률;
		private System.Windows.Forms.DataGridViewButtonColumn 즉시매도;
		private System.Windows.Forms.DataGridViewTextBoxColumn 점수;
		private System.Windows.Forms.DataGridViewTextBoxColumn 보유수량;
		private System.Windows.Forms.DataGridViewTextBoxColumn 매입가;
		private System.Windows.Forms.DataGridViewTextBoxColumn 현재가;
		private System.Windows.Forms.DataGridViewTextBoxColumn 총매입가액;
		private System.Windows.Forms.DataGridViewTextBoxColumn 총평가금액;
		public System.Windows.Forms.ListView listView_book_contract;
		public System.Windows.Forms.Label lb_book_총매도잔량;
		public System.Windows.Forms.Label lb_book_총매수잔량;
		public System.Windows.Forms.Label lb_book_총잔량차이;
		public System.Windows.Forms.Label lb_book_volume;
		public System.Windows.Forms.Label lb_book_등락률;
		public System.Windows.Forms.Label lb_book_전일대비;
		public System.Windows.Forms.Label lb_book_nowPrice;
		private System.Windows.Forms.TabControl tabControl1;
		public System.Windows.Forms.TabPage tabPage_balance;
		public System.Windows.Forms.TabPage tabPage_notContractOrder;
		public System.Windows.Forms.DataGridView order_GridView;
		private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
		private System.Windows.Forms.DataGridViewTextBoxColumn on_주문;
		private System.Windows.Forms.DataGridViewTextBoxColumn on_종목명;
		private System.Windows.Forms.DataGridViewTextBoxColumn on_구분;
		private System.Windows.Forms.DataGridViewTextBoxColumn on_주문가;
		private System.Windows.Forms.DataGridViewTextBoxColumn on_주문량;
		private System.Windows.Forms.DataGridViewTextBoxColumn on_미체결;
		private System.Windows.Forms.DataGridViewButtonColumn on_즉시취소;
		private System.Windows.Forms.DataGridViewTextBoxColumn on_주문번호;
		public System.Windows.Forms.ComboBox comboBox_condition1;
		public System.Windows.Forms.ComboBox comboBox_condition3;
		public System.Windows.Forms.ComboBox comboBox_condition2;
		public System.Windows.Forms.Button button_conditionSearchStart;
		private System.Windows.Forms.Label label12;
		public System.Windows.Forms.Label lb_트레일링로스;
		public System.Windows.Forms.Button button_조회;
		public System.Windows.Forms.TextBox textBox_SearchBox;
		private System.Windows.Forms.DataGridViewTextBoxColumn slt_종목명;
		private System.Windows.Forms.DataGridViewTextBoxColumn slt_현재가;
		private System.Windows.Forms.DataGridViewTextBoxColumn slt_등락률;
		private System.Windows.Forms.DataGridViewTextBoxColumn slt_점수;
		private System.Windows.Forms.DataGridViewButtonColumn slt_즉시매수;
	}
}

