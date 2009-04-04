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

        public Command Command
        {
            get { return command; }
        }
        private Command command;

        public int MaxHp
        {
            get { return maxHp; }
        }
        private int maxHp;

        public int MaxMp
        {
            get { return maxMp; }
        }
        private int maxMp;

        public int Exp
        {
            get { return exp; }
        }
        private int exp;


        public Job(string name, Command command, int maxHp, int maxMp, int exp)
        {
            this.name = name;
            this.command = command;
            this.maxHp = maxHp;
            this.maxMp = maxMp;
            this.exp = exp;
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
