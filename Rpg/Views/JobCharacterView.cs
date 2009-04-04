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
        const int STATUS_WIDTH = 45;
        static readonly Color STATUS_BACKGROUND_COLOR = Color.LightGray;
        static readonly Color STATUS_HP_COLOR = Color.Green;
        static readonly Color STATUS_MP_COLOR = Color.Tomato;

        protected Texture2D Texture
        {
            get { return texture; }
        }
        private Texture2D texture;

        private Texture2D pixelTexture;

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

            Character.JobChanged += (sender, args) => LoadJobTexture();
        }

        public void LoadContent()
        {
            pixelTexture = Content.Load<Texture2D>("blank");
            LoadJobTexture();
        }
        private void LoadJobTexture()
        {
            texture = Content.Load<Texture2D>(Character.Job.TextureName(Character.Sex));
        }

        public override void Draw(GameTime gameTime)
        {
            if (!Visible) return;

            if (Character.Alive)
            {
                Vector2 origin = new Vector2(texture.Width / 2, texture.Height);
                SpriteBatch.Draw(texture, Vector2.Add(Position, CharacterPosition), null, Color.White, 0, origin, 1, mirroring, 0);
            }

            if (StatusVisible)
                DrawStatus(gameTime);

            base.Draw(gameTime);
        }

        private void DrawStatus(GameTime gameTime)
        {
            Vector2 position = new Vector2(Position.X, Position.Y - 26);
            position.X += Character.Party == Party.Player ? 40 : -40 - STATUS_WIDTH;

            DrawStatusMeter(Character.Hp, Character.MaxHp, position, STATUS_HP_COLOR);
            position.Y += 15;
            DrawStatusMeter(Character.Mp, Character.MaxMp, position, STATUS_MP_COLOR);
        }

        private void DrawStatusMeter(int value, int max, Vector2 position, Color color)
        {
            string label = value.ToString() + "/" + max.ToString();
            Vector2 labelPosition = position;
            if (Character.Party == Party.Player)
                labelPosition.X = position.X + STATUS_WIDTH - Font.MeasureString(label).X;
            SpriteBatch.DrawString(Font, label, labelPosition, Color.Black);

            Rectangle rect = new Rectangle((int)position.X, (int)position.Y + 10, STATUS_WIDTH, 1);
            SpriteBatch.Draw(pixelTexture, rect, null, STATUS_BACKGROUND_COLOR);

            rect.Width = max == 0 ? 0 : (int)(rect.Width * (float)value / (float)max);
            SpriteBatch.Draw(pixelTexture, rect, null, color);
        }
    }
}
