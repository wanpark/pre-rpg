using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Sample.Runtime
{
    /// <summary>
    /// テキストメッセージとフォントを保持するTextMessageクラス
    /// </summary>
    public class TextMessage
    {
        /// <summary>
        /// スプライトフォント
        /// </summary>
        public SpriteFont   Font;

        /// <summary>
        /// テキストメッセージ
        /// </summary>
        public string[]     Message;
    }

    /// <summary>
    /// TextMessageデータを読み込むTypeReader
    /// </summary>
    public class TextMessageReader : ContentTypeReader<TextMessage>
    {
        protected override TextMessage Read(ContentReader input, TextMessage existingInstance)
        {
            TextMessage textMessage = new TextMessage();

            textMessage.Font = input.ReadObject<SpriteFont>();
            textMessage.Message = input.ReadObject<string[]>();

            return textMessage;
        }
    }

}
