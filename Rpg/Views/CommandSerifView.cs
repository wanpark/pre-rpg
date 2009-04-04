using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    class CommandSerifView : View
    {

        private Command command;
        private CharacterView characterView;
        private Texture2D frameTexture;

        public CommandSerifView(GameScreen screen, Command command, CharacterView characterView)
            : base(screen)
        {
            this.command = command;
            this.characterView = characterView;
            LoadContent();
        }

        public void LoadContent()
        {
            frameTexture = Content.Load<Texture2D>("serif_frame");
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 position = new Vector2(characterView.Position.X + 40, characterView.Position.Y - 50);
            SpriteBatch.Draw(frameTexture, position, null, Color.White);

            position = new Vector2(position.X + 13, position.Y + 8);
            SpriteBatch.DrawString(Font, CommandLabel(), position, Color.Black);

            base.Draw(gameTime);
        }

        private string CommandLabel()
        {
            return Message("Command", command.Name, "Name");
        }

        
    }
}
