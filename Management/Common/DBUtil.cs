using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Management.Common
{
    public class DBUtil
    {
        private string ConnectionString;
        private string DBSchema;

        public DBUtil()
        {
            // App.configを読み込む
            string server = ConfigurationManager.AppSettings["DB_SERVER"];
            string db = ConfigurationManager.AppSettings["DB_NAME"];
            string user = ConfigurationManager.AppSettings["DB_USER"];
            string pass = ConfigurationManager.AppSettings["DB_PASS"];
            DBSchema = ConfigurationManager.AppSettings["DB_SCHEMA"];

            // データベースに接続する
            ConnectionString = $"Data Source={server};Initial Catalog={db};User ID={user};Password={pass};Encrypt=True;TrustServerCertificate=True;";
        }

        /// <summary>
        /// 売上データを検索して、表形式（DataTable）で返す
        /// </summary>
        public DataTable GetSalesData(DateTime start, DateTime end, List<string> categories, string itemNo, string itemName)
        {
            DataTable dt = new DataTable();

            using (var conn = new SqlConnection(ConnectionString))
            {
                // テーブルからデータを取得する
                string sql = $@"
                    SELECT 
                        s.sale_date AS '販売日時',
                        CASE p.category_id 
                            WHEN '001' THEN N'食料品' 
                            WHEN '002' THEN N'機器' 
                            WHEN '003' THEN N'生活用品' 
                            WHEN '004' THEN N'その他' 
                            ELSE p.category_id 
                        END AS '分類',
                        p.item_no AS '商品番号',
                        pn.item_name AS '商品名',
                        s.quantity AS '売上数量',
                        s.discount AS '割引適用額',
                        (p.sale_unit * s.quantity - s.discount) AS '売上額'
                    FROM {DBSchema}.sales s
                    INNER JOIN {DBSchema}.product_master p ON s.item_code = p.item_code
                    INNER JOIN {DBSchema}.product_name pn ON s.item_code = pn.item_code
                    WHERE s.sale_date >= @start AND s.sale_date < @end";

                // チェックボックスで選んだ分類だけを絞り込む
                if (categories.Count > 0)
                {
                    string catIn = string.Join(",", categories.Select((c, i) => $"@cat{i}"));
                    sql += $" AND p.category_id IN ({catIn})";
                }

                // 商品番号絞り込み
                if (!string.IsNullOrEmpty(itemNo)) sql += " AND p.item_no = @itemNo";

                // 商品名絞り込み
                if (!string.IsNullOrEmpty(itemName)) sql += " AND pn.item_name LIKE @itemName";

                var cmd = new SqlCommand(sql, conn);

                // 検索期間の設定（開始月の1日から、終了月の翌月1日未満まで）
                cmd.Parameters.AddWithValue("@start", new DateTime(start.Year, start.Month, 1));
                cmd.Parameters.AddWithValue("@end", new DateTime(end.Year, end.Month, 1).AddMonths(1));

                // 分類のパラメータ設定
                for (int i = 0; i < categories.Count; i++) cmd.Parameters.AddWithValue($"@cat{i}", categories[i]);

                if (!string.IsNullOrEmpty(itemNo)) cmd.Parameters.AddWithValue("@itemNo", itemNo);
                if (!string.IsNullOrEmpty(itemName)) cmd.Parameters.AddWithValue("@itemName", "%" + itemName + "%");

                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt); // 取得したデータをテーブルに入れる
            }
            return dt;
        }

        /// <summary>
        /// 送受信ログを検索して、表形式（DataTable）で返す
        /// </summary>
        public DataTable GetTransmissionLogs(DateTime start, DateTime end, List<int> categories, List<int> statuses)
        {
            DataTable dt = new DataTable();

            using (var conn = new SqlConnection(ConnectionString))
            {
                // transmissionテーブルからデータを取得、加工
                string sql = $@"
                    SELECT 
                        processed_at AS N'処理日時',
                        CASE category WHEN 0 THEN N'送信' ELSE N'受信' END AS N'分類',
                        file_name AS N'ファイル名',
                        CASE status 
                            WHEN 0 THEN N'送信済み' 
                            WHEN 1 THEN N'再送待ち' 
                            ELSE N'異常' 
                        END AS N'ステータス',
                        output_message AS N'出力メッセージ'
                    FROM {DBSchema}.transmission
                    WHERE processed_at >= @start AND processed_at < @end";

                // 分類チェックボックスの絞り込み
                if (categories.Count > 0)
                {
                    sql += $" AND category IN ({string.Join(",", categories)})";
                }

                // ステータスチェックボックスの絞り込み
                if (statuses.Count > 0)
                {
                    sql += $" AND status IN ({string.Join(",", statuses)})";
                }

                // 最後に日時の降順（最新が一番上）で並べ替える
                sql += " ORDER BY processed_at DESC";

                var cmd = new SqlCommand(sql, conn);

                // 検索期間の設定（開始月の1日から、終了月の翌月1日未満まで）
                cmd.Parameters.AddWithValue("@start", new DateTime(start.Year, start.Month, 1));
                cmd.Parameters.AddWithValue("@end", new DateTime(end.Year, end.Month, 1).AddMonths(1));

                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }


    }
}
