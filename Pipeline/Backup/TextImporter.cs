using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace Sample.Pipeline
{
    /// <summary>
    /// UTF-8ファイルフォーマットのテキストファイルを読み込むインポーター
    /// </summary>

    // インポータークラスには、ContentImporterAttributeを指定する
    [ContentImporter(".txt", DisplayName="UTF-8 テキストファイルインポーター")]
    public class TextImporter : ContentImporter<string[]>
    {
        /// <summary>
        /// データをファイルから既定のタイプにインポートする。
        /// </summary>
        /// <param name="filename">インポートするファイル名</param>
        /// <param name="context">コンテントインポーターのコンテキスト、ログやファイルの依存関係を指定できる。</param>
        /// <returns></returns>
        public override string[] Import(string filename, ContentImporterContext context)
        {
            // LogWarningまたはLogImportantMessageを使うと、ビルドメッセージウィンドウに
            // メッセージを表示できる。
            context.Logger.LogImportantMessage("ファイル読み込み開始 {0}", filename);
            // テキストファイルを読み込んでstring[]形式にする。
            List<string> text = new List<string>();
            using (StreamReader sr = File.OpenText(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    text.Add(line);
                }
            }

            return text.ToArray();
        }
    }
}
