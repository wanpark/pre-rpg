using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    abstract class Effect
    {

        public View View
        {
            get { return view; }
            set { view = value; }
        }
        private View view;


        public Effect()
            : this(null)
        { }

        public Effect(View view)
        {
            this.view = view;
        }

        public abstract void Update(GameTime gameTime);

    }
}
