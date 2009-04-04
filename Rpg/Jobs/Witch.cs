using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{
    class Witch : Job
    {


        public Witch()
            : base("Witch", new AttackCommand(), 10, 10, 5)
        {
        }

    }
}
