using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

namespace Sample.Pipeline
{
    /// <summary>
    /// TextMessageDescription����TextMessageContent�ɕϊ�����v���Z�b�T
    /// </summary>

    // �v���Z�b�T�N���X�ɂ́AContentProcessorAttribute���w�肷��
    [ContentProcessor(DisplayName = "�e�L�X�g���b�Z�[�W�v���Z�b�T")]
    class TextMessageProcessor : ContentProcessor<TextMessageDescription, TextMessageContent>
    {
        public override TextMessageContent Process(TextMessageDescription input, ContentProcessorContext context)
        {
            // context��ʂ���ExternalReference(�O���Q��)�̃A�Z�b�g���r���h�����ł���B
            // �ʏ�A�v���Z�b�T���w�肷�邪�A�����ł�null���w�肷�邱�ƂŁA
            // �C���|�[�g����̃^�C�v���擾���Ă���B
            FontDescription fontDescription = context.BuildAndLoadAsset<FontDescription, FontDescription>(input.FontDescription, null);
            string[] messageSource = context.BuildAndLoadAsset<string[], string[]>(input.Message, null);

            // FontDescription��Characters��messageSource�Ŏg�p���Ă��镶���R�[�h��ǉ�����B
            int totalCharacterCount = 0;
            foreach (string line in messageSource)
            {
                foreach (char c in line)
                {
                    totalCharacterCount++;

                    // FontDescription.Characters.Add���\�b�h���ŕ����R�[�h�d���`�F�b�N�����Ă���̂�
                    // �����ł͏d�����C�ɂ����ɕ�����ǉ����邾���ł悢�B
                    fontDescription.Characters.Add(c);
                }
            }

            // �ŏI���ʂɕϊ�����
            TextMessageContent outContent = new TextMessageContent();

            // FontDescriptionProcessor�𒼐ڎ��s���āASpriteFontContent���擾����B
            FontDescriptionProcessor processor = new FontDescriptionProcessor();
            outContent.Font = processor.Process(fontDescription, context);

            // ���b�Z�[�W������̏����BDiscardMessage�t���O��True�̏ꍇ�͏������Ȃ��B
        if (!input.DiscardMessage)
            outContent.Message = ProcessMessage(messageSource);

            context.Logger.LogImportantMessage(String.Format("�g�p������{0}, ��������:{1}", fontDescription.Characters.Count, totalCharacterCount));

            return outContent;
        }

        /// <summary>
        /// �e�L�X�g���b�Z�[�W�̏���
        /// ���̃T���v���ł́A�P���Ɍ��̃e�L�X�g���󔒍s����؂�Ƃ���
        /// �����̃��b�Z�[�W�ɕϊ����Ă���B
        /// </summary>
        /// <param name="messageSource"></param>
        /// <returns></returns>
        string[] ProcessMessage(string[] messageSource)
        {
            List<string> messages = new List<string>();
            string curMessage = String.Empty;
            bool capturingMessage = false;

            foreach (string line in messageSource)
            {
                if (String.IsNullOrEmpty(line) == false )
                {
                    curMessage += line + "\n";
                    capturingMessage = true;
                }
                else
                {
                    if ( capturingMessage )
                    {
                        messages.Add(curMessage);
                        curMessage = String.Empty;
                        capturingMessage = false;
                    }
                }
            }

            if (capturingMessage)
            {
                messages.Add(curMessage);
            }

            return messages.ToArray();
        }

    }
}