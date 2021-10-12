using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace boatgame
{
    class boatClass : GameObject
    {
        public boatClass(Vector2 position, float angle) : base(position, angle)
        {
            texture = Game1.boat;
            hitzones.Add(new Hitzone(5, position));
        }

        public override void Update(float deltaSeconds)
        {
            base.Update(deltaSeconds);

            Vector2 lastPos = posCoord;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                momentum = Vector2.Lerp(momentum, customMath.AngleToVector(posAngle)*2, 0.01f);
            else
                momentum = Vector2.Lerp(momentum, new Vector2(0, 0), 0.025f);



            if (Keyboard.GetState().IsKeyDown(Keys.A))
                posAngle += 0.02f;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                posAngle -= 0.02f;

            base.posCoord += momentum;

            Vector2 deltaPos = Vector2.Subtract(posCoord, lastPos);
            
            foreach(Hitzone hitzone in hitzones)
            {
                hitzone.position += deltaPos;
            }
        }

        public Vector2 momentum = new Vector2(0, 0);
    }
}
