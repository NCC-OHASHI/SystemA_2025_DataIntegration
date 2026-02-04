using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Management.Common; // これを追加

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
            // 仕様：初期表示時は現在日時から年月を取得して開始終了に設定
            DateTime currentData = DateTime.Now;

            // DateTimePickerに現在日時をセット
            dtpDateFrom.Value = currentData;
            dtpDateTo.Value = currentData;

            // カスタムフォーマットの適用（プロパティ設定済みなら不要ですが念のため）
            // Formatプロパティはデザイナで設定済み前提
        }

        private void txtItemNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 仕様：半角数値以外の入力は不可
            // バックスペース(文字コード8)は許可する
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
                // 1. 入力チェック（Chapter 05 Page 15の要件）
                // 少なくとも1つは分類が選ばれているか
                if (!chkFood.Checked && !chkMachine.Checked && !chkLife.Checked && !chkOther.Checked)
                {
                    MessageBox.Show("商品分類は1つ以上選択してください。", "入力チェックエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 期間の妥当性チェック（開始 > 終了 になっていないか）
                // ※仕様にはありませんが、業務システムとして一般的に必要なチェックです
                if (dtpDateFrom.Value.Date > dtpDateTo.Value.Date)
                {
                    MessageBox.Show("期間の開始年月は終了年月以前を設定してください。", "入力チェックエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // 2. 検索処理の呼び出し
                SearchSalesData();


                // 3. 検索が成功したら、他のボタンを押せるようにする（資料 Page 16の要件）
                btnSend.Enabled = true;
                btnRefresh.Enabled = true;

            }
            catch (Exception ex)
            {
                // 仕様：例外エラー発生時はエラーメッセージを表示し、エラーログを記録する
                MessageBox.Show("検索処理中に予期せぬエラーが発生しました。\n" + ex.Message, "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 2. 【追加】ファイルにエラーの詳細を記録（資料 Page 20の要件）
                Log.WriteLog(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // 1. 期間を現在年月に戻す（資料 Page 15：初期表示時は現在日時）
            DateTime currentData = DateTime.Now;
            dtpDateFrom.Value = currentData;
            dtpDateTo.Value = currentData;

            // 2. チェックボックスを全て「チェックあり」に戻す（資料 Page 15：全項目にチェック）
            chkFood.Checked = true;
            chkMachine.Checked = true;
            chkLife.Checked = true;
            chkOther.Checked = true;

            // 3. テキストボックスを空にする
            txtItemNo.Text = "";
            txtItemName.Text = "";

            // 4. 【追加】検索結果（表）もクリアする
            // 表に表示する「元データ」を空っぽにします
            dgvSales.DataSource = null;

            // 5. 【追加】検索後に有効化したボタンを、再度無効化する（初期状態に戻す）
            btnSend.Enabled = false;
            btnRefresh.Enabled = false;

            // （おまけ）最初の入力欄にカーソルを戻して、すぐに入力できるようにする
            dtpDateFrom.Focus();

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // 1. 画面から送信対象の期間（年月）を取得する
            string startMonth = dtpDateFrom.Value.ToString("yyyyMM");
            string endMonth = dtpDateTo.Value.ToString("yyyyMM");

            // 2. ユーザーに確認メッセージを出す（資料 Page 16の要件）
            // ※商品分類や商品名は送信の条件に含まれないことを伝える
            string msg = $"{startMonth} ～ {endMonth} の売上データを送信しますか？\n" +
                         "（注意：商品分類や商品名の検索条件は反映されず、期間内の全データが送信されます）";

            DialogResult result = MessageBox.Show(msg, "送信確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 「いいえ」が押されたら中止
            if (result != DialogResult.Yes) return;

            try
            {
                // 3. Batch.exe を起動するための準備
                // 資料 Page 7 に基づき、binフォルダ内の Batch.exe を指定します
                string batchPath = @"D:\SystemA\bin\Batch.exe";

                // もし自分のPCにまだそのフォルダがない場合は、
                // いったんデバッグ用のパスにするか、フォルダを作成してBatch.exeをコピーしてください。
                if (!System.IO.File.Exists(batchPath))
                {
                    MessageBox.Show("Batch.exe が見つかりません。パスを確認してください。", "エラー");
                    return;
                }

                // 4. パラメータを設定して起動（資料 Page 10：[処理区分] [開始年月] [終了年月]）
                var startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = batchPath,
                    Arguments = $"1 {startMonth} {endMonth}", // 1 は「店舗売上データ送信」
                    UseShellExecute = false,
                    CreateNoWindow = true // 黒い画面を出さない設定
                };

                // 5. バッチを実行し、終わるまで待つ
                using (var process = System.Diagnostics.Process.Start(startInfo))
                {
                    process.WaitForExit();

                    // 6. 終了コード（リターンコード）で成功・失敗を判定（資料 Page 10）
                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show("売上データの送信が正常に終了しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 【追加】送信が成功したので、画面を初期状態に戻す
                        btnClear_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("送信処理でエラーが発生しました。ログを確認してください。", "異常終了", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // ★【追加】バッチが異常終了したことをログに記録する
                        // 自分で分かりやすいメッセージを作って渡します
                        Log.WriteLog($"Batch.exeが異常終了しました。リターンコード: {process.ExitCode} (期間: {startMonth}-{endMonth})");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("バッチ処理の起動中にエラーが発生しました。\n" + ex.Message, "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 2. 【追加】ファイルにエラーの詳細を記録（資料 Page 20の要件）
                Log.WriteLog(ex.ToString());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // 仕様：検索ボタン押下のイベント処理を呼び出す
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
            // 追加：デザイナで設定した列以外、勝手に作らないようにする
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
            // 引数：開始月, 終了月, 分類リスト, 商品番号, 商品名
            DataTable dt = db.GetSalesData(
                dtpDateFrom.Value,
                dtpDateTo.Value,
                selectedCategories,
                txtItemNo.Text,
                txtItemName.Text
            );

            // 画面の表（DataGridView）にデータを流し込む
            // ※DataGridViewの名前が「dgvSales」だとして書いています。ご自身の名前に合わせてください。
            dgvSales.DataSource = dt;
        }
    }
}