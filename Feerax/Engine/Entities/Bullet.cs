﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feerax.Engine.Entities
{
    internal class Bullet : Entity
    {
        public static Texture2D BulletTexture = Feerax.Instance.Content.Load<Texture2D>("Game/Lasers/laserBlue01Flipped");
        public static int Speed = 1000;
        public Vector2 Velocity;

        public Bullet(Texture2D texture) : base(texture)
        {
        }

        public Bullet(Texture2D texture, SpriteBatch spriteBatch) : base(texture, spriteBatch)
        {
            Position = Vector2.One;
        }

        public override string Name { get; } = "Bullet";
        public Vector2 Start { get; set; }
        public Vector2 Point { get; set; }

        public override bool IsValid
            =>
                new Rectangle(0, 0, Feerax.Instance.GraphicsDevice.Viewport.Width,
                    Feerax.Instance.GraphicsDevice.Viewport.Height).Contains(Bounds);

        public void Initialize()
        {
            Position = Start;
            Velocity = -(Start - Point);
            Velocity.Normalize();
        }

        public override void Update(GameTime gameTime)
        {
            Position += Velocity*Speed*(float) gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(GameTime gameTime)
        {
            var real = Start - Point;
            var rotation = (float) Math.Atan2(real.Y, real.X);

            SpriteBatch.Draw(Texture, Position, null, null, null, rotation, null, null, SpriteEffects.FlipHorizontally);
        }
    }
}