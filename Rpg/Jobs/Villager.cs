using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{
    class Villager : Job
    {


        public Villager() : base("villager")
        {
        }

        public override bool HasSexTexture()
        {
            return true;
        }

    }
}
