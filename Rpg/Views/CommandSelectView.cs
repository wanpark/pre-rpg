using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    class CommandSelectView : View
    {

        private PlayerView playerView;
        private Texture2D frameTexture;
        private Texture2D cursorTexture;

        private int selectedIndex;

        public CommandSelectView(GameScreen screen, PlayerView playerView)
            : base(screen)
        {
            this.playerView = playerView;
            selectedIndex = 0;
            LoadContent();
        }

        public void LoadContent()
        {
            frameTexture = Content.Load<Texture2D>("command_frame");
            cursorTexture = Content.Load<Texture2D>("cursor");
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 position = new Vector2(
                playerView.Position.X - frameTexture.Width - 30,
                playerView.Position.Y - frameTexture.Height
                );
            SpriteBatch.Draw(frameTexture, position, null, Color.White);

            int i = 0;
            position = new Vector2(position.X + 15, position.Y + 10);
            foreach (Command command in playerView.Player.Commands)
            {
                if (i++ == selectedIndex)
                {
                    Vector2 cursorPosition = new Vector2(position.X - 8, position.Y);
                    SpriteBatch.Draw(cursorTexture, cursorPosition, null, Color.White);
                }
                SpriteBatch.DrawString(Font, CommandLabel(command), position, Color.Black);
                position.Y += 12;
            }
        }


        private string CommandLabel(Command command)
        {
            return Message("Command", command.Name, "Name");
        }


        public void SelectNext()
        {
            int count = playerView.Player.Commands.Count;
            selectedIndex = ++selectedIndex % count;
        }
        public void SelectPrevious()
        {
            int count = playerView.Player.Commands.Count;
            selectedIndex = (--selectedIndex + count) % count;
        }

        public Command SelectedCommand()
        {
            return playerView.Player.Commands[selectedIndex];
        }

    }
}
