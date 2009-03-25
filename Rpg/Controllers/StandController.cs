using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Rpg
{
    class StandController : Controller
    {

        public StandController(ControllerManager controllerManager)
            : base(controllerManager)
        {
            Views = new List<View>();
            foreach (View player in ViewManager.Players)
            {
                Views.Add(player);
            }
            Views.Add(ViewManager.ForwardArrow);
        }

        public override void Begin()
        {
            ModelManager.ResetPlayerStatus();
            foreach (PlayerView player in ViewManager.Players)
            {
                player.Stop();
            }
        }

        public override void HandleInput(InputState input) {
            if (input.IsNewKeyPress(Keys.Left))
            {
                walk();
            }
        }

        private void walk()
        {
            foreach (PlayerView player in ViewManager.Players)
            {
                player.Walk();
            }

            ControllerManager.Controller = new EncounterController(ControllerManager);
        }

    }
}
