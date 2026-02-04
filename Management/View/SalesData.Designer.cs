namespace Management
{
    partial class SalesData
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
            groupBox1 = new GroupBox();
            label5 = new Label();
            txtItemName = new TextBox();
            txtItemNo = new TextBox();
            chkOther = new CheckBox();
            chkLife = new CheckBox();
            chkMachine = new CheckBox();
            chkFood = new CheckBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dtpDateTo = new DateTimePicker();
            dtpDateFrom = new DateTimePicker();
            label1 = new Label();
            printDialog1 = new PrintDialog();
            btnSearch = new Button();
            btnClear = new Button();
            dgvSales = new DataGridView();
            btnSend = new Button();
            btnRefresh = new Button();
            btnClose = new Button();
            label6 = new Label();
            colSalesDate = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colItemNo = new DataGridViewTextBoxColumn();
            colItemName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colDiscount = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtItemName);
            groupBox1.Controls.Add(txtItemNo);
            groupBox1.Controls.Add(chkOther);
            groupBox1.Controls.Add(chkLife);
            groupBox1.Controls.Add(chkMachine);
            groupBox1.Controls.Add(chkFood);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtpDateTo);
            groupBox1.Controls.Add(dtpDateFrom);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(18, 53);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(489, 187);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "検索条件";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(260, 32);
            label5.Name = "label5";
            label5.Size = new Size(19, 15);
            label5.TabIndex = 15;
            label5.Text = "～";
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(112, 140);
            txtItemName.MaxLength = 30;
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(297, 23);
            txtItemName.TabIndex = 14;
            // 
            // txtItemNo
            // 
            txtItemNo.ImeMode = ImeMode.Disable;
            txtItemNo.Location = new Point(112, 103);
            txtItemNo.MaxLength = 5;
            txtItemNo.Name = "txtItemNo";
            txtItemNo.Size = new Size(297, 23);
            txtItemNo.TabIndex = 13;
            txtItemNo.KeyPress += txtItemNo_KeyPress;
            // 
            // chkOther
            // 
            chkOther.AutoSize = true;
            chkOther.Checked = true;
            chkOther.CheckState = CheckState.Checked;
            chkOther.Location = new Point(385, 65);
            chkOther.Name = "chkOther";
            chkOther.Size = new Size(81, 19);
            chkOther.TabIndex = 12;
            chkOther.Text = "その他用品";
            chkOther.UseVisualStyleBackColor = true;
            // 
            // chkLife
            // 
            chkLife.AutoSize = true;
            chkLife.Checked = true;
            chkLife.CheckState = CheckState.Checked;
            chkLife.Location = new Point(285, 65);
            chkLife.Name = "chkLife";
            chkLife.Size = new Size(74, 19);
            chkLife.TabIndex = 11;
            chkLife.Text = "生活用品";
            chkLife.UseVisualStyleBackColor = true;
            // 
            // chkMachine
            // 
            chkMachine.AutoSize = true;
            chkMachine.Checked = true;
            chkMachine.CheckState = CheckState.Checked;
            chkMachine.Location = new Point(207, 65);
            chkMachine.Name = "chkMachine";
            chkMachine.Size = new Size(50, 19);
            chkMachine.TabIndex = 10;
            chkMachine.Text = "機器";
            chkMachine.UseVisualStyleBackColor = true;
            // 
            // chkFood
            // 
            chkFood.AutoSize = true;
            chkFood.Checked = true;
            chkFood.CheckState = CheckState.Checked;
            chkFood.Location = new Point(123, 65);
            chkFood.Name = "chkFood";
            chkFood.Size = new Size(62, 19);
            chkFood.TabIndex = 9;
            chkFood.Text = "食料品";
            chkFood.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.BackColor = SystemColors.ActiveBorder;
            label4.Font = new Font("Yu Gothic UI", 10F);
            label4.Location = new Point(6, 141);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 8;
            label4.Text = "商品名";
            // 
            // label3
            // 
            label3.BackColor = SystemColors.ActiveBorder;
            label3.Font = new Font("Yu Gothic UI", 10F);
            label3.Location = new Point(6, 103);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 7;
            label3.Text = "商品番号";
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ActiveBorder;
            label2.Font = new Font("Yu Gothic UI", 10F);
            label2.Location = new Point(6, 64);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 6;
            label2.Text = "商品分類";
            // 
            // dtpDateTo
            // 
            dtpDateTo.CustomFormat = "yyyy/MM";
            dtpDateTo.Format = DateTimePickerFormat.Custom;
            dtpDateTo.Location = new Point(285, 26);
            dtpDateTo.Name = "dtpDateTo";
            dtpDateTo.ShowUpDown = true;
            dtpDateTo.Size = new Size(124, 23);
            dtpDateTo.TabIndex = 5;
            // 
            // dtpDateFrom
            // 
            dtpDateFrom.CustomFormat = "yyyy/MM";
            dtpDateFrom.Format = DateTimePickerFormat.Custom;
            dtpDateFrom.Location = new Point(123, 26);
            dtpDateFrom.Name = "dtpDateFrom";
            dtpDateFrom.ShowUpDown = true;
            dtpDateFrom.Size = new Size(124, 23);
            dtpDateFrom.TabIndex = 4;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveBorder;
            label1.Font = new Font("Yu Gothic UI", 10F);
            label1.Location = new Point(6, 26);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            label1.Text = "期間";
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Yu Gothic UI", 12F);
            btnSearch.Location = new Point(529, 182);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(130, 58);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Yu Gothic UI", 12F);
            btnClear.Location = new Point(665, 182);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(130, 58);
            btnClear.TabIndex = 2;
            btnClear.Text = "条件クリア";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dgvSales
            // 
            dgvSales.AllowUserToAddRows = false;
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSales.Columns.AddRange(new DataGridViewColumn[] { colSalesDate, colCategory, colItemNo, colItemName, colQuantity, colDiscount, colAmount });
            dgvSales.Location = new Point(18, 246);
            dgvSales.Name = "dgvSales";
            dgvSales.Size = new Size(777, 317);
            dgvSales.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.Enabled = false;
            btnSend.Font = new Font("Yu Gothic UI", 12F);
            btnSend.Location = new Point(18, 571);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(130, 58);
            btnSend.TabIndex = 4;
            btnSend.Text = "売上データ送信";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Enabled = false;
            btnRefresh.Font = new Font("Yu Gothic UI", 12F);
            btnRefresh.Location = new Point(529, 571);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(130, 58);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "更新";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Yu Gothic UI", 12F);
            btnClose.Location = new Point(665, 571);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(130, 58);
            btnClose.TabIndex = 6;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label6
            // 
            label6.Font = new Font("Yu Gothic UI", 17F);
            label6.Location = new Point(18, 9);
            label6.Name = "label6";
            label6.Size = new Size(111, 37);
            label6.TabIndex = 7;
            label6.Text = "売上管理";
            // 
            // colSalesDate
            // 
            colSalesDate.DataPropertyName = "販売日時";
            colSalesDate.HeaderText = "販売日時";
            colSalesDate.Name = "colSalesDate";
            // 
            // colCategory
            // 
            colCategory.DataPropertyName = "分類";
            colCategory.HeaderText = "分類";
            colCategory.Name = "colCategory";
            // 
            // colItemNo
            // 
            colItemNo.DataPropertyName = "商品番号";
            colItemNo.HeaderText = "商品番号";
            colItemNo.Name = "colItemNo";
            // 
            // colItemName
            // 
            colItemName.DataPropertyName = "商品名";
            colItemName.HeaderText = "商品名";
            colItemName.Name = "colItemName";
            // 
            // colQuantity
            // 
            colQuantity.DataPropertyName = "売上数量";
            colQuantity.HeaderText = "売上数量";
            colQuantity.Name = "colQuantity";
            // 
            // colDiscount
            // 
            colDiscount.DataPropertyName = "割引適用額";
            colDiscount.HeaderText = "割引適用額";
            colDiscount.Name = "colDiscount";
            // 
            // colAmount
            // 
            colAmount.DataPropertyName = "売上額";
            colAmount.HeaderText = "売上額";
            colAmount.Name = "colAmount";
            // 
            // SalesData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 637);
            Controls.Add(label6);
            Controls.Add(btnClose);
            Controls.Add(btnRefresh);
            Controls.Add(btnSend);
            Controls.Add(dgvSales);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "SalesData";
            Text = "売上管理";
            Load += SalesData_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker dtpDateTo;
        private DateTimePicker dtpDateFrom;
        private Label label1;
        private Label label5;
        private TextBox txtItemName;
        private TextBox txtItemNo;
        private CheckBox chkOther;
        private CheckBox chkLife;
        private CheckBox chkMachine;
        private CheckBox chkFood;
        private Label label4;
        private Label label3;
        private Label label2;
        private PrintDialog printDialog1;
        private Button btnSearch;
        private Button btnClear;
        private DataGridView dgvSales;
        private Button btnSend;
        private Button btnRefresh;
        private Button btnClose;
        private Label label6;
        private DataGridViewTextBoxColumn colSalesDate;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colItemNo;
        private DataGridViewTextBoxColumn colItemName;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colDiscount;
        private DataGridViewTextBoxColumn colAmount;
    }
}