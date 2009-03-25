using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Rpg
{
    class CommandSelectController : Controller
    {
        private CommandSelectView selectView;

        public CommandSelectController(ControllerManager controllerManager, Player performer)
            : base(controllerManager)
        {
            AddViews(ViewManager.Characters);

            selectView = new CommandSelectView(Screen, (PlayerView)ViewManager.ViewForCharacter(performer));
            Views.Add(selectView);
        }

        public override void HandleInput(InputState input)
        {
            base.HandleInput(input);

            if (input.IsNewKeyPress(Keys.Up))
            {
                selectView.SelectPrevious();
            }
            if (input.IsNewKeyPress(Keys.Down))
            {
                selectView.SelectNext();
            }

            if (input.IsNewKeyPress(Keys.X))
            {
                selectTarget();
            }
        }

        private void selectTarget()
        {
            ControllerManager.Controller = new CommandTargetSelectController(ControllerManager, selectView.SelectedCommand(), this);
        }

    }
}
