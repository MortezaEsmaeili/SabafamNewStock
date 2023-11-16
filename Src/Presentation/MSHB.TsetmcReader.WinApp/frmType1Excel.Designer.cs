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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openExcelFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dg_InsData = new System.Windows.Forms.DataGridView();
            this.InsCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price100 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PE100 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Earning100 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price500 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PE500 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Earning500 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Freez_CHB = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.LocateExcelFile_BT = new System.Windows.Forms.Button();
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
            this.Price100,
            this.PE100,
            this.Earning100,
            this.Price500,
            this.PE500,
            this.Earning500});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_InsData.DefaultCellStyle = dataGridViewCellStyle17;
            this.dg_InsData.Location = new System.Drawing.Point(1, 60);
            this.dg_InsData.Name = "dg_InsData";
            this.dg_InsData.ReadOnly = true;
            this.dg_InsData.RowHeadersWidth = 51;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dg_InsData.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dg_InsData.RowTemplate.Height = 24;
            this.dg_InsData.Size = new System.Drawing.Size(1098, 364);
            this.dg_InsData.TabIndex = 3;
            // 
            // InsCode
            // 
            this.InsCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.InsCode.DataPropertyName = "InsCode";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsCode.DefaultCellStyle = dataGridViewCellStyle10;
            this.InsCode.HeaderText = "InsCode";
            this.InsCode.MinimumWidth = 100;
            this.InsCode.Name = "InsCode";
            this.InsCode.ReadOnly = true;
            this.InsCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Price100
            // 
            this.Price100.DataPropertyName = "Price100";
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price100.DefaultCellStyle = dataGridViewCellStyle11;
            this.Price100.HeaderText = "Price100";
            this.Price100.MinimumWidth = 6;
            this.Price100.Name = "Price100";
            this.Price100.ReadOnly = true;
            this.Price100.Width = 88;
            // 
            // PE100
            // 
            this.PE100.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PE100.DataPropertyName = "PE100";
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PE100.DefaultCellStyle = dataGridViewCellStyle12;
            this.PE100.HeaderText = "PE100";
            this.PE100.MinimumWidth = 6;
            this.PE100.Name = "PE100";
            this.PE100.ReadOnly = true;
            this.PE100.Width = 75;
            // 
            // Earning100
            // 
            this.Earning100.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Earning100.DataPropertyName = "Earning100";
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Earning100.DefaultCellStyle = dataGridViewCellStyle13;
            this.Earning100.HeaderText = "Earning100";
            this.Earning100.MinimumWidth = 6;
            this.Earning100.Name = "Earning100";
            this.Earning100.ReadOnly = true;
            this.Earning100.Width = 103;
            // 
            // Price500
            // 
            this.Price500.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Price500.DataPropertyName = "Price500";
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price500.DefaultCellStyle = dataGridViewCellStyle14;
            this.Price500.HeaderText = "Price500";
            this.Price500.MinimumWidth = 6;
            this.Price500.Name = "Price500";
            this.Price500.ReadOnly = true;
            this.Price500.Width = 88;
            // 
            // PE500
            // 
            this.PE500.DataPropertyName = "PE500";
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PE500.DefaultCellStyle = dataGridViewCellStyle15;
            this.PE500.HeaderText = "PE500";
            this.PE500.MinimumWidth = 6;
            this.PE500.Name = "PE500";
            this.PE500.ReadOnly = true;
            this.PE500.Width = 75;
            // 
            // Earning500
            // 
            this.Earning500.DataPropertyName = "Earning500";
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Earning500.DefaultCellStyle = dataGridViewCellStyle16;
            this.Earning500.HeaderText = "Earning500";
            this.Earning500.MinimumWidth = 6;
            this.Earning500.Name = "Earning500";
            this.Earning500.ReadOnly = true;
            this.Earning500.Width = 103;
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
            // LocateExcelFile_BT
            // 
            this.LocateExcelFile_BT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LocateExcelFile_BT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.LocateExcelFile_BT.Location = new System.Drawing.Point(948, 17);
            this.LocateExcelFile_BT.Name = "LocateExcelFile_BT";
            this.LocateExcelFile_BT.Size = new System.Drawing.Size(132, 32);
            this.LocateExcelFile_BT.TabIndex = 6;
            this.LocateExcelFile_BT.Text = "Locate Excel Files";
            this.LocateExcelFile_BT.UseVisualStyleBackColor = false;
            this.LocateExcelFile_BT.Click += new System.EventHandler(this.LocateExcelFile_BT_Click);
            // 
            // frmType1Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1111, 436);
            this.Controls.Add(this.LocateExcelFile_BT);
            this.Controls.Add(this.Freez_CHB);
            this.Controls.Add(this.dg_InsData);
            this.Name = "frmType1Excel";
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
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price100;
        private System.Windows.Forms.DataGridViewTextBoxColumn PE100;
        private System.Windows.Forms.DataGridViewTextBoxColumn Earning100;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price500;
        private System.Windows.Forms.DataGridViewTextBoxColumn PE500;
        private System.Windows.Forms.DataGridViewTextBoxColumn Earning500;
        private System.Windows.Forms.Button LocateExcelFile_BT;
    }
}