using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    class ForwardArrowView : View
    {

        AnimatedTexture arrowTexture;

        public ForwardArrowView(GameScreen screen)
            : base(screen)
        {
            LoadContent();
        }

        public void LoadContent()
        {
            arrowTexture = new AnimatedTexture(Content, "arrow", 2, 0.4f);
            arrowTexture.Play();
        }

        public override void Update(GameTime gameTime)
        {
            arrowTexture.UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public override void Draw(GameTime gameTime)
        {
            arrowTexture.DrawFrame(SpriteBatch, new Vector2(60, 180));
        }

    }
}
