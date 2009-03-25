using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    class BlinkEffect : CoroutineEffect
    {

        private float duration;

        public BlinkEffect(float duration)
            : this(duration, null)
        {}

        public BlinkEffect(float duration, View view)
            : base(view)
        {
            this.duration = duration;
        }

        public override IEnumerator<bool> UpdateCoroutine()
        {
            View.Visible = false;
            foreach (bool b in this.Sleep(duration)) yield return true;
            View.Visible = true;
        }

    }
}
