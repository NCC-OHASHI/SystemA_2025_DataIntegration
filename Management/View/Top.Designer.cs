namespace Management
{
    partial class Top
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
            topTitle = new Label();
            btnSales = new Button();
            btnTransmission = new Button();
            SuspendLayout();
            // 
            // topTitle
            // 
            topTitle.Font = new Font("Yu Gothic UI", 20F);
            topTitle.Location = new Point(167, 60);
            topTitle.Name = "topTitle";
            topTitle.Size = new Size(297, 46);
            topTitle.TabIndex = 0;
            topTitle.Text = "売上管理システム";
            // 
            // btnSales
            // 
            btnSales.Font = new Font("Yu Gothic UI", 15F);
            btnSales.Location = new Point(28, 150);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(219, 70);
            btnSales.TabIndex = 1;
            btnSales.Text = "売上管理";
            btnSales.UseVisualStyleBackColor = true;
            btnSales.Click += btnSales_Click;
            // 
            // btnTransmission
            // 
            btnTransmission.Font = new Font("Yu Gothic UI", 15F);
            btnTransmission.Location = new Point(300, 150);
            btnTransmission.Name = "btnTransmission";
            btnTransmission.Size = new Size(219, 70);
            btnTransmission.TabIndex = 2;
            btnTransmission.Text = "送受信管理";
            btnTransmission.UseVisualStyleBackColor = true;
            btnTransmission.Click += btnTransmission_Click;
            // 
            // Top
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 334);
            Controls.Add(btnTransmission);
            Controls.Add(btnSales);
            Controls.Add(topTitle);
            Font = new Font("Yu Gothic UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Top";
            Text = "トップ画面";
            ResumeLayout(false);
        }

        #endregion

        private Label topTitle;
        private Button btnSales;
        private Button btnTransmission;
    }
}