using System;
using System.IO;
using System.Text;

namespace Management.Common
{
    /// <summary>
    /// エラーログ出力クラス（資料 Page 20の仕様に基づく）
    /// </summary>
    public static class Log
    {
        // ログを出力するフォルダ
        private const string LogFolder = @"D:\SystemA\log";

        public static void WriteLog(string errorMessage)
        {
            try
            {
                // 1. フォルダが存在しない場合は作成する
                if (!Directory.Exists(LogFolder))
                {
                    Directory.CreateDirectory(LogFolder);
                }

                // 2. ファイル名を作成（例：err_20260205.log）
                string fileName = $"err_{DateTime.Now:yyyyMMdd}.log";
                string filePath = Path.Combine(LogFolder, fileName);

                // 3. ログの行を作成（資料の仕様：日時[タブ]内容）
                // 日時フォーマット：yyyyMMdd_HHmmss_fff
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");

                // メッセージ内の改行をスペースに変換して、1行に収まるようにする（TSV形式を保つため）
                string cleanMessage = errorMessage.Replace(Environment.NewLine, " ");

                string logLine = $"{timestamp}\t{cleanMessage}";

                // 4. ファイルに追記（UTF-8形式）
                File.AppendAllText(filePath, logLine + Environment.NewLine, Encoding.UTF8);
            }
            catch
            {
                // ログ出力自体に失敗した場合は、アプリを止めないために何もしない
            }
        }
    }
}