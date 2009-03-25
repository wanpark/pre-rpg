using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace Sample.Pipeline
{
    /// <summary>
    /// 処理されたテキストメッセージを保持するコンテントクラス
    /// </summary>
    public class TextMessageContent
    {
        /// <summary>
        /// スプライトフォントコンテント
        /// </summary>
        public SpriteFontContent    Font;

        /// <summary>
        /// メッセージ配列
        /// </summary>
        public string[]             Message;
    }


    /// <summary>
    /// TextMessageContentをXNBファイルに書き出す為のタイプライター
    /// </summary>

    // ContentTypeWriterAttributeを指定する必要があり、ContentTypeWriter<T>から派生したクラスを宣言する。
    [ContentTypeWriter]
    public class TextMessageContentWriter : ContentTypeWriter<TextMessageContent>
    {
        /// <summary>
        /// コンテントの書き出し
        /// </summary>
        /// <param name="output">コンテントライター</param>
        /// <param name="value">書き出すオブジェクト</param>
        protected override void Write(ContentWriter output, TextMessageContent value)
        {
            output.WriteObject<SpriteFontContent>(value.Font);
            output.WriteObject<string[]>(value.Message);
        }

        public override string GetRuntimeReader(Microsoft.Xna.Framework.TargetPlatform targetPlatform)
        {
            // ランタイム時のTypeReaderの方を返す。通常は"フルネームスペース,アセンブリ名"になる。
            // TypeReader自体はゲーム本体で定義しても動作するが、その場合、ゲームによって
            // この文字列を変更しないといけないので使い回しが利かない、この問題を回避する為に
            // 面倒でもRuntimeプロジェクトを別に作って置くのが良い。
            return "Sample.Runtime.TextMessageReader,Sample.Runtime";
        }
    }

}
