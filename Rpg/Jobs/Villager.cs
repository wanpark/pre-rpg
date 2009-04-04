using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{
    class Villager : Job
    {


        public Villager()
            : base("Villager", new AttackCommand(), 20, 0, 3)
        {
        }

        public override bool HasSexTexture()
        {
            return true;
        }

    }
}
