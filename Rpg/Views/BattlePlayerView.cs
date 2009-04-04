using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    class BattlePlayerView : JobCharacterView
    {

        public Player Player
        {
            get { return (Player)Character; }
        }

        public BattlePlayerView(Player player, GameScreen screen, Vector2 position)
            : base(player, screen, position, true)
        {
            player.JobMaster += onJobMaster;
        }

        private void onJobMaster(object sender, EventArgs args)
        {
            Vector2 position = new Vector2(Position.X - 20, Position.Y - 80);
            AddEffect(new LabelEffect(this, "Master!", position, Color.Black));
        }
        
    }
}
