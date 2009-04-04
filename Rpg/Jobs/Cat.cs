using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{
    class Cat : Job
    {


        public Cat()
            : base("Cat", new AttackCommand(), 10, 10, 5)
        {
        }

    }
}
