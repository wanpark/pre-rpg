using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Rpg
{
    class CommandTargetSelectController : Controller
    {

        private Command command;
        private CommandSelectController commandSelectController;

        private CommandTargetSelectView selectView;

        public CommandTargetSelectController(ControllerManager controllerManager, Command command, CommandSelectController commandSelectController)
            : base(controllerManager)
        {
            this.command = command;
            this.commandSelectController = commandSelectController;

            Views = new List<View>();
            foreach (View player in ViewManager.Players)
            {
                Views.Add(player);
            }
            foreach (View enemy in ViewManager.Enemies)
            {
                Views.Add(enemy);
            }

            selectView = new CommandTargetSelectView(Screen, ViewManager.Players, ViewManager.Enemies);
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
            if (input.IsNewKeyPress(Keys.Left) || input.IsNewKeyPress(Keys.Right))
            {
                selectView.SelectOtherParty();
            }

            if (input.IsNewKeyPress(Keys.X))
            {
                performCommand();
            }
            else if (input.IsNewKeyPress(Keys.Z))
            {
                commandReselect();
            }
        }

        private void performCommand()
        {
            command.Target = selectView.SelectedTarget();
            ControllerManager.Controller = new CommandPerformController(ControllerManager, command);
        }

        private void commandReselect()
        {
            ControllerManager.Controller = commandSelectController;
        }

    }
}
