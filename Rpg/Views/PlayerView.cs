using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    class PlayerView : JobCharacterView
    {

        public PlayerView(Player player, GameScreen screen, Vector2 position)
            : base(player, screen, position, true)
        {
        }

        
    }
}
