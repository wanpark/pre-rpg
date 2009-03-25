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

        public List<FieldPlayerView> FieldPlayers
        {
            get { return fieldPlayers; }
        }
        private List<FieldPlayerView> fieldPlayers;

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

        public ForwardArrowView ForwardArrow
        {
            get { return forwardArrow; }
        }
        private ForwardArrowView forwardArrow;


        public ViewManager(DanjonScreen screen)
        {
            this.screen = screen;
        }

        public void LoadContent()
        {
            CreatePlayers();
            forwardArrow = new ForwardArrowView(Screen);
        }

        private void CreatePlayers()
        {
            fieldPlayers = new List<FieldPlayerView>();
            players = new List<PlayerView>();
            int y = 100;
            foreach (Player player in ModelManager.Players)
            {
                fieldPlayers.Add(new FieldPlayerView(player, Screen, new Vector2(320, y)));
                players.Add(new PlayerView(player, Screen, new Vector2(320, y)));
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
                enemies.Add(new EnemyView(enemy, Screen, new Vector2(80, y)));
                y += 100;
            }
        }

    }
}
