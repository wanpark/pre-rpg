using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Rpg
{
    class EndBattleController : Controller
    {

        public EndBattleController(ControllerManager controllerManager)
            : base(controllerManager)
        {
            AddViews(ViewManager.Characters);
        }

        public override void HandleInput(InputState input)
        {
            base.HandleInput(input);

            if (input.IsNewKeyPress(Keys.X) ||
                input.IsNewKeyPress(Keys.Z) ||
                input.IsNewKeyPress(Keys.Left)
                )
            {
                ViewManager.Characters.ForEach(character => character.StatusVisible = false);
                ViewManager.Enemies.ForEach(enemy => enemy.Disappear());
                ControllerManager.Controller = new LeaveController(ControllerManager);
            }
        }

    }
}
