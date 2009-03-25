using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    class CommandTargetSelectView : View
    {

        private List<CharacterView> players;
        private List<CharacterView> enemies;
        private Texture2D cursorTexture;

        private Party selectedParty;
        private int selectedIndex;

        public CommandTargetSelectView(GameScreen screen, List<PlayerView> players, List<EnemyView> enemies)
            : base(screen)
        {
            this.players = new List<CharacterView>();
            foreach (CharacterView view in players)
            {
                this.players.Add(view);
            }
            this.enemies = new List<CharacterView>();
            foreach (CharacterView view in enemies)
            {
                this.enemies.Add(view);
            }

            selectedParty = Party.Enemies;
            selectedIndex = enemies.Count - 1;
            SelectNext();

            LoadContent();
        }

        public void LoadContent()
        {
            cursorTexture = Content.Load<Texture2D>("cursor");
        }

        public override void Draw(GameTime gameTime)
        {
            CharacterView view;
            if (selectedParty == Party.Players)
                view = players[selectedIndex];
            else
                view = enemies[selectedIndex];

            Vector2 cursorPosition = new Vector2(view.Position.X - 40, view.Position.Y - 40);
            SpriteBatch.Draw(cursorTexture, cursorPosition, null, Color.White);
        }

        public void SelectNext()
        {
            List<CharacterView> views = selectedPartyCharacterViews();
            while(!views[selectedIndex = ++selectedIndex % views.Count].Character.Alive);
        }
        public void SelectPrevious()
        {
            List<CharacterView> views = selectedPartyCharacterViews();
            while (!views[selectedIndex = (--selectedIndex + views.Count) % views.Count].Character.Alive) ;
        }
        public void SelectOtherParty()
        {
            selectedParty = selectedParty == Party.Players ? Party.Enemies : Party.Players;
            List<CharacterView> views = selectedPartyCharacterViews();
            if (selectedIndex >= views.Count)
            {
                selectedIndex = views.Count - 1;
            }
            if (!views[selectedIndex].Character.Alive)
            {
                SelectNext();
            }
        }

        public Character SelectedTarget()
        {
            return selectedPartyCharacterViews()[selectedIndex].Character;
        }

        private List<CharacterView> selectedPartyCharacterViews()
        {
            return selectedParty == Party.Players ? players : enemies;
        }
    }
}
