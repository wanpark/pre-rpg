using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    class JobSelectView : View
    {

        private Texture2D cursorTexture;

        private JobTreeItemView selectedItem;

        public JobSelectView(GameScreen screen)
            : base(screen)
        {
            LoadContent();
        }

        public void LoadContent()
        {
            cursorTexture = Content.Load<Texture2D>("cursor");
        }

        public override void Draw(GameTime gameTime)
        {
            if (selectedItem != null)
            {
                Vector2 position = new Vector2(selectedItem.Position.X - 12, selectedItem.Position.Y + 8);
                SpriteBatch.Draw(cursorTexture, position, null, Color.White);
            }
        }

        public void Select(JobTreeItemView item)
        {
            selectedItem = item;
        }

    }
}
