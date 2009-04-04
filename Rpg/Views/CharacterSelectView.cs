using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    class CharacterSelectView : View
    {

        private Texture2D cursorTexture;

        private HashSet<CharacterView> characterViews;

        public CharacterSelectView(GameScreen screen)
            : base(screen)
        {
            ClearSelection();
            LoadContent();
        }

        public void LoadContent()
        {
            cursorTexture = Content.Load<Texture2D>("cursor");
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (CharacterView view in characterViews)
            {
                SpriteBatch.Draw(cursorTexture, view.CursorPosition, null, Color.White);
            }
        }

        public void AddSelection(CharacterView view)
        {
            characterViews.Add(view);
        }

        public void RemoveSelection(CharacterView view)
        {
            characterViews.Remove(view);
        }

        public void ClearSelection()
        {
            characterViews = new HashSet<CharacterView>();
        }
    }
}
