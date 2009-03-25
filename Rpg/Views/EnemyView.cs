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

        // 出現時間
        const float APPEAR_DURATION = 0.2f;

        public EnemyView(Enemy enemy, GameScreen screen, Vector2 position)
            : base(enemy, screen, position, false)
        {
        }

        
        public void Appear()
        {
            AddEffect(new MoveEffect(new Vector2(-Texture.Width / 2, Position.Y), Position, APPEAR_DURATION, this));
        }

        public void Disappear()
        {
            AddEffect(new MoveEffect(Position, new Vector2(-Texture.Width / 2, Position.Y), APPEAR_DURATION, this));
        }

    }
}
