using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

// MessageContent.TestWriteメソッドに必要な名前空間
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace Rpg.Pipeline
{
    /// <summary>
    /// XMLメッセージ記述クラス。使うフォントとメッセージファイルを指定する。
    /// </summary>
    public class XmlMessageDescription
    {
        /// <summary>
        /// SpriteFontファイルへの外部参照
        /// </summary>
        public ExternalReference<FontDescription> FontDescription;

        /// <summary>
        /// XMLファイルの外部参照
        /// </summary>
        public ExternalReference<Dictionary<string, string>> Messages;

        /// <summary>
        /// メッセージをXmlMessageContentに格納するかの指定フラグ。
        /// これはテキストファイルがソースコード自体や、リソースファイル
        /// だった時などにメッセージデータが重複するのを防ぐため。
        /// </summary>
        public bool DiscardMessage;

        /// <summary>
        /// XMLインポーターを使う場合の雛形ファイルを生成する、ヘルパーメソッド
        /// </summary>
        /// <param name="filename"></param>
        public static void TestWrite(string filename)
        {
            // 仮データの生成
            XmlMessageDescription obj = new XmlMessageDescription();
            obj.FontDescription = new ExternalReference<FontDescription>("MyFont.spritefont");
            obj.Messages = new ExternalReference<Dictionary<string, string>>("Message.txt");
            obj.DiscardMessage = false;

            // シリアライズする
            using (XmlWriter writer = XmlWriter.Create(filename))
            {
                IntermediateSerializer.Serialize<XmlMessageDescription>(writer, obj, ".");
            }
        }
    }
}
