using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    class MoveEffect : Effect
    {

        private float duration;
        private float elapsed;
        private Vector2 fromPosition;
        private Vector2 toPosition;

        public MoveEffect(Vector2 fromPosition, Vector2 toPosition, float duration)
            : this(fromPosition, toPosition, duration, null)
        { }

        public MoveEffect(Vector2 fromPosition, Vector2 toPosition, float duration, View view)
            : base(view)
        {
            this.fromPosition = fromPosition;
            this.toPosition = toPosition;
            this.duration = duration;
            elapsed = 0;
        }

        public override void Update(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            float ammount = elapsed / duration;
            if (ammount >= 1)
            {
                View.Position = toPosition;
                View.RemoveEffect(this);
            }
            else
            {
                View.Position = Vector2.Lerp(fromPosition, toPosition, ammount);
            }
        }

    }
}
