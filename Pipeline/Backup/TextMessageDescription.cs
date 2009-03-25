using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

// MessageContent.TestWrite���\�b�h�ɕK�v�Ȗ��O���
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace Sample.Pipeline
{
    /// <summary>
    /// �e�L�X�g���b�Z�[�W�L�q�N���X�B�g���t�H���g�ƃ��b�Z�[�W�t�@�C�����w�肷��B
    /// </summary>
    public class TextMessageDescription
    {
        /// <summary>
        /// SpriteFont�t�@�C���ւ̊O���Q��
        /// </summary>
        public ExternalReference<FontDescription>   FontDescription;

        /// <summary>
        /// �e�L�X�g�t�@�C���̊O���Q��
        /// </summary>
        public ExternalReference<string[]>          Message;

        /// <summary>
        /// ���b�Z�[�W��TextMessageContent�Ɋi�[���邩�̎w��t���O�B
        /// ����̓e�L�X�g�t�@�C�����\�[�X�R�[�h���̂�A���\�[�X�t�@�C��
        /// ���������ȂǂɃ��b�Z�[�W�f�[�^���d������̂�h�����߁B
        /// </summary>
        public bool                                 DiscardMessage;

    /// <summary>
    /// XML�C���|�[�^�[���g���ꍇ�̐��`�t�@�C���𐶐�����A�w���p�[���\�b�h
    /// </summary>
    /// <param name="filename"></param>
    public static void TestWrite( string filename )
    {
        // ���f�[�^�̐���
        TextMessageDescription obj = new TextMessageDescription();
        obj.FontDescription = new ExternalReference<FontDescription>("MyFont.spritefont");
        obj.Message         = new ExternalReference<string[]>("Message.txt");
        obj.DiscardMessage  = false;

        // �V���A���C�Y����
        using ( XmlWriter writer = XmlWriter.Create( filename ) )
        {
            IntermediateSerializer.Serialize<TextMessageDescription>(writer, obj, ".");
        }
    }
    }
}
