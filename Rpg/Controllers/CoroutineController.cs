using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    abstract class CoroutineController : Controller, ICoroutineUpdatable
    {

        private IEnumerator<bool> update;

        public GameTime CurrentGameTime
        {
            get { return currentGameTime; }
        }
        private GameTime currentGameTime;

        public CoroutineController(ControllerManager controllerManager)
            : base(controllerManager)
        {
        }

        public override void Begin()
        {
            base.Begin();
            update = UpdateCoroutine();
        }

        public override void Update(GameTime gameTime)
        {
            currentGameTime = gameTime;
            update.MoveNext();
 
            base.Update(gameTime);
        }

        public abstract IEnumerator<bool> UpdateCoroutine();

    }

}
