using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace boatgame
{
    class boatClass : PhysicalGameObject
    {
        public boatClass(Vector2 position, float angle) : base(position, angle)
        {
            texture = Game1.boat;

            hitzones.Add(new Hitzone(25, position + new Vector2(25,0)));

            hitzones.Add(new Hitzone(25, position + new Vector2(-25,0)));

            foreach(Hitzone hitzone in hitzones)
            {
                hitzone.position -= positionalCoord;
                CustomMath.V2Rotate(ref hitzone.position, angle);
                hitzone.position += positionalCoord;
            }
        }

        public override void Update(float deltaSeconds)
        {

            base.Update(deltaSeconds);

            deltaSpeed = deltaSeconds * speed;

            deltaTurnSpeed = deltaSeconds * turnSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.W)) positionalMomentum = Vector2.Lerp(positionalMomentum, CustomMath.AngleToVector(positionalAngle) * deltaSpeed, 0.06f);
            else if (Keyboard.GetState().IsKeyDown(Keys.S)) positionalMomentum = Vector2.Lerp(positionalMomentum, CustomMath.AngleToVector(positionalAngle) * -deltaSpeed, 0.06f);
            else positionalMomentum = Vector2.Lerp(positionalMomentum, new Vector2(0, 0), 0.08f);

            if (Keyboard.GetState().IsKeyDown(Keys.D) && !Keyboard.GetState().IsKeyDown(Keys.A))
                angularMomentum = MathHelper.Lerp(angularMomentum, deltaTurnSpeed, 0.06f);
            else if (Keyboard.GetState().IsKeyDown(Keys.A) && !Keyboard.GetState().IsKeyDown(Keys.D))
                angularMomentum = MathHelper.Lerp(angularMomentum, -deltaTurnSpeed, 0.06f);
            else angularMomentum = MathHelper.Lerp(angularMomentum, 0, 0.08f);
        }

        public override void Collide(PhysicalGameObject otherObject)
        {
            base.Collide(otherObject);
        }



        protected float turnSpeed = 5f; protected float deltaTurnSpeed = 0;
        public float speed = 150f; protected float deltaSpeed = 0;
    }
}
