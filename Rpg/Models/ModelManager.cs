using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{
    class ModelManager
    {

        public static string[] PLAYER_NAMES;
        public static string[] PLAYER_JOB_NAMES;

        static ModelManager()
        {
            PLAYER_NAMES = new string[3] { "boy", "girl", "ninja" };
            PLAYER_JOB_NAMES = new string[3] { "boy", "girl", "ninja" };
        }


        public List<Player> Players
        {
            get { return players; }
        }
        private List<Player> players;

        public List<Enemy> Enemies
        {
            get { return enemies; }
        }
        private List<Enemy> enemies;

        public ModelManager()
        {
            players = new List<Player>();
            players.Add(new Player("boy", Sex.Male, new Villager()));
            players.Add(new Player("girl", Sex.Female, new Villager()));
            players.Add(new Player("ninja", Sex.Male, new Villager()));
        }


        public List<Enemy> CreateEnemies()
        {
            enemies = new List<Enemy>();
            enemies.Add(new Enemy(new Job("witch")));
            enemies.Add(new Enemy(new Job("witch")));
            enemies.Add(new Enemy(new Job("witch")));
            return enemies;
        }
    }
}
