using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Rpg
{
    class CommandSelectController : Controller
    {
        private Player performer;
        private CommandSelectView selectView;

        public CommandSelectController(ControllerManager controllerManager, Player performer)
            : base(controllerManager)
        {
            AddViews(ViewManager.Characters);

            this.performer = performer;
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
            Command command = (Command)selectView.SelectedCommand().Clone();
            command.Performer = performer;
            ControllerManager.Controller = new CommandTargetSelectController(ControllerManager, command, this);
        }

    }
}
