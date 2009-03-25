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

        public virtual Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        private Vector2 position;

        public CharacterView(Character character, Vector2 position, GameScreen screen)
            : base(screen)
        {
            this.character = character;
            this.position = position;
        }

    }
}
