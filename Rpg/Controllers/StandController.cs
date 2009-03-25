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
            foreach (View player in ViewManager.FieldPlayers)
            {
                Views.Add(player);
            }
            Views.Add(ViewManager.ForwardArrow);
        }

        public override void Begin()
        {
            foreach (FieldPlayerView player in ViewManager.FieldPlayers)
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
            foreach (FieldPlayerView player in ViewManager.FieldPlayers)
            {
                player.Walk();
            }

            ControllerManager.Controller = new EncounterController(ControllerManager);
        }

    }
}
