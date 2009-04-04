using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    class EncounterController : CoroutineController
    {

        public EncounterController(ControllerManager controllerManager)
            : base(controllerManager)
        {
            AddViews(ViewManager.Players);
        }

        public override IEnumerator<bool> UpdateCoroutine()
        {
            foreach (bool b in this.Sleep(1.0f)) yield return true;

            appearEnemy();
            stop();

            foreach (bool b in this.Sleep(0.3f)) yield return true;

            transform();

            foreach (PlayerView player in ViewManager.Players)
                if (!player.IsTransformed())
                    foreach (bool b in this.WaitEvent(player, "TransformEnd")) yield return true;

            ControllerManager.PerformNext();
        }

        private void stop()
        {
            foreach (PlayerView player in ViewManager.Players)
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
            foreach (PlayerView player in ViewManager.Players)
            {
                player.Transform();
            }
        }

    }

}
