using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    class CharacterView :View
    {
        public Character Character
        {
            get { return character; }
        }
        private Character character;

        public CharacterView(Character character, Vector2 position, GameScreen screen)
            : base(screen, position)
        {
            this.character = character;
        }


        // 点滅
        const float BLINK_DURATION = 0.1f;

        public virtual void Blink()
        {
            AddEffect(new BlinkEffect(BLINK_DURATION, this));
        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

    }
}
