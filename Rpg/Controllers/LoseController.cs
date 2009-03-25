using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Rpg
{
    class LoseController : LeaveController
    {

        public LoseController(ControllerManager controllerManager)
            : base(controllerManager)
        {
            AddViews(ViewManager.Enemies);
        }

        public override IEnumerator<bool> UpdateCoroutine()
        {
            ViewManager.Enemies.ForEach(enemy => enemy.Disappear());

            foreach (bool b in this.Sleep(0.8f)) yield return true;

            IEnumerator<bool> leave = leaveUpdateCoroutine();
            while (leave.MoveNext()) yield return true;
        }

        private IEnumerator<bool> leaveUpdateCoroutine()
        {
            return base.UpdateCoroutine();
        }

    }
}
