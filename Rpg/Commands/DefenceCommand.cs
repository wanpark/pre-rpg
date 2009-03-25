using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{
    class DefenceCommand : Command
    {


        public override string Name
        {
            get { return "Defence"; }
        }

        public DefenceCommand() : base() { }
        public DefenceCommand(Character performer) : base(performer) { }

    }
}
