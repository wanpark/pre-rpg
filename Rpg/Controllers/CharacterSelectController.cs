using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Rpg
{

    public enum CharacterSelectType
    {
        One,
        OnePlayer
    }

    class CharacterSelectController : Controller
    {

        public event EventHandler Selected;
        public event EventHandler Cancelled;

        private CharacterSelectType selectType;
        private Party selectedParty;
        private int selectedIndex;

        protected CharacterSelectView SelectView
        {
            get { return selectView; }

        }
        private CharacterSelectView selectView;

        public CharacterSelectController(ControllerManager controllerManager, CharacterSelectType selectType)
            : base(controllerManager)
        {
            this.selectType = selectType;
            selectView = new CharacterSelectView(Screen);
            Views.Add(selectView);
        }

        public override void HandleInput(InputState input)
        {
            base.HandleInput(input);

            if (input.IsNewKeyPress(Keys.Up))
            {
                SelectPrevious();
            }
            if (input.IsNewKeyPress(Keys.Down))
            {
                SelectNext();
            }
            if (input.IsNewKeyPress(Keys.Left) || input.IsNewKeyPress(Keys.Right))
            {
                SelectOtherParty();
            }

            if (input.IsNewKeyPress(Keys.X))
            {
                OnCommandSelected();
            }
            else if (input.IsNewKeyPress(Keys.Z))
            {
                OnCancelled();
            }
        }

        public void SelectCharacter(Character character)
        {
            selectedParty = character.Party;
            selectedIndex = SelectedPartyCharacters().IndexOf(character);
            ValidateSelection(true);
        }

        public void SelectNext()
        {
            ++selectedIndex;
            ValidateSelection(true);
        }
        public void SelectPrevious()
        {
            --selectedIndex;
            ValidateSelection(false);
        }
        public void SelectOtherParty()
        {
            if (selectType != CharacterSelectType.One)
                return;
            selectedParty = selectedParty == Party.Player ? Party.Enemy : Party.Player;
            ValidateSelection(true);
        }

        private void ValidateSelection(bool skipForward)
        {
            List<Character> characters = SelectedPartyCharacters();
            selectedIndex = (selectedIndex + characters.Count) % characters.Count;
            while (!characters[selectedIndex].Alive)
            {
                selectedIndex = (selectedIndex + (skipForward ? 1 : -1) + characters.Count) % characters.Count;
            }
            SetViewSelection();
        }

        private void SetViewSelection()
        {
            selectView.ClearSelection();
            selectView.AddSelection(ViewManager.ViewForCharacter(SelectedCharacter()));
        }

        public Character SelectedCharacter()
        {
            return SelectedPartyCharacters()[selectedIndex];
        }

        public List<Character> SelectedPartyCharacters()
        {
            return selectedParty == Party.Player ?
                ToCharacterList(ModelManager.Players) :
                ToCharacterList(ModelManager.Enemies);
        }

        private List<Character> ToCharacterList<T>(List<T> list)
            where T : Character
        {
            List<Character> result = new List<Character>();
            list.ForEach(character => result.Add(character));
            return result;
        }


        protected void OnCommandSelected()
        {
            if (Selected != null)
                Selected(this, EventArgs.Empty);
        }

        protected void OnCancelled()
        {
            if (Cancelled != null)
                Cancelled(this, EventArgs.Empty);
        }

    }
}
