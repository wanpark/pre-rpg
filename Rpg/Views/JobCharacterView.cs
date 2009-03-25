using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    class JobCharacterView :CharacterView
    {

        protected Texture2D Texture
        {
            get { return texture; }
        }
        private Texture2D texture;

        private SpriteEffects mirroring;

        public JobCharacterView(Character character, GameScreen screen, Vector2 position, bool isMirrorTexture)
            : base(character, position, screen)
        {
            mirroring = isMirrorTexture ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            LoadContent();
        }

        public void LoadContent()
        {
            texture = Content.Load<Texture2D>(Character.Job.TextureName(Character.Sex));
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Draw(texture, Position, null, Color.White,
                0, new Vector2(texture.Width / 2, texture.Height), 1, mirroring, 0);
        }


    }
}
