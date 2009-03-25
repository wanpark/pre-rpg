using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    class CommandPerformController : Controller
    {

        private Command command;
        public CommandPerformController(ControllerManager controllerManager, Command command)
            : base(controllerManager)
        {
            this.command = command;
            AddViews(ViewManager.Characters);
        }

        public override void Begin()
        {
            ControllerManager.PerformCommand(command);
        }

    }
}
