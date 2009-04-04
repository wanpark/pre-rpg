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

            setupBattle();

            foreach (bool b in this.Sleep(0.3f)) yield return true;

            transform();

            foreach (PlayerView player in ViewManager.Players)
                if (!player.IsTransformed())
                    foreach (bool b in this.WaitEvent(player, "TransformEnd")) yield return true;

            ViewManager.Characters.ForEach(character => character.StatusVisible = true);

            ControllerManager.PerformNext();
        }

        private void stop()
        {
            ViewManager.Players.ForEach(player => player.Stop());
        }

        private void appearEnemy()
        {
            ModelManager.CreateEnemies();
            ViewManager.CreateEnemies();

            AddViews(ViewManager.Enemies);
            ViewManager.Enemies.ForEach(enemy => enemy.Appear());
        }

        private void setupBattle()
        {
            ModelManager.SetupBattle();
        }

        private void transform()
        {
            ViewManager.Players.ForEach(player => player.Transform());
        }

    }

}
