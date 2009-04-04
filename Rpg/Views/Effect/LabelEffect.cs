using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    class LabelEffect : Effect
    {

        private string label;
        private Vector2 position;
        private Color color;

        public LabelEffect(View view, string label, Vector2 position, Color color)
            : base(view)
        {
            this.label = label;
            this.position = position;
            this.color = color;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            View.SpriteBatch.DrawString(View.Font, label, position, color);
        }

    }
}
