using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

// MessageContent.TestWriteメソッドに必要な名前空間
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace Sample.Pipeline
{
    /// <summary>
    /// テキストメッセージ記述クラス。使うフォントとメッセージファイルを指定する。
    /// </summary>
    public class TextMessageDescription
    {
        /// <summary>
        /// SpriteFontファイルへの外部参照
        /// </summary>
        public ExternalReference<FontDescription>   FontDescription;

        /// <summary>
        /// テキストファイルの外部参照
        /// </summary>
        public ExternalReference<string[]>          Message;

        /// <summary>
        /// メッセージをTextMessageContentに格納するかの指定フラグ。
        /// これはテキストファイルがソースコード自体や、リソースファイル
        /// だった時などにメッセージデータが重複するのを防ぐため。
        /// </summary>
        public bool                                 DiscardMessage;

    /// <summary>
    /// XMLインポーターを使う場合の雛形ファイルを生成する、ヘルパーメソッド
    /// </summary>
    /// <param name="filename"></param>
    public static void TestWrite( string filename )
    {
        // 仮データの生成
        TextMessageDescription obj = new TextMessageDescription();
        obj.FontDescription = new ExternalReference<FontDescription>("MyFont.spritefont");
        obj.Message         = new ExternalReference<string[]>("Message.txt");
        obj.DiscardMessage  = false;

        // シリアライズする
        using ( XmlWriter writer = XmlWriter.Create( filename ) )
        {
            IntermediateSerializer.Serialize<TextMessageDescription>(writer, obj, ".");
        }
    }
    }
}
