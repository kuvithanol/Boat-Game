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
            base.texture = Game1.boat;
        }

        public override void Update(float deltaSeconds)
        {
            base.Update(deltaSeconds);

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                momentum = Vector2.Lerp(momentum, customMath.AngleToVector(posAngle), 0.01f);

            if (Keyboard.GetState().IsKeyDown(Keys.A))
                posAngle += 0.02f;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                posAngle -= 0.02f;

            base.posCoord += momentum;

            momentum = Vector2.Lerp(momentum, new Vector2(0, 0), 0.005f);
        }

        public Vector2 momentum = new Vector2(0, 0);
    }
}
