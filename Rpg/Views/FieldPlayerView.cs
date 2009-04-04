using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    class FieldPlayerView : CharacterView
    {

        public override Vector2 CursorPosition
        {
            get { return new Vector2(Position.X - 25, Position.Y - 20); }
        }

        const float WALK_TIME_PER_FRAME = 0.2f;
        const float VANISH_TIME_PER_FRAME = 0.1f;

        const int WALK_FRAME = 4;
        const int VANISH_FRAME = 7;

        AnimatedTexture walkTexture;
        AnimatedTexture vanishTexture;
        AnimatedTexture appearTexture;
        AnimatedTexture currentTexture;

        public Player Player
        {
            get { return (Player)Character; }
        }

        public event EventHandler TransformEnd;
        public event EventHandler AppearEnd;

        public FieldPlayerView(Player player, GameScreen screen, Vector2 position)
            : base(player, position, screen)
        {
            LoadContent();
        }

        public void LoadContent()
        {
            walkTexture = new AnimatedTexture(Content, assetName("walk"), WALK_FRAME, WALK_TIME_PER_FRAME);
            vanishTexture = new AnimatedTexture(Content, assetName("vanish"), VANISH_FRAME, VANISH_TIME_PER_FRAME);
            appearTexture = new AnimatedTexture(Content, assetName("appear"), VANISH_FRAME, VANISH_TIME_PER_FRAME);
            currentTexture = walkTexture;

            vanishTexture.LoopEnd += onTransformEnd;
            appearTexture.LoopEnd += onAppearEnd;
        }

        private string assetName(string type)
        {
            return "Characters/" + Player.Name + "_" + type;
        }


        public void Walk()
        {
            walkTexture.Reset();
            walkTexture.Play(1);
            currentTexture = walkTexture;
        }

        public void Stop()
        {
            walkTexture.Stop();
            currentTexture = walkTexture;
        }

        public void Transform()
        {
            vanishTexture.Reset();
            vanishTexture.Play();
            currentTexture = vanishTexture;
        }

        private void onTransformEnd(object sender, EventArgs args)
        {
            Stop();
            if (TransformEnd != null)
                TransformEnd(this, args);
        }

        public bool IsTransforming()
        {
            return currentTexture == vanishTexture;
        }

        public void Appear()
        {
            appearTexture.Reset();
            appearTexture.Play();
            currentTexture = appearTexture;
        }

        private void onAppearEnd(object sender, EventArgs args)
        {
            Stop();
            if (AppearEnd != null)
                AppearEnd(this, args);
        }

        public bool IsAppearing()
        {
            return currentTexture == appearTexture;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            currentTexture.UpdateFrame(elapsed);
        }

        public override void Draw(GameTime gameTime)
        {
            if (!Visible) return;

            base.Draw(gameTime);

            currentTexture.DrawFrame(SpriteBatch, Position);
        }

    }
}
