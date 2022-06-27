
namespace ATK_01
{
	partial class SetupStrategyForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.총예수금label = new System.Windows.Forms.Label();
			this.예수금TextBox = new System.Windows.Forms.TextBox();
			this.SubmitStrategyButton = new System.Windows.Forms.Button();
			this.최대매수종목수Label = new System.Windows.Forms.Label();
			this.최대매수종목수numericUpDown = new System.Windows.Forms.NumericUpDown();
			this.종목당금액Label = new System.Windows.Forms.Label();
			this.종목당금액numericUpDown = new System.Windows.Forms.NumericUpDown();
			this.초당증가점수Label = new System.Windows.Forms.Label();
			this.초당증가점수numericUpDown = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.최대매수종목수numericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.종목당금액numericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.초당증가점수numericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// 총예수금label
			// 
			this.총예수금label.AutoSize = true;
			this.총예수금label.Location = new System.Drawing.Point(14, 16);
			this.총예수금label.Name = "총예수금label";
			this.총예수금label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.총예수금label.Size = new System.Drawing.Size(41, 12);
			this.총예수금label.TabIndex = 0;
			this.총예수금label.Text = "예수금";
			// 
			// 예수금TextBox
			// 
			this.예수금TextBox.Location = new System.Drawing.Point(140, 13);
			this.예수금TextBox.Name = "예수금TextBox";
			this.예수금TextBox.Size = new System.Drawing.Size(100, 21);
			this.예수금TextBox.TabIndex = 1;
			// 
			// SubmitStrategyButton
			// 
			this.SubmitStrategyButton.Location = new System.Drawing.Point(351, 404);
			this.SubmitStrategyButton.Name = "SubmitStrategyButton";
			this.SubmitStrategyButton.Size = new System.Drawing.Size(94, 34);
			this.SubmitStrategyButton.TabIndex = 2;
			this.SubmitStrategyButton.Text = "전략설정";
			this.SubmitStrategyButton.UseVisualStyleBackColor = false;
			// 
			// 최대매수종목수Label
			// 
			this.최대매수종목수Label.AutoSize = true;
			this.최대매수종목수Label.Location = new System.Drawing.Point(12, 46);
			this.최대매수종목수Label.Name = "최대매수종목수Label";
			this.최대매수종목수Label.Size = new System.Drawing.Size(89, 12);
			this.최대매수종목수Label.TabIndex = 3;
			this.최대매수종목수Label.Text = "최대매수종목수";
			// 
			// 최대매수종목수numericUpDown
			// 
			this.최대매수종목수numericUpDown.Location = new System.Drawing.Point(140, 44);
			this.최대매수종목수numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.최대매수종목수numericUpDown.Name = "최대매수종목수numericUpDown";
			this.최대매수종목수numericUpDown.Size = new System.Drawing.Size(100, 21);
			this.최대매수종목수numericUpDown.TabIndex = 4;
			this.최대매수종목수numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// 종목당금액Label
			// 
			this.종목당금액Label.AutoSize = true;
			this.종목당금액Label.Location = new System.Drawing.Point(13, 78);
			this.종목당금액Label.Name = "종목당금액Label";
			this.종목당금액Label.Size = new System.Drawing.Size(65, 12);
			this.종목당금액Label.TabIndex = 5;
			this.종목당금액Label.Text = "종목당금액";
			// 
			// 종목당금액numericUpDown
			// 
			this.종목당금액numericUpDown.Location = new System.Drawing.Point(140, 78);
			this.종목당금액numericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
			this.종목당금액numericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.종목당금액numericUpDown.Name = "종목당금액numericUpDown";
			this.종목당금액numericUpDown.Size = new System.Drawing.Size(100, 21);
			this.종목당금액numericUpDown.TabIndex = 6;
			this.종목당금액numericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// 초당증가점수Label
			// 
			this.초당증가점수Label.AutoSize = true;
			this.초당증가점수Label.Location = new System.Drawing.Point(406, 21);
			this.초당증가점수Label.Name = "초당증가점수Label";
			this.초당증가점수Label.Size = new System.Drawing.Size(77, 12);
			this.초당증가점수Label.TabIndex = 7;
			this.초당증가점수Label.Text = "초당증가점수";
			// 
			// 초당증가점수numericUpDown
			// 
			this.초당증가점수numericUpDown.Location = new System.Drawing.Point(513, 19);
			this.초당증가점수numericUpDown.Name = "초당증가점수numericUpDown";
			this.초당증가점수numericUpDown.Size = new System.Drawing.Size(120, 21);
			this.초당증가점수numericUpDown.TabIndex = 8;
			// 
			// SetupStrategyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.초당증가점수numericUpDown);
			this.Controls.Add(this.초당증가점수Label);
			this.Controls.Add(this.종목당금액numericUpDown);
			this.Controls.Add(this.종목당금액Label);
			this.Controls.Add(this.최대매수종목수numericUpDown);
			this.Controls.Add(this.최대매수종목수Label);
			this.Controls.Add(this.SubmitStrategyButton);
			this.Controls.Add(this.예수금TextBox);
			this.Controls.Add(this.총예수금label);
			this.Name = "SetupStrategyForm";
			this.Text = "전략설정";
			((System.ComponentModel.ISupportInitialize)(this.최대매수종목수numericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.종목당금액numericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.초당증가점수numericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label 총예수금label;
		public System.Windows.Forms.TextBox 예수금TextBox;
		public System.Windows.Forms.Button SubmitStrategyButton;
		private System.Windows.Forms.Label 최대매수종목수Label;
		private System.Windows.Forms.NumericUpDown 최대매수종목수numericUpDown;
		private System.Windows.Forms.Label 종목당금액Label;
		private System.Windows.Forms.Label 초당증가점수Label;
		private System.Windows.Forms.NumericUpDown 초당증가점수numericUpDown;
		public System.Windows.Forms.NumericUpDown 종목당금액numericUpDown;
	}
}