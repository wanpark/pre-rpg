using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    class EnemyView : JobCharacterView
    {

        public Enemy Enemy
        {
            get { return (Enemy)Character; }
        }

        // 出現時
        const float APPEAR_DURATION = 0.2f;
        private bool appearing = false;
        private float appearElapsed;
        private Vector2 appearFrom;
        private Vector2 appearTo;

        // 点滅
        const float BLINK_DURATION = 0.1f;
        private bool blinking = false;
        private float blinkElapsed;

        public EnemyView(Enemy enemy, GameScreen screen, Vector2 position)
            : base(enemy, screen, position, false)
        {
        }

        
        public void Appear()
        {
            if (appearing)
                return;

            appearing = true;
            appearElapsed = 0.0f;
            appearTo = Position;
            Position = appearFrom = new Vector2(- Texture.Width / 2, Position.Y);
        }

        public void Blink()
        {
            if (blinking)
                return;

            blinking = true;
            blinkElapsed = 0.0f;
        }

        public override void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (appearing)
            {
                appearElapsed += elapsed;
                float ammount = appearElapsed / APPEAR_DURATION;
                if (ammount >= 1)
                {
                    appearing = false;
                    Position = appearTo;
                }
                else
                {
                    Position = Vector2.Lerp(appearFrom, appearTo, ammount);
                }
            }

            if (blinking)
            {
                blinkElapsed += elapsed;
                if (blinkElapsed >= BLINK_DURATION)
                {
                    blinking = false;
                }
            }

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            if (Enemy.Alive && !blinking)
            {
                base.Draw(gameTime);
            }
        }
    }
}
