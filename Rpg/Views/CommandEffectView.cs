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

        private CharacterView target;
        private float elapsed;
        private Vector2 originPosition;
        private bool active;

        public event EventHandler EffectEnd;

        public CommandEffectView(GameScreen screen, Command command, ViewManager viewManager)
            : base(screen)
        {
            target = viewManager.Characters.Find(delegate(CharacterView view) { return view.Character == command.Target; });
            
            originPosition = target.Position;
            int diff = (command.Target is Player) ? 10 : -10;
            target.Position = new Vector2(originPosition.X + diff, originPosition.Y);
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
                target.Position = originPosition;
            }

            base.Update(gameTime);
        }

        
    }
}
