using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    class Controller
    {

        public HashSet<View> Views
        {
            get { return views; }
            protected set { views = value; }
        }
        private HashSet<View> views;

        protected DanjonScreen Screen
        {
            get { return controllerManager.Screen; }
        }

        protected ControllerManager ControllerManager
        {
            get { return controllerManager; }
        }
        private ControllerManager controllerManager;

        protected ViewManager ViewManager
        {
            get { return Screen.ViewManager; }
        }
        protected ModelManager ModelManager
        {
            get { return Screen.ModelManager; }
        }

        protected ActionScheduler Scheduler
        {
            get { return ControllerManager.Scheduler; }
        }


        public Controller(ControllerManager controllerManager)
        {
            this.controllerManager = controllerManager;
            views = new HashSet<View>();
        }

        public virtual void Begin() {}
        public virtual void End() { }
        public virtual void HandleInput(InputState input) {}


        public virtual void Update(GameTime gameTime)
        {
            foreach (View view in Views)
            {
                view.Update(gameTime);
            }
        }

        public virtual void Draw(GameTime gameTime)
        {
            Screen.ScreenManager.GraphicsDevice.Clear(ClearOptions.Target, Color.White, 0, 0);

            SpriteBatch batch = Screen.ScreenManager.SpriteBatch;
            batch.Begin();

            foreach (View view in Views)
            {
                view.Draw(gameTime);
            }

            batch.End();
        }

        public void AddViews<T>(ICollection<T> views)
            where T : View
        {
            foreach (T view in views)
            {
                Views.Add(view);
            }
        }

    }
}
