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

        protected ViewManager ViewManager
        {
            get { return Screen.ViewManager; }
        }
        protected ModelManager ModelManager
        {
            get { return Screen.ModelManager; }
        }


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


        public void PerformCommand(Command command)
        {
            ModelManager.PerformCommand(command);

            // いろいろ判定

            if (ModelManager.IsBattleEnd())
            {
                if (ModelManager.IsWin())
                {
                    Scheduler.Add(delegate()
                    {
                        Controller = new LeaveController(this);
                    }, 0.5f);
                }
                else if (ModelManager.IsLoose())
                {
                    Controller = new GameOverController(this);
                }
            }
            else
            {
                PerformNext();
            }
        }

        public void PerformNext()
        {
            Character nextPerformer = ModelManager.NextPerformer();
            if (nextPerformer is Player)
            {
                Controller = new CommandSelectController(this, (Player)nextPerformer);
            }
            else
            {
                Controller = new EnemyCommandPerformController(this, (Enemy)nextPerformer);
            }
        }

    }
}
