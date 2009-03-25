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

        public EnemyCommandPerformController(ControllerManager controllerManager, Enemy enemy)
            : base(controllerManager)
        {
            this.command = ModelManager.CreateEnemyCommand(enemy);

            Views = new List<View>();
            foreach (View view in ViewManager.Characters)
            {
                Views.Add(view);
            }

            Scheduler.Add(blink, 0.2f);
            Scheduler.Add(doEffect, 0.5f);
        }

        private void blink()
        {
            EnemyView view = ViewManager.Enemies.Find(delegate(EnemyView v)
            {
                return v.Character == command.Performer;
            });
            view.Blink();
        }

        private void doEffect()
        {
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
