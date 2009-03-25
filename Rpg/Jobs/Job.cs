using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{
    class Job
    {

        public string Name
        {
            get { return name; }
        }
        private string name;


        public Job(string name)
        {
            this.name = name;
        }


        public string TextureName()
        {
            return TextureName(Sex.Male);
        }
        public string TextureName(Sex sex)
        {
            string textureName = "Jobs/" + name;
            if (HasSexTexture() && sex == Sex.Female)
            {
                textureName += "_female";
            }
            return textureName;
        }

        public virtual bool HasSexTexture()
        {
            return false;
        }

    }
}
