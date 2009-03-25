using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    class GameOverController : Controller
    {

        public GameOverController(ControllerManager controllerManager)
            : base(controllerManager)
        {
            Views = new List<View>();
            foreach (View view in ViewManager.Characters)
            {
                Views.Add(view);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            SpriteBatch batch = Screen.ScreenManager.SpriteBatch;
            batch.Begin();
            batch.DrawString(Screen.ScreenManager.Font, "Game Over", new Vector2(180, 160), Color.Black);
            batch.End();
        }

    }
}
