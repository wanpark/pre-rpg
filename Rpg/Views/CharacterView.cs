using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{
    abstract class CharacterView :View
    {
        public Character Character
        {
            get { return character; }
        }
        private Character character;

        public virtual Vector2 CharacterPosition
        {
            get { return characterPosition; }
            set { characterPosition = value; }
        }
        private Vector2 characterPosition;

        public abstract Vector2 CursorPosition
        {
            get;
        }

        public virtual bool StatusVisible
        {
            get { return statusVisible; }
            set { statusVisible = value; }
        }
        private bool statusVisible;


        public CharacterView(Character character, Vector2 position, GameScreen screen)
            : base(screen, position)
        {
            this.character = character;
            characterPosition = Vector2.Zero;
            statusVisible = false;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

    }
}
