using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace Rpg
{
    public interface ICoroutineUpdatable
    {

        GameTime CurrentGameTime
        {
            get;
        }

        IEnumerator<bool> UpdateCoroutine();

    }

    public static class CoroutineUpdatableExtension
    {
        public static IEnumerable<bool> Sleep(this ICoroutineUpdatable updatable, float duration)
        {
            while (duration > 0)
            {
                duration -= (float)updatable.CurrentGameTime.ElapsedGameTime.TotalSeconds;
                yield return true;
            }
        }

        public static IEnumerable<bool> WaitEvent(this ICoroutineUpdatable updatable, object target, string eventName)
        {
            EventInfo e = target.GetType().GetEvent(eventName);
            bool waiting = true;
            EventHandler handler = null;
            handler = delegate(object sender, EventArgs args)
            {
                e.RemoveEventHandler(target, handler);
                waiting = false;
            };
            e.AddEventHandler(target, handler);

            while (waiting)
            {
                yield return true;
            }
        }
    }
}
