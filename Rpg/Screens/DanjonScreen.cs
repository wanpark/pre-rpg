using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    class DanjonScreen : GameScreen
    {

        public ViewManager ViewManager
        {
            get { return viewManager; }
        }
        private ViewManager viewManager;

        public ModelManager ModelManager
        {
            get { return modelManager; }
        }
        private ModelManager modelManager;

        private ControllerManager controllerManager;

        

        public DanjonScreen()
            : base("Danjon")
        {
            
        }

        public override void LoadContent() {
            JobManager.Instance.LoadContent(ScreenManager.Game.Content);
            modelManager = ModelManager.Instance;
            viewManager = new ViewManager(this);
            viewManager.LoadContent();
            controllerManager = new ControllerManager(this);
            controllerManager.Controller = new StandController(controllerManager);
        }



        /// <summary>
        /// Updates the loading screen.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            controllerManager.Update(gameTime);
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void HandleInput(InputState input)
        {
            controllerManager.HandleInput(input);
            base.HandleInput(input);
        }


        /// <summary>
        /// Draws the loading screen.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            controllerManager.Draw(gameTime);
            base.Draw(gameTime);
        }

    }
}
