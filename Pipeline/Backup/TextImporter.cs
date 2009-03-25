using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace Sample.Pipeline
{
    /// <summary>
    /// UTF-8�t�@�C���t�H�[�}�b�g�̃e�L�X�g�t�@�C����ǂݍ��ރC���|�[�^�[
    /// </summary>

    // �C���|�[�^�[�N���X�ɂ́AContentImporterAttribute���w�肷��
    [ContentImporter(".txt", DisplayName="UTF-8 �e�L�X�g�t�@�C���C���|�[�^�[")]
    public class TextImporter : ContentImporter<string[]>
    {
        /// <summary>
        /// �f�[�^���t�@�C���������̃^�C�v�ɃC���|�[�g����B
        /// </summary>
        /// <param name="filename">�C���|�[�g����t�@�C����</param>
        /// <param name="context">�R���e���g�C���|�[�^�[�̃R���e�L�X�g�A���O��t�@�C���̈ˑ��֌W���w��ł���B</param>
        /// <returns></returns>
        public override string[] Import(string filename, ContentImporterContext context)
        {
            // LogWarning�܂���LogImportantMessage���g���ƁA�r���h���b�Z�[�W�E�B���h�E��
            // ���b�Z�[�W��\���ł���B
            context.Logger.LogImportantMessage("�t�@�C���ǂݍ��݊J�n {0}", filename);
            // �e�L�X�g�t�@�C����ǂݍ����string[]�`���ɂ���B
            List<string> text = new List<string>();
            using (StreamReader sr = File.OpenText(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    text.Add(line);
                }
            }

            return text.ToArray();
        }
    }
}
