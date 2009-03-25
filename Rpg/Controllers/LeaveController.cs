using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Rpg
{
    class LeaveController : CoroutineController
    {

        public LeaveController(ControllerManager controllerManager)
            : base(controllerManager)
        {
            AddViews(ViewManager.Players);
        }

        public override IEnumerator<bool> UpdateCoroutine()
        {
            ViewManager.Players.ForEach(player => player.Detransform());

            foreach (PlayerView player in ViewManager.Players)
                if (!player.IsDetransformed())
                    foreach (bool b in this.WaitEvent(player, "DetransformEnd")) yield return true;

            ControllerManager.Controller = new StandController(ControllerManager);
        }

    }
}
