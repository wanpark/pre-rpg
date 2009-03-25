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

        // 出現時
        const float APPEAR_DURATION = 0.2f;
        private bool appearing = false;
        private float appearElapsed;
        private Vector2 appearFrom;
        private Vector2 appearTo;

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

        public override void Update(GameTime gameTime)
        {
            if (appearing)
            {
                appearElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
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

            base.Update(gameTime);
        }
    }
}
