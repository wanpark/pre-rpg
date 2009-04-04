using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{

    public enum Party
    {
        Player,
        Enemy
    }

    class ModelManager
    {

        public static ModelManager Instance
        {
            get { return Singleton<ModelManager>.Instance; }
        }

        private int performerIndex;

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

        private ModelManager()
        {
            players = new List<Player>();
            players.Add(new Player("boy", Sex.Male, JobManager.Instance.Job("Villager")));
            players.Add(new Player("girl", Sex.Female, JobManager.Instance.Job("Villager")));
            players.Add(new Player("ninja", Sex.Male, JobManager.Instance.Job("Villager")));

            performerIndex = 5;
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
            enemies.Add(new Enemy(JobManager.Instance.Job("Witch")));
            enemies.Add(new Enemy(JobManager.Instance.Job("Witch")));
            enemies.Add(new Enemy(JobManager.Instance.Job("Witch")));
            return enemies;
        }

        public void SetupBattle()
        {
            Characters.ForEach(character => character.ResetStatus());
        }

        private void FinalizeBattle()
        {
            if (IsWin())
            {
                foreach (Player player in players)
                {
                    if (player.Alive)
                        player.AddExp();
                }
            }

        }

        public Character NextPerformer()
        {
            List<Character> characters = Characters;
            for (int i = 1; i < characters.Count; i++)
            {
                int index = (performerIndex + i) % characters.Count;
                Character character = characters[index];
                if (character.Alive)
                {
                    performerIndex = index;
                    return character;
                }
            }
            return null;
        }

        public Command CreateEnemyCommand(Enemy enemy)
        {
            Command command = (Command)enemy.Job.Command.Clone();
            command.Performer = enemy;
            Player target = null;
            do
            {
                target = players[new Random().Next(players.Count)];
            } while (!target.Alive);
            command.Target = target;
            return command;
        }

        public void PerformCommand(Command command)
        {
            command.Perform();
            if (IsBattleEnd())
                FinalizeBattle();
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
