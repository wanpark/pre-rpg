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

        public CommandSelectController(ControllerManager controllerManager, Player targetPlayer)
            : base(controllerManager)
        {
            Views = new List<View>();
            foreach (View view in ViewManager.Characters)
            {
                Views.Add(view);
            }

            PlayerView playerView = ViewManager.Players.Find(delegate(PlayerView view) { return view.Player == targetPlayer; });
            selectView = new CommandSelectView(Screen, playerView);
            Views.Add(selectView);
        }

        public override void Begin()
        {
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
