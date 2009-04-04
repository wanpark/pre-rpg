using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    delegate void ItemHandler(JobTreeItemView item, int row, int col);

    class JobTreeView : View
    {

        private const int COLS = 3;

        public int Cols
        {
            get { return items.GetLength(1); }
        }

        public int Rows
        {
            get { return items.GetLength(0); }
        }

        private JobTreeItemView[,] items;
        private Dictionary<Job, JobTreeItemView> itemsForJob;

        public JobTreeView(GameScreen screen, List<Job> jobs)
            : base(screen)
        {
            items = new JobTreeItemView[jobs.Count/COLS+1, COLS];
            itemsForJob = new Dictionary<Job, JobTreeItemView>();

            int i = 0;
            for (int row = 0; row < items.GetLength(0); row++)
            {
                for (int col = 0; col < items.GetLength(1); col++)
                {
                    items[row, col] = itemsForJob[jobs[i]] = new JobTreeItemView(Screen, jobs[i], row, col);
                    if (++i >= jobs.Count)
                        goto END_CREAETE_ITEM;
                }
            }
            END_CREAETE_ITEM: ;
        }

        public override void Draw(GameTime gameTime)
        {
            TraverseItems((item, row, col) => item.Draw(gameTime));
        }

        private void TraverseItems(ItemHandler handler)
        {
            for (int row = 0; row < items.GetLength(0); row++)
            {
                for (int col = 0; col < items.GetLength(1); col++)
                {
                    if (items[row, col] != null)
                        handler(items[row, col], row, col);
                }
            }
        }

        public JobTreeItemView ItemView(Job job)
        {
            return itemsForJob[job];
        }

        public JobTreeItemView ItemView(int row, int col)
        {
            return items[row, col];
        }

    }
}
