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
            // 仕様：初期表示時は現在日時から年月を取得して開始終了に設定
            InitializeInput();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // 仕様：検索条件の内容を初期表示の状態にする
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
                // 1. 入力チェック（資料 Page 18）

                // 分類が少なくとも1つ選ばれているか
                if (!chkTypeSend.Checked && !chkTypeRecv.Checked)
                {
                    MessageBox.Show("分類は少なくとも1つ選択してください。", "入力チェックエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ステータスが少なくとも1つ選ばれているか
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

                // 2. 検索処理の実行
                SearchTransmissionData();

                // 3. 検索成功後に更新ボタンを有効化する
                btnRefresh.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("データの取得中にエラーが発生しました。\n" + ex.Message, "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 【エラーログこの1行を追加！】
                Log.WriteLog(ex.ToString());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // 仕様：検索ボタン押下のイベント処理を呼び出す
            btnSearch_Click(sender, e);

            // 更新完了メッセージ
            MessageBox.Show("最新の送受信ログを取得しました。", "更新完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InitializeInput()
        {
            // 1. 期間を現在年月に設定（資料 Page 18）
            DateTime currentData = DateTime.Now;
            dtpDateFrom.Value = currentData;
            dtpDateTo.Value = currentData;

            // 2. 分類チェックボックスを全てオンにする
            chkTypeSend.Checked = true;
            chkTypeRecv.Checked = true;

            // 3. ステータスチェックボックスを全てオンにする
            chkStatusDone.Checked = true;
            chkStatusRetry.Checked = true;
            chkStatusError.Checked = true;

            // ※もし前回の検索結果が残っていたら消す
            dgvTransmission.DataSource = null;
        }

        private void SearchTransmissionData()
        {
            DBUtil db = new DBUtil();

            // 分類のリスト作成 (送信=0, 受信=1)
            List<int> categories = new List<int>();
            if (chkTypeSend.Checked) categories.Add(0);
            if (chkTypeRecv.Checked) categories.Add(1);

            // ステータスのリスト作成 (済み=0, 再送待ち=1, 異常=2)
            List<int> statuses = new List<int>();
            if (chkStatusDone.Checked) statuses.Add(0);
            if (chkStatusRetry.Checked) statuses.Add(1);
            if (chkStatusError.Checked) statuses.Add(2);

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
        }

    }
}
