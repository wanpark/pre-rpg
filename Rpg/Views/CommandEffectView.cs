using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    class CommandEffectView : View
    {

        const float TIME_PER_FRAME = 0.1f;

        public Command Command
        {
            get { return command; }
        }
        private Command command;

        private CharacterView characterView;
        private float elapsed;
        private Vector2 originPosition;
        private bool active;

        public event EventHandler EffectEnd;

        public CommandEffectView(GameScreen screen, Command command, CharacterView characterView)
            : base(screen)
        {
            this.command = command;
            this.characterView = characterView;

            originPosition = characterView.Position;
            int diff = (command.Target is Player) ? 10 : -10;
            characterView.Position = new Vector2(originPosition.X + diff, originPosition.Y);
            elapsed = 0;
            active = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (!active)
                return;

            elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsed >= TIME_PER_FRAME * 2)
            {
                active = false;
                if (EffectEnd != null)
                {
                    EffectEnd(this, EventArgs.Empty);
                }
            }
            else if (elapsed >= TIME_PER_FRAME)
            {
                characterView.Position = originPosition;
            }

            base.Update(gameTime);
        }

        
    }
}
