using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    class PlayerView : CharacterView
    {

        public Player Player
        {
            get { return (Player)Character; }
        }

        public override Vector2 Position
        {
            get { return currentView.Position; }
            set { currentView.Position = value; }
        }

        public override Vector2 CharacterPosition
        {
            get { return currentView.CharacterPosition; }
            set { currentView.CharacterPosition = value; }
        }

        public override Vector2 CursorPosition
        {
            get { return currentView.CursorPosition; }
        }

        public override bool StatusVisible
        {
            get { return battleView.StatusVisible; }
            set { battleView.StatusVisible = value; }
        }

        public event EventHandler TransformEnd
        {
            add { fieldView.TransformEnd += value; }
            remove { fieldView.TransformEnd -= value; }
        }

        public event EventHandler DetransformEnd
        {
            add { fieldView.AppearEnd += value; }
            remove { fieldView.AppearEnd -= value; }
        }

        private FieldPlayerView fieldView;
        private BattlePlayerView battleView;

        private CharacterView CurrentView
        {
            get { return currentView; }
            set
            {
                if (currentView != null) currentView.ClearEffects();
                currentView = value;
            }
        }
        private CharacterView currentView;

        public PlayerView(Player player, GameScreen screen, Vector2 position)
            : base(player, position, screen)
        {
            fieldView = new FieldPlayerView(player, screen, position);
            battleView = new BattlePlayerView(player, screen, position);

            fieldView.TransformEnd += onTransformEnd;

            CurrentView = fieldView;

            player.Died += onDied;
        }

        public override void Update(GameTime gameTime)
        {
            CurrentView.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            CurrentView.Draw(gameTime);
            base.Draw(gameTime);
        }

        public void Walk()
        {
            fieldView.Walk();
            CurrentView = fieldView;
        }

        public void Stop()
        {
            fieldView.Stop();
            CurrentView = fieldView;
        }

        public void Transform()
        {
            if (CurrentView == battleView || fieldView.IsTransforming())
                return;

            fieldView.Transform();
            CurrentView = fieldView;
        }

        public bool IsTransforming()
        {
            return CurrentView == fieldView && fieldView.IsTransforming();
        }
        public bool IsTransformed()
        {
            return CurrentView == battleView;
        }

        private void onTransformEnd(object sender, EventArgs args)
        {
            CurrentView = battleView;
        }

        public void Detransform()
        {
            if (CurrentView == fieldView)
                return;

            fieldView.Appear();
            CurrentView = fieldView;
        }

        public bool IsDetransformimg()
        {
            return CurrentView == fieldView && fieldView.IsAppearing();
        }

        public bool IsDetransformed()
        {
            return CurrentView == fieldView && !fieldView.IsAppearing() && !fieldView.IsTransforming();
        }

        private void onDied(object sender, EventArgs args)
        {
            //Detransform();
        }

    }
}
