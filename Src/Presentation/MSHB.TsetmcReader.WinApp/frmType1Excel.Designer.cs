namespace MSHB.TsetmcReader.WinApp
{
    partial class frmType1Excel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openExcelFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dg_InsData = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Freez_CHB = new System.Windows.Forms.CheckBox();
            this.InsCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Target1PricePercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Target2PricePercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Target3PricePercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceSupportPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetPrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetPrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetPrice3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupportPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg_InsData)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_InsData
            // 
            this.dg_InsData.AllowUserToAddRows = false;
            this.dg_InsData.AllowUserToDeleteRows = false;
            this.dg_InsData.AllowUserToOrderColumns = true;
            this.dg_InsData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_InsData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dg_InsData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_InsData.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dg_InsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_InsData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InsCode,
            this.Name,
            this.Target1PricePercentage,
            this.Target2PricePercentage,
            this.Target3PricePercentage,
            this.PriceSupportPercentage,
            this.CurrentPrice,
            this.TargetPrice1,
            this.TargetPrice2,
            this.TargetPrice3,
            this.SupportPrice});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_InsData.DefaultCellStyle = dataGridViewCellStyle11;
            this.dg_InsData.Location = new System.Drawing.Point(1, 60);
            this.dg_InsData.Name = "dg_InsData";
            this.dg_InsData.ReadOnly = true;
            this.dg_InsData.RowHeadersWidth = 51;
            this.dg_InsData.RowTemplate.Height = 24;
            this.dg_InsData.Size = new System.Drawing.Size(1098, 364);
            this.dg_InsData.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Freez_CHB
            // 
            this.Freez_CHB.AutoSize = true;
            this.Freez_CHB.Location = new System.Drawing.Point(26, 24);
            this.Freez_CHB.Name = "Freez_CHB";
            this.Freez_CHB.Size = new System.Drawing.Size(71, 20);
            this.Freez_CHB.TabIndex = 5;
            this.Freez_CHB.Text = "Freeze";
            this.Freez_CHB.UseVisualStyleBackColor = true;
            this.Freez_CHB.CheckedChanged += new System.EventHandler(this.Freez_CHB_CheckedChanged);
            // 
            // InsCode
            // 
            this.InsCode.DataPropertyName = "InsCode";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.InsCode.HeaderText = "InsCode";
            this.InsCode.MinimumWidth = 6;
            this.InsCode.Name = "InsCode";
            this.InsCode.ReadOnly = true;
            this.InsCode.Width = 86;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Symbol";
            this.Name.HeaderText = "Name";
            this.Name.MinimumWidth = 6;
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 73;
            // 
            // Target1PricePercentage
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.NullValue = null;
            this.Target1PricePercentage.DefaultCellStyle = dataGridViewCellStyle2;
            this.Target1PricePercentage.HeaderText = "T1<->P %";
            this.Target1PricePercentage.MinimumWidth = 6;
            this.Target1PricePercentage.Name = "Target1PricePercentage";
            this.Target1PricePercentage.ReadOnly = true;
            this.Target1PricePercentage.Width = 94;
            // 
            // Target2PricePercentage
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.NullValue = null;
            this.Target2PricePercentage.DefaultCellStyle = dataGridViewCellStyle3;
            this.Target2PricePercentage.HeaderText = "T2<->P %";
            this.Target2PricePercentage.MinimumWidth = 6;
            this.Target2PricePercentage.Name = "Target2PricePercentage";
            this.Target2PricePercentage.ReadOnly = true;
            this.Target2PricePercentage.Width = 94;
            // 
            // Target3PricePercentage
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Target3PricePercentage.DefaultCellStyle = dataGridViewCellStyle4;
            this.Target3PricePercentage.HeaderText = "T3<->P %";
            this.Target3PricePercentage.MinimumWidth = 6;
            this.Target3PricePercentage.Name = "Target3PricePercentage";
            this.Target3PricePercentage.ReadOnly = true;
            this.Target3PricePercentage.Width = 94;
            // 
            // PriceSupportPercentage
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceSupportPercentage.DefaultCellStyle = dataGridViewCellStyle5;
            this.PriceSupportPercentage.HeaderText = "P<->SP %";
            this.PriceSupportPercentage.MinimumWidth = 6;
            this.PriceSupportPercentage.Name = "PriceSupportPercentage";
            this.PriceSupportPercentage.ReadOnly = true;
            this.PriceSupportPercentage.Width = 96;
            // 
            // CurrentPrice
            // 
            this.CurrentPrice.DataPropertyName = "CurrentPrice";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.CurrentPrice.HeaderText = "Current Price";
            this.CurrentPrice.MinimumWidth = 6;
            this.CurrentPrice.Name = "CurrentPrice";
            this.CurrentPrice.ReadOnly = true;
            this.CurrentPrice.Width = 112;
            // 
            // TargetPrice1
            // 
            this.TargetPrice1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TargetPrice1.DataPropertyName = "TargetPrice1";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetPrice1.DefaultCellStyle = dataGridViewCellStyle7;
            this.TargetPrice1.HeaderText = "Target Price 1";
            this.TargetPrice1.MinimumWidth = 6;
            this.TargetPrice1.Name = "TargetPrice1";
            this.TargetPrice1.ReadOnly = true;
            this.TargetPrice1.Width = 120;
            // 
            // TargetPrice2
            // 
            this.TargetPrice2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TargetPrice2.DataPropertyName = "TargetPrice2";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetPrice2.DefaultCellStyle = dataGridViewCellStyle8;
            this.TargetPrice2.HeaderText = "Target Price 2";
            this.TargetPrice2.MinimumWidth = 6;
            this.TargetPrice2.Name = "TargetPrice2";
            this.TargetPrice2.ReadOnly = true;
            this.TargetPrice2.Width = 120;
            // 
            // TargetPrice3
            // 
            this.TargetPrice3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TargetPrice3.DataPropertyName = "TargetPrice3";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetPrice3.DefaultCellStyle = dataGridViewCellStyle9;
            this.TargetPrice3.HeaderText = "Target Price 3";
            this.TargetPrice3.MinimumWidth = 6;
            this.TargetPrice3.Name = "TargetPrice3";
            this.TargetPrice3.ReadOnly = true;
            this.TargetPrice3.Width = 120;
            // 
            // SupportPrice
            // 
            this.SupportPrice.DataPropertyName = "SupportPrice";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupportPrice.DefaultCellStyle = dataGridViewCellStyle10;
            this.SupportPrice.HeaderText = "Support Price";
            this.SupportPrice.MinimumWidth = 6;
            this.SupportPrice.Name = "SupportPrice";
            this.SupportPrice.ReadOnly = true;
            this.SupportPrice.Width = 117;
            // 
            // frmType1Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1111, 436);
            this.Controls.Add(this.Freez_CHB);
            this.Controls.Add(this.dg_InsData);

            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel Type 1";
            this.Load += new System.EventHandler(this.frmType1Excel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_InsData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openExcelFileDialog;
        private System.Windows.Forms.DataGridView dg_InsData;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.CheckBox Freez_CHB;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Target1PricePercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Target2PricePercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Target3PricePercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceSupportPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetPrice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetPrice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetPrice3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupportPrice;
    }
}