using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

using Rpg.Runtime;

namespace Rpg.Pipeline
{

    /// <summary>
    /// XmlMessageContent��XNB�t�@�C���ɏ����o���ׂ̃^�C�v���C�^�[
    /// </summary>

    // ContentTypeWriterAttribute���w�肷��K�v������AContentTypeWriter<T>����h�������N���X��錾����B
    [ContentTypeWriter]
    public class JobWriter : ContentTypeWriter<JobContent>
    {
        /// <summary>
        /// �R���e���g�̏����o��
        /// </summary>
        /// <param name="output">�R���e���g���C�^�[</param>
        /// <param name="value">�����o���I�u�W�F�N�g</param>
        protected override void Write(ContentWriter output, JobContent value)
        {
            output.Write(value.Name);
            output.Write(value.CommandName);
            output.Write(value.MaxHp);
            output.Write(value.MaxMp);
            output.Write(value.Exp);
            output.Write(value.HasSexTexture);
        }

        public override string GetRuntimeReader(Microsoft.Xna.Framework.TargetPlatform targetPlatform)
        {
            return "Rpg.JobReader,Rpg";
        }
    }

}
