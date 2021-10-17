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
            spriteWidth = spriteSheet.Height;
            spriteSheetLength = spriteSheet.Width / spriteSheet.Height;
        }

        public override void Update(float deltaSeconds)
        {
            base.Update(deltaSeconds);

            if (Keyboard.GetState().IsKeyDown(Keys.W)) positionalMomentum = Vector2.Lerp(positionalMomentum, CustomMath.AngleToVector(positionalAngle) * deltaSpeed, 0.06f);
            else if (Keyboard.GetState().IsKeyDown(Keys.S)) positionalMomentum = Vector2.Lerp(positionalMomentum, CustomMath.AngleToVector(positionalAngle) * -deltaSpeed, 0.06f);
            else positionalMomentum = Vector2.Lerp(positionalMomentum, new Vector2(0, 0), 0.08f);

            if (Keyboard.GetState().IsKeyDown(Keys.D) && !Keyboard.GetState().IsKeyDown(Keys.A))
                angularMomentum = MathHelper.Lerp(angularMomentum, deltaTurnSpeed, 0.06f);
            else if (Keyboard.GetState().IsKeyDown(Keys.A) && !Keyboard.GetState().IsKeyDown(Keys.D))
                angularMomentum = MathHelper.Lerp(angularMomentum, -deltaTurnSpeed, 0.06f);
            else angularMomentum = MathHelper.Lerp(angularMomentum, 0, 0.08f);

            fireDelay += deltaSeconds;
            if(fireDelay > fireRate) fireDelay = fireRate;

            if (Keyboard.GetState().IsKeyDown(Keys.K))
            {
                if (fireDelay == fireRate)
                {
                    Attack();
                    fireDelay = 0;
                }
            }
        }

        public override void Attack()
        {
            base.Attack();
        }

        protected override void updateSprite()
        {
            spriteIndex = (int)((positionalAngle / MathHelper.Pi + .5f) % 2 * spriteSheetLength) % spriteSheetLength;

            flipSprite = (positionalAngle / MathHelper.Pi + .5f) % 2 > 1;

            if (flipSprite)
            {
                spriteIndex = (spriteSheetLength-1) - spriteIndex;
            }

            sourceRect = new Rectangle(new Point(0 + spriteIndex*spriteWidth, 0), new Point(spriteWidth, spriteWidth));
        }
    }
}
