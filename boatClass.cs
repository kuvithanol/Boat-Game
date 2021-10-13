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
            hitzones.Add(new Hitzone(25, position));

            hitzones.Add(new Hitzone(25, position + new Vector2(25,0)));

            hitzones.Add(new Hitzone(25, position + new Vector2(-25,0)));
        }

        public override void Update(float deltaSeconds)
        {

            Vector2 lastPos = posCoord;

            if (Keyboard.GetState().IsKeyDown(Keys.W))  momentum = Vector2.Lerp(momentum, CustomMath.AngleToVector(posAngle)*speed, 0.05f);
            else momentum = Vector2.Lerp(momentum, new Vector2(0, 0), 0.08f);

            if (Keyboard.GetState().IsKeyDown(Keys.A))
                posAngle += 1f * MathF.PI * deltaSeconds;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                posAngle -= 1f * MathF.PI * deltaSeconds;

            base.posCoord += momentum;

            Vector2 deltaPos = Vector2.Subtract(posCoord, lastPos);
            
            foreach(Hitzone hitzone in hitzones)
            {
                hitzone.position += deltaPos;
            }

            base.Update(deltaSeconds);
        }

        public override void Collide(PhysicalGameObject otherObject)
        {
            base.Collide(otherObject);


        }

        public float speed = 3f;
    }
}
