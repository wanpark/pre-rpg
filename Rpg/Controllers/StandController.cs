using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Rpg
{
    class StandController : CharacterSelectController
    {

        public StandController(ControllerManager controllerManager)
            : base(controllerManager, CharacterSelectType.OnePlayer)
        {
            AddViews(ViewManager.Players);
            Views.Add(new ForwardArrowView(Screen));
            Selected += showJobMenu;

            ModelManager.ResetPlayerStatus();
            SelectCharacter(ModelManager.Players[0]);
        }

        public override void Begin()
        {
            base.Begin();
            ViewManager.Players.ForEach(player => player.Stop());
        }

        public override void HandleInput(InputState input) {
            
            if (input.IsNewKeyPress(Keys.Left))
            {
                walk();
            }
            base.HandleInput(input);
        }

        private void walk()
        {
            ViewManager.Players.ForEach(player => player.Walk());
            ControllerManager.Controller = new EncounterController(ControllerManager);
        }

        private void showJobMenu(object sender, EventArgs args)
        {
            ControllerManager.Controller = new JobMenuController(ControllerManager, (Player)SelectedCharacter(), this);
        }

    }
}
