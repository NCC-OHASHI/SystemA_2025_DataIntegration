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
            // App.configに書いた設定を読み込みます
            string server = ConfigurationManager.AppSettings["DB_SERVER"];
            string db = ConfigurationManager.AppSettings["DB_NAME"];
            string user = ConfigurationManager.AppSettings["DB_USER"];
            string pass = ConfigurationManager.AppSettings["DB_PASS"];
            DBSchema = ConfigurationManager.AppSettings["DB_SCHEMA"];

            // データベースに接続するための「合言葉」を作ります
            ConnectionString = $"Data Source={server};Initial Catalog={db};User ID={user};Password={pass};Encrypt=True;TrustServerCertificate=True;";
        }

        /// <summary>
        /// 売上データを検索して、表形式（DataTable）で返します
        /// </summary>
        public DataTable GetSalesData(DateTime start, DateTime end, List<string> categories, string itemNo, string itemName)
        {
            DataTable dt = new DataTable();

            using (var conn = new SqlConnection(ConnectionString))
            {
                // 資料Page 3, 15に基づき、売上(sales)・商品マスタ(product_master)・商品名(product_name)を結合します
                // UIで「商品名」を表示する必要があるため、3つのテーブルを合体させてデータを取ります
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

                // チェックボックスで選んだ分類だけを絞り込む条件を追加
                if (categories.Count > 0)
                {
                    string catIn = string.Join(",", categories.Select((c, i) => $"@cat{i}"));
                    sql += $" AND p.category_id IN ({catIn})";
                }

                // 商品番号が入力されていたら絞り込む
                if (!string.IsNullOrEmpty(itemNo)) sql += " AND p.item_no = @itemNo";

                // 商品名が入力されていたら「あいまい検索」をする
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
                adapter.Fill(dt); // 結果を表(dt)に流し込む
            }
            return dt;
        }

        /// <summary>
        /// 送受信ログを検索して、表形式（DataTable）で返します
        /// </summary>
        public DataTable GetTransmissionLogs(DateTime start, DateTime end, List<int> categories, List<int> statuses)
        {
            DataTable dt = new DataTable();

            using (var conn = new SqlConnection(ConnectionString))
            {
                // 1. SQLの基本形（資料 Page 1に基づき、transmissionテーブルから取得）
                // ユーザーにわかりやすいように CASE文で「送信/受信」や「送信済み/異常」などの名前に変換します
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

                // 2. 分類チェックボックスの絞り込み（送信：0, 受信：1）
                if (categories.Count > 0)
                {
                    sql += $" AND category IN ({string.Join(",", categories)})";
                }

                // 3. ステータスチェックボックスの絞り込み（済み：0, 再送待ち：1, 異常：2）
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
