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
    class EnemyCommandPerformController : Controller
    {

        private Command command;
        private CommandSerifView serifView;

        public EnemyCommandPerformController(ControllerManager controllerManager, Enemy enemy)
            : base(controllerManager)
        {
            this.command = ModelManager.CreateEnemyCommand(enemy);

            AddViews(ViewManager.Characters);
        }

        public override void  Begin()
        {
 	        base.Begin();
            Scheduler.Add(say, 0.2f);
            Scheduler.Add(delegate() { ControllerManager.PerformCommand(command); }, 0.6f);
        }

        private void say()
        {
            EnemyView view = (EnemyView)ViewManager.ViewForCharacter(command.Performer);
            serifView = new CommandSerifView(Screen, command, view);
            Views.Add(serifView);
        }

    }
}
