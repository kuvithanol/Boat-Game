using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace boatgame
{
    class Player : Boat
    {
        public Player(Vector2 Position, float Angle) : base(Position, Angle)
        {
            hitzones.Add(new Hitzone(50, Position));
            spriteSheet = MasterGame.boatSheet;
            projectileSpeed = 1f;
            speed *= 1.5f;
            projectileSpeed *= 5f;
            fireRate = 0.15f;
        }

        public override void Update(float deltaSeconds)
        {
            base.Update(deltaSeconds);

            if (Keyboard.GetState().IsKeyDown(Keys.W) && !Keyboard.GetState().IsKeyDown(Keys.S)) positionalMomentum = Vector2.Lerp(positionalMomentum, CustomMath.AngleToVector(positionalAngle) * deltaSpeed, 0.05f);
            else if (Keyboard.GetState().IsKeyDown(Keys.S) && !Keyboard.GetState().IsKeyDown(Keys.W)) positionalMomentum = Vector2.Lerp(positionalMomentum, CustomMath.AngleToVector(positionalAngle) * -deltaSpeed, 0.05f);
            else positionalMomentum = Vector2.Lerp(positionalMomentum, new Vector2(0, 0), 0.06f);

            if (Keyboard.GetState().IsKeyDown(Keys.D) && !Keyboard.GetState().IsKeyDown(Keys.A)) angularMomentum = MathHelper.Lerp(angularMomentum, deltaTurnSpeed, 0.05f);
            else if (Keyboard.GetState().IsKeyDown(Keys.A) && !Keyboard.GetState().IsKeyDown(Keys.D)) angularMomentum = MathHelper.Lerp(angularMomentum, -deltaTurnSpeed, 0.05f);
            else angularMomentum = MathHelper.Lerp(angularMomentum, 0, 0.06f);

            fireDelay += deltaSeconds;
            if(fireDelay > fireRate) fireDelay = fireRate;

            if (Keyboard.GetState().IsKeyDown(Keys.K))
            {
                if (fireDelay == fireRate)
                {
                    Attack(-MathHelper.Pi / 2.5f);
                    fireDelay = 0;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.L))
            {
                if (fireDelay == fireRate)
                {
                    Attack(MathHelper.Pi / 2.5f);
                    fireDelay = 0;
                }
            }
        }

        protected override void Attack(float angle)
        {
            Projectile proj = new Projectile(positionalCoord - CustomMath.AngleToVector(positionalAngle) * 10, angle + positionalAngle, pierce, projectileDamage, projectileSpeed * CustomMath.AngleToVector(angle + positionalAngle), 20, this, 0.15f);
            positionalMomentum -= CustomMath.AngleToVector(angle + positionalAngle) * projectileSpeed * proj.mass;
        }
    }
}
