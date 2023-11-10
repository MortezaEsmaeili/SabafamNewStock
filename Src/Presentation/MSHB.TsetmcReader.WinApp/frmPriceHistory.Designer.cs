namespace MSHB.TsetmcReader.WinApp
{
    partial class frmPriceHistory
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dg_InsHistory = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg_InsHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_InsHistory
            // 
            this.dg_InsHistory.AllowUserToAddRows = false;
            this.dg_InsHistory.AllowUserToDeleteRows = false;
            this.dg_InsHistory.AllowUserToOrderColumns = true;
            this.dg_InsHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_InsHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dg_InsHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_InsHistory.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_InsHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_InsHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_InsHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Symbol,
            this.day1,
            this.day2,
            this.day3,
            this.day4,
            this.day5,
            this.day6,
            this.day7});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_InsHistory.DefaultCellStyle = dataGridViewCellStyle9;
            this.dg_InsHistory.Location = new System.Drawing.Point(12, 55);
            this.dg_InsHistory.Name = "dg_InsHistory";
            this.dg_InsHistory.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_InsHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dg_InsHistory.RowHeadersWidth = 51;
            this.dg_InsHistory.RowTemplate.Height = 24;
            this.dg_InsHistory.Size = new System.Drawing.Size(942, 430);
            this.dg_InsHistory.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Below the support price"});
            this.comboBox1.Location = new System.Drawing.Point(331, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(272, 24);
            this.comboBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search Condition: ";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Symbol
            // 
            this.Symbol.DataPropertyName = "Symbol";
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.MinimumWidth = 6;
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            this.Symbol.Width = 80;
            // 
            // day1
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.NullValue = null;
            this.day1.DefaultCellStyle = dataGridViewCellStyle2;
            this.day1.HeaderText = "Yesterday";
            this.day1.MinimumWidth = 6;
            this.day1.Name = "day1";
            this.day1.ReadOnly = true;
            this.day1.Width = 96;
            // 
            // day2
            // 
            this.day2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.day2.DataPropertyName = "towdaysago";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day2.DefaultCellStyle = dataGridViewCellStyle3;
            this.day2.HeaderText = "II days ago";
            this.day2.MinimumWidth = 6;
            this.day2.Name = "day2";
            this.day2.ReadOnly = true;
            this.day2.Width = 103;
            // 
            // day3
            // 
            this.day3.DataPropertyName = "Threedaysago";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day3.DefaultCellStyle = dataGridViewCellStyle4;
            this.day3.HeaderText = "III days ago";
            this.day3.MinimumWidth = 6;
            this.day3.Name = "day3";
            this.day3.ReadOnly = true;
            this.day3.Width = 108;
            // 
            // day4
            // 
            this.day4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.day4.DataPropertyName = "fourdaysago";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day4.DefaultCellStyle = dataGridViewCellStyle5;
            this.day4.HeaderText = "IV days ago";
            this.day4.MinimumWidth = 6;
            this.day4.Name = "day4";
            this.day4.ReadOnly = true;
            this.day4.Width = 109;
            // 
            // day5
            // 
            this.day5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.day5.DataPropertyName = "fivedaysago";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day5.DefaultCellStyle = dataGridViewCellStyle6;
            this.day5.HeaderText = "V days ago";
            this.day5.MinimumWidth = 6;
            this.day5.Name = "day5";
            this.day5.ReadOnly = true;
            this.day5.Width = 104;
            // 
            // day6
            // 
            this.day6.DataPropertyName = "sixdaysago";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day6.DefaultCellStyle = dataGridViewCellStyle7;
            this.day6.HeaderText = "VI days ago";
            this.day6.MinimumWidth = 6;
            this.day6.Name = "day6";
            this.day6.ReadOnly = true;
            this.day6.Width = 109;
            // 
            // day7
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day7.DefaultCellStyle = dataGridViewCellStyle8;
            this.day7.HeaderText = "VII days ago";
            this.day7.MinimumWidth = 6;
            this.day7.Name = "day7";
            this.day7.ReadOnly = true;
            this.day7.Width = 114;
            // 
            // frmPriceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 497);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dg_InsHistory);
            this.Name = "frmPriceHistory";
            this.Text = "frmPriceHistory";
            this.Load += new System.EventHandler(this.frmPriceHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_InsHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_InsHistory;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn day1;
        private System.Windows.Forms.DataGridViewTextBoxColumn day2;
        private System.Windows.Forms.DataGridViewTextBoxColumn day3;
        private System.Windows.Forms.DataGridViewTextBoxColumn day4;
        private System.Windows.Forms.DataGridViewTextBoxColumn day5;
        private System.Windows.Forms.DataGridViewTextBoxColumn day6;
        private System.Windows.Forms.DataGridViewTextBoxColumn day7;
    }
}