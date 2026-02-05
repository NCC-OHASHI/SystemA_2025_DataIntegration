using Management.Common; // これを追加
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
    public partial class Transmission : Form
    {
        public Transmission()
        {
            InitializeComponent();
        }

        private void Transmission_Load(object sender, EventArgs e)
        {
            // 初期表示を設定
            InitializeInput();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // 初期表示の状態に戻す
            InitializeInput();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 画面を閉じる
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // 分類にチェックが１つでも入っているか
                if (!chkTypeSend.Checked && !chkTypeRecv.Checked)
                {
                    MessageBox.Show("分類は少なくとも1つ選択してください。", "入力チェックエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ステータスにチェックが１つでも入っているか
                if (!chkStatusDone.Checked && !chkStatusRetry.Checked && !chkStatusError.Checked)
                {
                    MessageBox.Show("ステータスは少なくとも1つ選択してください。", "入力チェックエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 期間の整合性チェック（開始 > 終了 になっていないか）
                if (dtpDateFrom.Value.Date > dtpDateTo.Value.Date)
                {
                    MessageBox.Show("期間の開始年月は終了年月以前を設定してください。", "入力チェックエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 検索処理の実行
                DBUtil db = new DBUtil();

                // 分類のリスト作成
                List<int> categories = new List<int>();
                if (chkTypeSend.Checked) categories.Add(0); // 送信
                if (chkTypeRecv.Checked) categories.Add(1); // 受信

                // ステータスのリスト作成
                List<int> statuses = new List<int>();
                if (chkStatusDone.Checked) statuses.Add(0); // 済み
                if (chkStatusRetry.Checked) statuses.Add(1); // 再送待ち
                if (chkStatusError.Checked) statuses.Add(2); // 異常

                // データベースからデータを取得
                DataTable dt = db.GetTransmissionLogs(
                    dtpDateFrom.Value,
                    dtpDateTo.Value,
                    categories,
                    statuses
                );

                // 表（DataGridView）に表示
                dgvTransmission.AutoGenerateColumns = false; // 勝手に列を増やさない
                dgvTransmission.DataSource = dt;


                // 検索成功後に更新ボタンを有効化する
                btnRefresh.Enabled = true;
            }
            catch (Exception ex)
            {
                // エラーメッセージを表示
                MessageBox.Show("データの取得中にエラーが発生しました。\n" + ex.Message, "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // エラーログを記録
                Log.WriteLog(ex.ToString());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // 検索ボタン押下のイベント処理を呼び出す
            btnSearch_Click(sender, e);

            // 更新完了メッセージ
            MessageBox.Show("最新の送受信ログを取得しました。", "更新完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InitializeInput()
        {
            // 期間を現在年月に設定
            DateTime currentData = DateTime.Now;
            dtpDateFrom.Value = currentData;
            dtpDateTo.Value = currentData;

            // 分類チェックボックスを全てオンにする
            chkTypeSend.Checked = true;
            chkTypeRecv.Checked = true;

            // ステータスチェックボックスを全てオンにする
            chkStatusDone.Checked = true;
            chkStatusRetry.Checked = true;
            chkStatusError.Checked = true;

            // もし前回の検索結果が残っていたら消す
            dgvTransmission.DataSource = null;
        }

    }
}
