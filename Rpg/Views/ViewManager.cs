using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    class ViewManager
    {

        public DanjonScreen Screen
        {
            get { return screen; }
        }
        DanjonScreen screen;

        public ModelManager ModelManager
        {
            get { return screen.ModelManager; }
        }

        public List<PlayerView> Players
        {
            get { return players; }
        }
        private List<PlayerView> players;

        public List<EnemyView> Enemies
        {
            get { return enemies; }
        }
        private List<EnemyView> enemies;

        public List<CharacterView> Characters
        {
            get
            {
                List<CharacterView> characters = new List<CharacterView>();
                foreach (CharacterView player in players)
                    characters.Add(player);
                foreach (CharacterView enemy in enemies)
                    characters.Add(enemy);
                return characters;
            }
        }

        public ViewManager(DanjonScreen screen)
        {
            this.screen = screen;
        }

        public void LoadContent()
        {
            CreatePlayers();
            enemies = new List<EnemyView>();
        }

        private void CreatePlayers()
        {;
            players = new List<PlayerView>();
            int y = 100;
            foreach (Player player in ModelManager.Players)
            {
                players.Add(new PlayerView(player, Screen, new Vector2(300, y)));
                y += 100;
            }
        }

        public void CreateEnemies()
        {
            if (ModelManager.Enemies == null)
            {
                ModelManager.CreateEnemies();
            }

            enemies = new List<EnemyView>();
            int y = 100;
            foreach (Enemy enemy in ModelManager.Enemies)
            {
                enemies.Add(new EnemyView(enemy, Screen, new Vector2(100, y)));
                y += 100;
            }
        }


        public CharacterView ViewForCharacter(Character character)
        {
            return Characters.Find(delegate(CharacterView view) { return view.Character == character; });
        }

    }
}
