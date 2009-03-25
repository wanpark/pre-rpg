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

            Views = new List<View>();
            foreach (View view in ViewManager.Characters)
            {
                Views.Add(view);
            }

            CommandEffectView effect = new CommandEffectView(Screen, command, ViewManager);
            effect.EffectEnd += effectEnd;
            Views.Add(effect);
        }

        private void effectEnd(object sender, EventArgs args)
        {
            ((CommandEffectView)sender).EffectEnd -= effectEnd;
            ControllerManager.PerformCommand(command);
        }

    }
}
