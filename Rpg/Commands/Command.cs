using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{

    class Command : ICloneable
    {

        public virtual string Name
        {
            get { return "Empty"; }
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

        public object Clone()
        {
            Command clone = (Command)Activator.CreateInstance(this.GetType());
            clone.Target = Target;
            clone.Performer = Performer;
            return clone;
        }

        public virtual void Perform() { }
    }
}
