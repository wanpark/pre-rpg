using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace Rpg.Pipeline
{
    /// <summary>
    /// �������ꂽ�e�L�X�g���b�Z�[�W��ێ�����R���e���g�N���X
    /// </summary>
    public class XmlMessageContent
    {
        /// <summary>
        /// �X�v���C�g�t�H���g�R���e���g
        /// </summary>
        public SpriteFontContent    Font;

        /// <summary>
        /// ���b�Z�[�WDictionary
        /// </summary>
        public Dictionary<string, string> Messages;
    }


    /// <summary>
    /// XmlMessageContent��XNB�t�@�C���ɏ����o���ׂ̃^�C�v���C�^�[
    /// </summary>

    // ContentTypeWriterAttribute���w�肷��K�v������AContentTypeWriter<T>����h�������N���X��錾����B
    [ContentTypeWriter]
    public class XmlMessageContentWriter : ContentTypeWriter<XmlMessageContent>
    {
        /// <summary>
        /// �R���e���g�̏����o��
        /// </summary>
        /// <param name="output">�R���e���g���C�^�[</param>
        /// <param name="value">�����o���I�u�W�F�N�g</param>
        protected override void Write(ContentWriter output, XmlMessageContent value)
        {
            output.WriteObject<SpriteFontContent>(value.Font);
            output.WriteObject<Dictionary<string, string>>(value.Messages);
        }

        public override string GetRuntimeReader(Microsoft.Xna.Framework.TargetPlatform targetPlatform)
        {
            // �����^�C������TypeReader�̕���Ԃ��B�ʏ��"�t���l�[���X�y�[�X,�A�Z���u����"�ɂȂ�B
            // TypeReader���̂̓Q�[���{�̂Œ�`���Ă����삷�邪�A���̏ꍇ�A�Q�[���ɂ����
            // ���̕������ύX���Ȃ��Ƃ����Ȃ��̂Ŏg���񂵂������Ȃ��A���̖����������ׂ�
            // �ʓ|�ł�Runtime�v���W�F�N�g��ʂɍ���Ēu���̂��ǂ��B
            return "Rpg.Runtime.XmlMessageReader,Rpg.Runtime";
        }
    }

}
