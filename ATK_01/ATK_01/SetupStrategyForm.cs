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
	public partial class SetupStrategyForm : Form
	{
		public SetupStrategyForm()
		{
			InitializeComponent();

			InitForm();
			SubmitStrategyButton.Click += SubmitStrategy;
		}

		private void InitForm()
		{
			예수금TextBox.Text = Config.TOTAL_DEPOSIT.ToString();
			최대매수종목수numericUpDown.Value = Config.ORDER_COUNT_MAX;
			종목당금액numericUpDown.Value = Config.BUY_AMOUNT_ONCE;
			초당증가점수numericUpDown.Value = Config.IN_ITEM_SECOND_ADD_POINT;
			
		}

		private void SubmitStrategy(object sender, EventArgs e)
		{
			Config.ORDER_COUNT_MAX = Decimal.ToInt32(최대매수종목수numericUpDown.Value);
			Config.BUY_AMOUNT_ONCE = Decimal.ToInt32(종목당금액numericUpDown.Value);
			Config.IN_ITEM_SECOND_ADD_POINT = Decimal.ToInt32(초당증가점수numericUpDown.Value);

			this.Close();
		}
	}
}
