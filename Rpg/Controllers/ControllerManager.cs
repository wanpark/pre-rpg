﻿using System;
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
            get { return controller; }
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
            CommandEffectView effect = new CommandEffectView(Screen, command, ViewManager.ViewForCharacter(command.Target));
            effect.EffectEnd += effectEnd;
            controller.Views.Add(effect);
        }

        private void effectEnd(object sender, EventArgs args)
        {
            CommandEffectView effect = (CommandEffectView)sender;
            effect.EffectEnd -= effectEnd;

            ModelManager.PerformCommand(effect.Command);

            if (ModelManager.IsBattleEnd())
            {
                Controller = new EndBattleController(this);
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
