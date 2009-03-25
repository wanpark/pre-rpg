using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Rpg
{
    class LeaveController : Controller
    {

        public LeaveController(ControllerManager controllerManager)
            : base(controllerManager)
        {
            Views = new List<View>();
            foreach (View player in ViewManager.FieldPlayers)
            {
                Views.Add(player);
            }
        }

        public override void Begin()
        {
            foreach (FieldPlayerView player in ViewManager.FieldPlayers)
            {
                player.Appear();
                player.AppearEnd += appeared;
            }
        }

        private void appeared(object sender, EventArgs args)
        {
            foreach (FieldPlayerView player in ViewManager.FieldPlayers)
            {
                player.Stop();
                player.AppearEnd -= appeared;
            }
            ControllerManager.Controller = new StandController(ControllerManager);
        }
    }
}
