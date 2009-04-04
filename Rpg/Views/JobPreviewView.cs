using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    class JobPreviewView : View
    {

        private Player player;

        public Job Job
        {
            get { return job; }
            set
            {
                job = value;
                LoadJobTexture();
            }
        }
        private Job job;

        private Texture2D frameTexture;
        private Texture2D jobTexture;

        public JobPreviewView(GameScreen screen, Player player)
            : base(screen)
        {
            this.player = player;
            this.job = player.Job;
            Position = new Vector2(15, 57);
            LoadContent();
        }

        public void LoadContent()
        {
            frameTexture = Content.Load<Texture2D>("job_preview_frame");
            LoadJobTexture();
        }
        private void LoadJobTexture()
        {
            jobTexture = Content.Load<Texture2D>(job.TextureName(player.Sex));
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Draw(frameTexture, Position, Color.White);

            Vector2 position = new Vector2(
                Position.X + frameTexture.Width / 2 - Font.MeasureString(JobName).X / 2,
                Position.Y + 8);
            SpriteBatch.DrawString(Font, JobName, position, Color.Black);

            position = new Vector2(
                Position.X + frameTexture.Width / 2 - jobTexture.Width / 2,
                position.Y + 100 - jobTexture.Height);
            SpriteBatch.Draw(jobTexture, position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            
            position = new Vector2(Position.X + 8, position.Y + jobTexture.Height + 10);
            DrawLines(JobDescription, position);

            position = new Vector2(position.X, 210);
            SpriteBatch.DrawString(Font, CommandName, position, Color.Black);

            position.Y += 12;
            DrawLines(CommandDescription, position);

            position.Y += 30;
            SpriteBatch.DrawString(Font, "HP " + job.MaxHp.ToString(), position, Color.Black);
            position.X += 50;
            SpriteBatch.DrawString(Font, "MP " + job.MaxMp.ToString(), position, Color.Black);

            position.X -= 50;
            position.Y += 36;
            SpriteBatch.DrawString(Font, "Exp " + player.Exp(job).ToString() + " / " + job.Exp.ToString(), position, Color.Black);
        }

        private void DrawLines(string str, Vector2 position)
        {
            int length = 7;
            for (int i = 0; i < str.Length; i += length)
            {
                int sublength = i + length < str.Length ? length : str.Length - i;
                string line = str.Substring(i, sublength);
                SpriteBatch.DrawString(Font, line, position, Color.Black);
                position.Y += 12;
            }
        }


        protected string JobName
        {
            get { return Message("Job", job.Name, "Name"); }
        }
        protected string JobDescription
        {
            get { return Message("Job", job.Name, "Description"); }
        }

        protected string CommandName
        {
            get { return Message("CommandMenu", "Prefix") + Message("Command", job.Command.Name, "Name"); }
        }
        protected string CommandDescription
        {
            get { return Message("Command", job.Command.Name, "Description"); }
        }

    }
}
