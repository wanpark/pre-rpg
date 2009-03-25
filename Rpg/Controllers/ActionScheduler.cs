using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Rpg
{

    delegate void Action();

    class ActionScheduler
    {

        List<Action> actions;
        Dictionary<Action, float> remainTimes;

        public ActionScheduler()
        {
            actions = new List<Action>();
            remainTimes = new Dictionary<Action, float>();
        }

        public void Add(Action action, float time)
        {
            actions.Add(action);
            remainTimes[action] = time;
        }

        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            actions.RemoveAll(delegate(Action action)
            {
                float remain = remainTimes[action] - elapsed;
                if (remain <= 0)
                {
                    remainTimes.Remove(action);
                    action();
                    return true;
                }
                else
                {
                    remainTimes[action] = remain;
                    return false;
                }
            });
        }
    }
}
