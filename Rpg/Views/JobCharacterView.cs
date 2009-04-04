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

        public override Vector2 CursorPosition
        {
            get { return new Vector2(Position.X - 40, Position.Y - 40); }
        }

        private SpriteEffects mirroring;

        public JobCharacterView(Character character, GameScreen screen, Vector2 position, bool isMirrorTexture)
            : base(character, position, screen)
        {
            mirroring = isMirrorTexture ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            LoadContent();

            Character.JobChanged += (sender, args) => LoadContent();
        }

        public void LoadContent()
        {
            texture = Content.Load<Texture2D>(Character.Job.TextureName(Character.Sex));
        }

        public override void Draw(GameTime gameTime)
        {
            if (!Visible) return;

            if (Character.Alive)
            {
                SpriteBatch.Draw(texture, Position, null, Color.White,
                    0, new Vector2(texture.Width / 2, texture.Height), 1, mirroring, 0);
            }
        }


    }
}
