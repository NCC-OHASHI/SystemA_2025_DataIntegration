using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management
{
    public partial class Top : Form
    {
        public Top()
        {
            InitializeComponent();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            // 売上管理画面を表示する
            SalesData salesForm = new SalesData();
            salesForm.Show();
        }

        private void btnTransmission_Click(object sender, EventArgs e)
        {
            // 送受信管理画面を表示する
            Transmission transForm = new Transmission();
            transForm.Show();
        }
    }
}
