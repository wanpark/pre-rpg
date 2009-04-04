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


        public override void Perform()
        {
            Target.Damage(10);
        }
    }
}
