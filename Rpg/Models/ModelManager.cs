using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{

    public enum Party
    {
        Players,
        Enemies
    }

    class ModelManager
    {

        private Character performer;

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

        public List<Character> Characters
        {
            get
            {
                List<Character> characters = new List<Character>();
                foreach (Character player in players)
                    characters.Add(player);
                foreach (Character enemy in enemies)
                    characters.Add(enemy);
                return characters;
            }
        }

        public ModelManager()
        {
            players = new List<Player>();
            players.Add(new Player("boy", Sex.Male, new Villager()));
            players.Add(new Player("girl", Sex.Female, new Villager()));
            players.Add(new Player("ninja", Sex.Male, new Villager()));
        }

        public void ResetPlayerStatus()
        {
            foreach (Player player in players)
            {
                player.ResetStatus();
            }
        }

        public List<Enemy> CreateEnemies()
        {
            enemies = new List<Enemy>();
            enemies.Add(new Enemy(new Job("witch")));
            enemies.Add(new Enemy(new Job("witch")));
            enemies.Add(new Enemy(new Job("witch")));
            return enemies;
        }

        public Character NextPerformer()
        {
            List<Character> characters = Characters;
            int current = performer != null ? characters.IndexOf(performer) : characters.Count - 1;
            for (int i = 1; i < characters.Count; i++)
            {
                Character character = characters[(current + i) % characters.Count];
                if (character.Alive)
                    return performer = character;
            }
            return null;
        }

        public void PerformCommand(Command command)
        {
            command.Target.Die();
        }

        public Command CreateEnemyCommand(Enemy enemy)
        {
            Command command = new AttackCommand(enemy);
            command.Target = players.Find(delegate(Player player) { return player.Alive; });
            return command;
        }

        public bool IsBattleEnd()
        {
            return IsWin() || IsLose();
        }
        public bool IsWin()
        {
            return enemies.All(delegate(Enemy enemy) { return !enemy.Alive; });
        }
        public bool IsLose()
        {
            return players.All(delegate(Player player) { return !player.Alive; });
        }
    }
}
