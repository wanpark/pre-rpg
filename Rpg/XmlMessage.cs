using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Rpg
{
    /// <summary>
    /// �e�L�X�g���b�Z�[�W�ƃt�H���g��ێ�����XmlMessage�N���X
    /// </summary>
    public class XmlMessage
    {
        /// <summary>
        /// �X�v���C�g�t�H���g
        /// </summary>
        public SpriteFont   Font;

        /// <summary>
        /// �e�L�X�g���b�Z�[�W
        /// </summary>
        public Dictionary<string, string>     Messages;
    }

    /// <summary>
    /// XmlMessage�f�[�^��ǂݍ���TypeReader
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
