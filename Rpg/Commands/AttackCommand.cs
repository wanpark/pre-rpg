using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{
    class AttackCommand : Command
    {

        public override string Name
        {
            get { return "Attack"; }
        }

        public AttackCommand() : base() { }
        public AttackCommand(Character performer) : base(performer) { }


    }
}
