using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Rpg
{
    class CommandController : Controller
    {

        public CommandController(ControllerManager controllerManager)
            : base(controllerManager)
        {
            Views = new List<View>();
            foreach (View player in ViewManager.Players)
            {
                Views.Add(player);
            }
            foreach (View enemy in ViewManager.Enemies)
            {
                Views.Add(enemy);
            }
        }

        public override void Begin()
        {
            Scheduler.Add(endBattle, 2);
        }

        private void endBattle()
        {
            ControllerManager.Controller = new LeaveController(ControllerManager);
        }

    }
}
