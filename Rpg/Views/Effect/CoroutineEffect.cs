using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    abstract class CoroutineEffect : Effect, ICoroutineUpdatable
    {

        public GameTime CurrentGameTime
        {
            get { return currentGameTime; }
        }
        private GameTime currentGameTime;


        public CoroutineEffect()
            : this(null)
        { }

        public CoroutineEffect(View view)
            : base(view)
        {
        }


        private IEnumerator<bool> update;

        public override void Update(GameTime gameTime)
        {
            currentGameTime = gameTime;

            if (update == null)
                update = UpdateCoroutine();

            if (!update.MoveNext())
            {
                View.RemoveEffect(this);
            }
        }

        public abstract IEnumerator<bool> UpdateCoroutine();

    }
}
