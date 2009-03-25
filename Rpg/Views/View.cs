﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    class View
    {

        protected GameScreen Screen
        {
            get { return screen; }
        }
        GameScreen screen;

        protected ContentManager Content
        {
            get { return screen.ScreenManager.Game.Content; }
        }

        protected SpriteBatch SpriteBatch
        {
            get { return screen.ScreenManager.SpriteBatch; }
        }

        protected SpriteFont Font
        {
            get { return screen.ScreenManager.Font; }
        }


        public View(GameScreen screen)
        {
            this.screen = screen;
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(GameTime gameTime)
        {
        }


        public string Message(string group, string name)
        {
            return screen.ScreenManager.Message(group, name);
        }

    }
}
