using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{

    abstract class Command
    {

        public abstract string Name
        {
            get;
        }

        public Character Performer
        {
            get { return performer; }
            set { performer = value; }
        }
        private Character performer;

        public Character Target
        {
            get { return target; }
            set { target = value; }
        }
        private Character target;


        public Command()
        {
        }

        public Command(Character performer)
            : this()
        {
            this.performer = performer;
        }

        public Command(Character performer, Character target)
            : this(performer)
        {
            this.target = target;
        }
    }
}
