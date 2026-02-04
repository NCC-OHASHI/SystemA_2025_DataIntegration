namespace Management
{
    partial class Transmission
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
            label6 = new Label();
            btnClose = new Button();
            btnRefresh = new Button();
            dgvTransmission = new DataGridView();
            btnClear = new Button();
            btnSearch = new Button();
            groupBox1 = new GroupBox();
            chkStatusError = new CheckBox();
            label5 = new Label();
            chkStatusRetry = new CheckBox();
            chkStatusDone = new CheckBox();
            chkTypeRecv = new CheckBox();
            chkTypeSend = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            dtpDateTo = new DateTimePicker();
            dtpDateFrom = new DateTimePicker();
            label1 = new Label();
            label4 = new Label();
            colProcDate = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colFileName = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colMessage = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvTransmission).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.Font = new Font("Yu Gothic UI", 17F);
            label6.Location = new Point(7, -39);
            label6.Name = "label6";
            label6.Size = new Size(111, 37);
            label6.TabIndex = 15;
            label6.Text = "売上管理";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Yu Gothic UI", 12F);
            btnClose.Location = new Point(667, 475);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(130, 58);
            btnClose.TabIndex = 14;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Enabled = false;
            btnRefresh.Font = new Font("Yu Gothic UI", 12F);
            btnRefresh.Location = new Point(531, 475);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(130, 58);
            btnRefresh.TabIndex = 13;
            btnRefresh.Text = "更新";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvTransmission
            // 
            dgvTransmission.AllowUserToAddRows = false;
            dgvTransmission.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransmission.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransmission.Columns.AddRange(new DataGridViewColumn[] { colProcDate, colType, colFileName, colStatus, colMessage });
            dgvTransmission.Location = new Point(20, 251);
            dgvTransmission.Name = "dgvTransmission";
            dgvTransmission.Size = new Size(777, 218);
            dgvTransmission.TabIndex = 11;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Yu Gothic UI", 12F);
            btnClear.Location = new Point(667, 187);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(130, 58);
            btnClear.TabIndex = 10;
            btnClear.Text = "条件クリア";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Yu Gothic UI", 12F);
            btnSearch.Location = new Point(531, 187);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(130, 58);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkStatusError);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(chkStatusRetry);
            groupBox1.Controls.Add(chkStatusDone);
            groupBox1.Controls.Add(chkTypeRecv);
            groupBox1.Controls.Add(chkTypeSend);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtpDateTo);
            groupBox1.Controls.Add(dtpDateFrom);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(20, 58);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(489, 187);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "検索条件";
            // 
            // chkStatusError
            // 
            chkStatusError.AutoSize = true;
            chkStatusError.Checked = true;
            chkStatusError.CheckState = CheckState.Checked;
            chkStatusError.Location = new Point(306, 129);
            chkStatusError.Name = "chkStatusError";
            chkStatusError.Size = new Size(50, 19);
            chkStatusError.TabIndex = 16;
            chkStatusError.Text = "異常";
            chkStatusError.UseVisualStyleBackColor = true;
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
            // chkStatusRetry
            // 
            chkStatusRetry.AutoSize = true;
            chkStatusRetry.Checked = true;
            chkStatusRetry.CheckState = CheckState.Checked;
            chkStatusRetry.Location = new Point(208, 129);
            chkStatusRetry.Name = "chkStatusRetry";
            chkStatusRetry.Size = new Size(71, 19);
            chkStatusRetry.TabIndex = 12;
            chkStatusRetry.Text = "再送待ち";
            chkStatusRetry.UseVisualStyleBackColor = true;
            // 
            // chkStatusDone
            // 
            chkStatusDone.AutoSize = true;
            chkStatusDone.Checked = true;
            chkStatusDone.CheckState = CheckState.Checked;
            chkStatusDone.Location = new Point(123, 129);
            chkStatusDone.Name = "chkStatusDone";
            chkStatusDone.Size = new Size(73, 19);
            chkStatusDone.TabIndex = 11;
            chkStatusDone.Text = "送信済み";
            chkStatusDone.UseVisualStyleBackColor = true;
            // 
            // chkTypeRecv
            // 
            chkTypeRecv.AutoSize = true;
            chkTypeRecv.Checked = true;
            chkTypeRecv.CheckState = CheckState.Checked;
            chkTypeRecv.Location = new Point(207, 77);
            chkTypeRecv.Name = "chkTypeRecv";
            chkTypeRecv.Size = new Size(50, 19);
            chkTypeRecv.TabIndex = 10;
            chkTypeRecv.Text = "受信";
            chkTypeRecv.UseVisualStyleBackColor = true;
            // 
            // chkTypeSend
            // 
            chkTypeSend.AutoSize = true;
            chkTypeSend.Checked = true;
            chkTypeSend.CheckState = CheckState.Checked;
            chkTypeSend.Location = new Point(123, 77);
            chkTypeSend.Name = "chkTypeSend";
            chkTypeSend.Size = new Size(50, 19);
            chkTypeSend.TabIndex = 9;
            chkTypeSend.Text = "送信";
            chkTypeSend.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.BackColor = SystemColors.ActiveBorder;
            label3.Font = new Font("Yu Gothic UI", 10F);
            label3.Location = new Point(6, 129);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 7;
            label3.Text = "ステータス";
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ActiveBorder;
            label2.Font = new Font("Yu Gothic UI", 10F);
            label2.Location = new Point(6, 76);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 6;
            label2.Text = "分類";
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
            // label4
            // 
            label4.Font = new Font("Yu Gothic UI", 17F);
            label4.Location = new Point(20, 9);
            label4.Name = "label4";
            label4.Size = new Size(140, 37);
            label4.TabIndex = 16;
            label4.Text = "送受信管理";
            // 
            // colProcDate
            // 
            colProcDate.DataPropertyName = "処理日時";
            colProcDate.HeaderText = "処理日時";
            colProcDate.Name = "colProcDate";
            // 
            // colType
            // 
            colType.DataPropertyName = "分類";
            colType.HeaderText = "分類";
            colType.Name = "colType";
            // 
            // colFileName
            // 
            colFileName.DataPropertyName = "ファイル名";
            colFileName.HeaderText = "ファイル名";
            colFileName.Name = "colFileName";
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "ステータス";
            colStatus.HeaderText = "ステータス";
            colStatus.Name = "colStatus";
            // 
            // colMessage
            // 
            colMessage.DataPropertyName = "出力メッセージ";
            colMessage.HeaderText = "出力メッセージ";
            colMessage.Name = "colMessage";
            // 
            // Transmission
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 552);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(btnClose);
            Controls.Add(btnRefresh);
            Controls.Add(dgvTransmission);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Transmission";
            Text = "送受信管理";
            Load += Transmission_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTransmission).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label6;
        private Button btnClose;
        private Button btnRefresh;
        private DataGridView dgvTransmission;
        private Button btnClear;
        private Button btnSearch;
        private GroupBox groupBox1;
        private CheckBox chkStatusError;
        private Label label5;
        private CheckBox chkStatusRetry;
        private CheckBox chkStatusDone;
        private CheckBox chkTypeRecv;
        private CheckBox chkTypeSend;
        private Label label3;
        private Label label2;
        private DateTimePicker dtpDateTo;
        private DateTimePicker dtpDateFrom;
        private Label label1;
        private Label label4;
        private DataGridViewTextBoxColumn colProcDate;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colFileName;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colMessage;
    }
}