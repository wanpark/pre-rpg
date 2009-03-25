using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{
    class EmptyController : Controller
    {

        public EmptyController(ControllerManager manager)
            : base(manager)
        {
            Views = new List<View>();
        }

    }
}
