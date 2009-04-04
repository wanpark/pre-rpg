using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    class PlayerPreviewView : View
    {

        private Player player;

        private Texture2D playerTexture;

        public PlayerPreviewView(GameScreen screen, Player player)
            : base(screen)
        {
            this.player = player;
            Position = new Vector2(140, 10);
            LoadContent();
        }

        public void LoadContent()
        {
            playerTexture = Content.Load<Texture2D>("Characters/" + player.Name);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Draw(playerTexture, Position, Color.White);
            SpriteBatch.DrawString(Font, Message("JobMenu", "Title"), new Vector2(Position.X + 30, Position.Y + 10), Color.Black);
        }

    }
}
