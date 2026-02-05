using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Management.Common;
using System.IO;

namespace Management
{
    public partial class SalesData : Form
    {
        public SalesData()
        {
            InitializeComponent();
        }
        private void SalesData_Load(object sender, EventArgs e)
        {
            //初期表示を設定
            InitializeInput();
        }

        private void txtItemNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 半角数値以外の入力は不可
            // バックスペースは許可
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                // 数字でもバックスペースでもない場合は入力を無効化
                e.Handled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // 分類にチェックが１つでも入っているか
                if (!chkFood.Checked && !chkMachine.Checked && !chkLife.Checked && !chkOther.Checked)
                {
                    MessageBox.Show("商品分類は1つ以上選択してください。", "入力チェックエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 期間の整合性チェック（開始 > 終了 になっていないか）
                if (dtpDateFrom.Value.Date > dtpDateTo.Value.Date)
                {
                    MessageBox.Show("期間の開始年月は終了年月以前を設定してください。", "入力チェックエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // 検索処理の呼び出し
                SearchSalesData();


                // 検索が成功したら、他のボタンを有効化する
                btnSend.Enabled = true;
                btnRefresh.Enabled = true;

            }
            catch (Exception ex)
            {
                // エラーメッセージを表示
                MessageBox.Show("検索処理中に予期せぬエラーが発生しました。\n" + ex.Message, "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // エラーログを記録
                Log.WriteLog(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // 初期表示の状態に戻す
            InitializeInput();

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // 画面から送信対象の期間（年月）を取得する
            string startMonth = dtpDateFrom.Value.ToString("yyyyMM");
            string endMonth = dtpDateTo.Value.ToString("yyyyMM");

            // 2. ユーザーに確認メッセージを出す（商品分類や商品名は送信の条件に含まれないことを伝える）
            string msg = $"{startMonth} ～ {endMonth} の売上データを送信しますか？\n" +
                         "（注意：商品分類や商品名の検索条件は反映されず、期間内の全データが送信されます）";

            DialogResult result = MessageBox.Show(msg, "送信確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 「いいえ」が押されたら中止
            if (result != DialogResult.Yes) return;

            try
            {
                // 実行プログラムがある場所の「Batch.exe」を取得する
                string batchPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Batch.exe");

                if (!System.IO.File.Exists(batchPath))
                {
                    MessageBox.Show("Batch.exe が見つかりません。パスを確認してください。", "エラー");
                    return;
                }

                // パラメータを設定して起動（[処理区分] [開始年月] [終了年月]）
                var startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = batchPath,
                    Arguments = $"1 {startMonth} {endMonth}", // 1 は「店舗売上データ送信」
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                // バッチを実行し、終わるまで待つ
                using (var process = System.Diagnostics.Process.Start(startInfo))
                {
                    process.WaitForExit();

                    // 終了コード（リターンコード）で成功・失敗を判定
                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show("売上データの送信が正常に終了しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 送信が成功したら、画面を初期状態に戻す
                        InitializeInput();
                    }
                    else
                    {
                        MessageBox.Show("送信処理でエラーが発生しました。ログを確認してください。", "異常終了", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // バッチが異常終了したことをログに記録する
                        Log.WriteLog($"Batch.exeが異常終了しました。リターンコード: {process.ExitCode} (期間: {startMonth}-{endMonth})");
                    }
                }
            }
            catch (Exception ex)
            {
                // エラーメッセージを表示
                MessageBox.Show("バッチ処理の起動中にエラーが発生しました。\n" + ex.Message, "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // エラーログを記録
                Log.WriteLog(ex.ToString());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // 検索ボタン押下のイベント処理を呼び出す
            btnSearch_Click(sender, e);

            // 更新完了メッセージ
            MessageBox.Show("最新の検索結果を取得しました。", "更新完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 画面を閉じる
            this.Close();
        }
        private void SearchSalesData()
        {
            // デザイナで設定した列以外、勝手に作らないようにする
            dgvSales.AutoGenerateColumns = false;


            // DBUtilの準備
            DBUtil db = new DBUtil();

            // 画面でチェックされている分類（コード）をリストにする
            List<string> selectedCategories = new List<string>();
            if (chkFood.Checked) selectedCategories.Add("001");    // 食料品
            if (chkMachine.Checked) selectedCategories.Add("002"); // 機器
            if (chkLife.Checked) selectedCategories.Add("003");    // 生活用品
            if (chkOther.Checked) selectedCategories.Add("004");   // その他

            // データベースからデータを取ってくる
            DataTable dt = db.GetSalesData(
                dtpDateFrom.Value,
                dtpDateTo.Value,
                selectedCategories,
                txtItemNo.Text,
                txtItemName.Text
            );

            // 画面の表（DataGridView）にデータを入れる
            dgvSales.DataSource = dt;
        }

        private void InitializeInput()
        {
            // 期間を現在年月に戻す
            DateTime currentData = DateTime.Now;
            dtpDateFrom.Value = currentData;
            dtpDateTo.Value = currentData;

            // 分類チェックボックスを全てオンにする
            chkFood.Checked = true;
            chkMachine.Checked = true;
            chkLife.Checked = true;
            chkOther.Checked = true;

            // テキストボックスを空にする
            txtItemNo.Text = "";
            txtItemName.Text = "";

            // 検索結果（表）を空にする
            dgvSales.DataSource = null;

            // 検索後に有効化したボタンを、再度無効化する
            btnSend.Enabled = false;
            btnRefresh.Enabled = false;

            // 最初の入力欄にカーソルを戻す
            dtpDateFrom.Focus();

        }
    }
}