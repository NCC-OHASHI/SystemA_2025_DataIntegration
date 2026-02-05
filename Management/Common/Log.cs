using System;
using System.IO;
using System.Text;

namespace Management.Common
{
    /// <summary>
    /// エラーログ出力クラス
    /// </summary>
    public static class Log
    {
        // ログを出力するフォルダ
        private const string LogFolder = @"D:\SystemA\log";

        public static void WriteLog(string errorMessage)
        {
            try
            {
                // フォルダが存在しない場合は作成する
                if (!Directory.Exists(LogFolder))
                {
                    Directory.CreateDirectory(LogFolder);
                }

                // ファイル名を作成
                string fileName = $"err_{DateTime.Now:yyyyMMdd}.log";
                string filePath = Path.Combine(LogFolder, fileName);

                // ログの行を作成（資料の仕様：日時[タブ]内容）
                // 日時フォーマット：yyyyMMdd_HHmmss_fff
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");

                // メッセージ内の改行をスペースに変換して、1行に収まるようにする
                string cleanMessage = errorMessage.Replace(Environment.NewLine, " ");

                string logLine = $"{timestamp}\t{cleanMessage}";

                // ファイルに追記（UTF-8形式）
                File.AppendAllText(filePath, logLine + Environment.NewLine, Encoding.UTF8);
            }
            catch
            {
                // ログの書き込みに失敗したら何もしない
            }
        }
    }
}