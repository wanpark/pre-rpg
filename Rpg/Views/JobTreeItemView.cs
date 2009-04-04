using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    class JobTreeItemView : View
    {

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        private bool selected;

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        private bool active;

        public Job Job
        {
            get { return job; }
        }
        private Job job;

        public int Row
        {
            get { return row; }
        }
        private int row;

        public int Col
        {
            get { return col; }
        }
        private int col;

        private Texture2D frameTexture;

        public JobTreeItemView(GameScreen screen, Job job, int row, int col)
            : base(screen)
        {
            this.job = job;
            this.row = row;
            this.col = col;
            Position = new Vector2(140 + col * 90, 57 + row * 20);
            LoadContent();

            selected = false;
            active = false;
        }

        public void LoadContent()
        {
            frameTexture = Content.Load<Texture2D>("job_tree_item_frame");
        }

        public override void Draw(GameTime gameTime)
        {
            if (Active)
            {
                SpriteBatch.Draw(frameTexture, Position, Color.White);
            }
            Vector2 position = new Vector2(Position.X + 8, Position.Y + 8);
            SpriteBatch.DrawString(Font, JobName, position, Color.Black);
        }


        protected string JobName
        {
            get { return Message("Job", job.Name, "Name"); }
        }

    }
}
