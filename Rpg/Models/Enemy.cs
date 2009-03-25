using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{
    class Enemy : Character
    {

        public Enemy(Job job)
            : base(Sex.Male, job)
        {
        }

        public Enemy(Sex sex, Job job)
            : base(sex, job)
        {
        }
    }
}
