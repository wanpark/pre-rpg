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
    /// XmlMessageContentをXNBファイルに書き出す為のタイプライター
    /// </summary>

    // ContentTypeWriterAttributeを指定する必要があり、ContentTypeWriter<T>から派生したクラスを宣言する。
    [ContentTypeWriter]
    public class JobWriter : ContentTypeWriter<JobContent>
    {
        /// <summary>
        /// コンテントの書き出し
        /// </summary>
        /// <param name="output">コンテントライター</param>
        /// <param name="value">書き出すオブジェクト</param>
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
