using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Rpg
{
    /// <summary>
    /// テキストメッセージとフォントを保持するXmlMessageクラス
    /// </summary>
    public class XmlMessage
    {
        /// <summary>
        /// スプライトフォント
        /// </summary>
        public SpriteFont   Font;

        /// <summary>
        /// テキストメッセージ
        /// </summary>
        public Dictionary<string, string>     Messages;
    }

    /// <summary>
    /// XmlMessageデータを読み込むTypeReader
    /// </summary>
    public class XmlMessageReader : ContentTypeReader<XmlMessage>
    {
        protected override XmlMessage Read(ContentReader input, XmlMessage existingInstance)
        {
            XmlMessage xmlMessage = new XmlMessage();

            xmlMessage.Font = input.ReadObject<SpriteFont>();
            xmlMessage.Messages = input.ReadObject<Dictionary<string, string>>();

            return xmlMessage;
        }
    }

}
