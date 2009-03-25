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
            foreach (View player in ViewManager.Players)
            {
                Views.Add(player);
            }
        }

        public override void Begin()
        {
            // すでに全員変身が解けている時
            if (ViewManager.Players.All(delegate (PlayerView view) {
                return !view.IsTransformed() && !view.IsDetransformimg();
            })) {
                exit();
                return;
            }

            foreach (PlayerView player in ViewManager.Players)
            {
                player.Detransform();
                player.DetransformEnd += detransformed;
            }
        }

        private void detransformed(object sender, EventArgs args)
        {
            if (ViewManager.Players.All(delegate(PlayerView view)
            {
                return !view.IsTransformed() && !view.IsDetransformimg();
            }))
            {
                foreach (PlayerView player in ViewManager.Players)
                {
                    player.Stop();
                    player.DetransformEnd -= detransformed;
                }
                exit();
            }
        }

        private void exit()
        {
            ControllerManager.Controller = new StandController(ControllerManager);
        }
    }
}
