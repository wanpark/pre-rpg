using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Rpg
{

    class FieldPlayerView : View
    {

        const float WALK_TIME_PER_FRAME = 0.2f;
        const float VANISH_TIME_PER_FRAME = 0.1f;

        const int WALK_FRAME = 4;
        const int VANISH_FRAME = 7;

        public Player Player
        {
            get { return Player; }
        }
        Player player;

        public Vector2 Position
        {
            get { return position; }
        }
        Vector2 position;

        AnimatedTexture walkTexture;
        AnimatedTexture vanishTexture;
        AnimatedTexture appearTexture;
        AnimatedTexture currentTexture;

        public event EventHandler TransformEnd;
        public event EventHandler AppearEnd;

        public FieldPlayerView(Player player, GameScreen screen, Vector2 position) : base(screen)
        {
            this.player = player;
            this.position = position;

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
            return "Characters/" + player.Name + "_" + type;
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
            if (TransformEnd != null)
                TransformEnd(this, args);
        }

        public void Appear()
        {
            appearTexture.Reset();
            appearTexture.Play();
            currentTexture = appearTexture;
        }

        private void onAppearEnd(object sender, EventArgs args)
        {
            if (AppearEnd != null)
                AppearEnd(this, args);
        }

        public override void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            currentTexture.UpdateFrame(elapsed);
        }

        public override void Draw(GameTime gameTime)
        {
            currentTexture.DrawFrame(SpriteBatch, position);
        }

    }
}
