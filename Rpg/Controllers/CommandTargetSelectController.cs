using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Rpg
{
    class CommandTargetSelectController : CharacterSelectController
    {

        private Command command;
        private CommandSelectController commandSelectController;

        public CommandTargetSelectController(ControllerManager controllerManager, Command command, CommandSelectController commandSelectController)
            : base(controllerManager, CharacterSelectType.One)
        {
            this.command = command;
            this.commandSelectController = commandSelectController;

            AddViews(ViewManager.Characters);

            Selected += performCommand;
            Cancelled += commandReselect;

            SelectCharacter(ModelManager.Enemies[0]);
        }

        private void performCommand(object sender, EventArgs args)
        {
            command.Target = SelectedCharacter();
            ControllerManager.Controller = new CommandPerformController(ControllerManager, command);
        }

        private void commandReselect(object sender, EventArgs args)
        {
            ControllerManager.Controller = commandSelectController;
        }

    }
}
