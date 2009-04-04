using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Rpg.Runtime;

namespace Rpg
{
    class JobReader : ContentTypeReader<JobContent>
    {
        protected override JobContent Read(ContentReader input, JobContent existingInstance)
        {
            JobContent job = new JobContent();
            job.Name = input.ReadString();
            job.CommandName = input.ReadString();
            job.MaxHp = input.ReadInt32();
            job.MaxMp = input.ReadInt32();
            job.Exp = input.ReadInt32();
            job.HasSexTexture = input.ReadBoolean();

            return job;
        }
    }
}
