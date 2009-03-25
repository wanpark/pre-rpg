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
        private CharacterView currentView;

        public PlayerView(Player player, GameScreen screen, Vector2 position)
            : base(player, position, screen)
        {
            fieldView = new FieldPlayerView(player, screen, position);
            battleView = new BattlePlayerView(player, screen, position);

            fieldView.TransformEnd += onTransformEnd;

            currentView = fieldView;

            player.Died += onDied;
        }

        public override void Update(GameTime gameTime)
        {
            currentView.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            currentView.Draw(gameTime);
            base.Draw(gameTime);
        }

        public void Walk()
        {
            fieldView.Walk();
            currentView = fieldView;
        }

        public void Stop()
        {
            fieldView.Stop();
            currentView = fieldView;
        }

        public void Transform()
        {
            if (currentView == battleView || fieldView.IsTransforming())
                return;

            fieldView.Transform();
            currentView = fieldView;
        }

        public bool IsTransforming()
        {
            return currentView == fieldView && fieldView.IsTransforming();
        }
        public bool IsTransformed()
        {
            return currentView == battleView;
        }

        private void onTransformEnd(object sender, EventArgs args)
        {
            currentView = battleView;
        }

        public void Detransform()
        {
            if (currentView == fieldView)
                return;

            fieldView.Appear();
            currentView = fieldView;
        }

        public bool IsDetransformimg()
        {
            return currentView == fieldView && fieldView.IsAppearing();
        }

        public bool IsDetransformed()
        {
            return currentView == fieldView && !fieldView.IsAppearing() && !fieldView.IsTransforming();
        }

        private void onDied(object sender, EventArgs args)
        {
            //Detransform();
        }

        public override void Blink()
        {
            currentView.Blink();
        }

    }
}
