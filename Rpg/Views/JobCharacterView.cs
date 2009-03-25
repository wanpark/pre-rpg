using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    class JobCharacterView :View
    {
        private Character character;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        private Vector2 position;

        protected Texture2D Texture
        {
            get { return texture; }
        }
        private Texture2D texture;

        private SpriteEffects mirroring;

        public JobCharacterView(Character character, GameScreen screen, Vector2 position, bool isMirrorTexture)
            : base(screen)
        {
            this.character = character;
            this.position = position;
            mirroring = isMirrorTexture ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            LoadContent();
        }

        public void LoadContent()
        {
            texture = Content.Load<Texture2D>(character.Job.TextureName(character.Sex));
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Draw(texture, position, null, Color.White,
                0, new Vector2(texture.Width / 2, texture.Height), 1, mirroring, 0);
        }


    }
}
