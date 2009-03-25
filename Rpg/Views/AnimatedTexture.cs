using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Rpg
{
    class AnimatedTexture
    {
        // アニメーションを横に並べた texture
        private Texture2D texture;

        // 全フレーム数
        private int totalFrame;
        // 現在のフレーム
        private int frame;

        // 1フレームあたりの所要時間
        private float timePerFrame;

        // フレームを変更してからの経過時間
        private float totalElapsed;

        // 一時停止中か否か
        private bool paused;

        public event EventHandler LoopEnd;

        public AnimatedTexture(ContentManager content, string asset,
            int totalFrame, float timePerFrame)
        {
            this.texture = content.Load<Texture2D>(asset);
            this.totalFrame = totalFrame;
            this.timePerFrame = timePerFrame;

            frame = 0;
            totalElapsed = 0;
            paused = true;
        }

        public void UpdateFrame(float elapsed)
        {
            if (paused)
                return;
            totalElapsed += elapsed;
            while (totalElapsed > timePerFrame)
            {
                // Keep the Frame between 0 and the total frames, minus one.
                frame = ++frame % totalFrame;
                totalElapsed -= timePerFrame;

                if (frame == 0 && LoopEnd != null)
                {
                    LoopEnd(this, EventArgs.Empty);
                }
            }
        }

        public void DrawFrame(SpriteBatch batch, Vector2 position)
        {
            DrawFrame(batch, frame, position);
        }
        public void DrawFrame(SpriteBatch batch, int frame, Vector2 position)
        {
            int width = texture.Width / totalFrame;
            Rectangle sourceRect = new Rectangle(width * frame, 0, width, texture.Height);
            batch.Draw(texture, position, sourceRect, Color.White,
                0, new Vector2(width / 2, texture.Height), 1, SpriteEffects.None, 0);
        }


        public bool IsPaused
        {
            get { return paused; }
        }
        public void Reset()
        {
            frame = 0;
            totalElapsed = 0f;
        }
        public void Stop()
        {
            Pause();
            Reset();
        }
        public void Play()
        {
            paused = false;
        }
        public void Play(int frame)
        {
            this.frame = frame;
            Play();
        }
        public void Pause()
        {
            paused = true;
        }

    }
}
