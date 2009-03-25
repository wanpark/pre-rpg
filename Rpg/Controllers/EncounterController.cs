using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Rpg
{
    class EncounterController : Controller
    {

        public EncounterController(ControllerManager controllerManager)
            : base(controllerManager)
        {
            Views = new List<View>();
            foreach (View player in ViewManager.FieldPlayers)
            {
                Views.Add(player);
            }
        }

        public override void Begin()
        {
            Scheduler.Add(appearEnemy, 1.0f);
            Scheduler.Add(stop, 1.0f);
            Scheduler.Add(transform, 1.3f);
        }

        private void stop()
        {
            foreach (FieldPlayerView player in ViewManager.FieldPlayers)
            {
                player.Stop();
            }
        }

        private void appearEnemy()
        {
            ModelManager.CreateEnemies();
            ViewManager.CreateEnemies();

            foreach (EnemyView enemy in ViewManager.Enemies)
            {
                Views.Add(enemy);
                enemy.Appear();
            }
        }

        private void transform()
        {
            ViewManager.FieldPlayers[0].TransformEnd += endTransformMovie;
            foreach (FieldPlayerView player in ViewManager.FieldPlayers)
            {
                player.Transform();
            }
        }

        private void endTransformMovie(object sender, EventArgs args)
        {
            foreach (FieldPlayerView player in ViewManager.FieldPlayers)
            {
                player.TransformEnd -= endTransformMovie;
            }
            ControllerManager.Controller = new CommandController(ControllerManager);
        }
    }
}
