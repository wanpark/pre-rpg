using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Rpg
{
    class ControllerManager
    {

        public Controller Controller
        {
            set
            {
                controller.End();
                controller = value;
                controller.Begin();
            }
        }
        private Controller controller;

        public DanjonScreen Screen
        {
            get { return screen; }
        }
        private DanjonScreen screen;

        public ActionScheduler Scheduler
        {
            get { return scheduler; }
        }
        private ActionScheduler scheduler;


        public ControllerManager(DanjonScreen screen)
        {
            this.screen = screen;
            scheduler = new ActionScheduler();
            controller = new EmptyController(this);
        }

        public void HandleInput(InputState input)
        {
            controller.HandleInput(input);
        }

        public void Update(GameTime gameTime)
        {
            scheduler.Update(gameTime);
            controller.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            controller.Draw(gameTime);
        }

    }
}
