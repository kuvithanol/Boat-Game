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

            MasterGame.iSlatedForCreation.Add(new Projectile(positionalCoord, positionalAngle, 1, 1, CustomMath.AngleToVector(positionalAngle), this));
        }
    }
}
