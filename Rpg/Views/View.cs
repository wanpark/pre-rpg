using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    class View
    {

        public virtual Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        private Vector2 position;

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
        private bool visible;

        public GameScreen Screen
        {
            get { return screen; }
        }
        GameScreen screen;

        private List<Effect> effects;

        public ContentManager Content
        {
            get { return screen.ScreenManager.Game.Content; }
        }

        public SpriteBatch SpriteBatch
        {
            get { return screen.ScreenManager.SpriteBatch; }
        }

        public SpriteFont Font
        {
            get { return screen.ScreenManager.Font; }
        }


        public View(GameScreen screen)
            : this(screen, Vector2.Zero)
        {
        }

        public View(GameScreen screen, Vector2 position)
        {
            this.screen = screen;
            this.position = position;
            this.visible = true;

            effects = new List<Effect>();
        }

        public virtual void Update(GameTime gameTime)
        {
            effects.ForEach(effect => effect.Update(gameTime));
        }

        public virtual void Draw(GameTime gameTime)
        {
        }

        public void AddEffect(Effect effect)
        {
            effects.Add(effect);
        }

        public void RemoveEffect(Effect effect)
        {
            effects.Remove(effect);
        }

        public string Message(string group, string name)
        {
            return screen.ScreenManager.Message(group, name);
        }

    }
}
