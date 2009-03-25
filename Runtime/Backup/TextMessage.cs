using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Sample.Runtime
{
    /// <summary>
    /// �e�L�X�g���b�Z�[�W�ƃt�H���g��ێ�����TextMessage�N���X
    /// </summary>
    public class TextMessage
    {
        /// <summary>
        /// �X�v���C�g�t�H���g
        /// </summary>
        public SpriteFont   Font;

        /// <summary>
        /// �e�L�X�g���b�Z�[�W
        /// </summary>
        public string[]     Message;
    }

    /// <summary>
    /// TextMessage�f�[�^��ǂݍ���TypeReader
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
