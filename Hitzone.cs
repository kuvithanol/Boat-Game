using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace boatgame
{
    public class Hitzone
    {
        public Hitzone(float rad, Vector2 pos)
        {
            radius = rad;
            position = pos;
        }
        float radius;
        public Vector2 position;

        public static bool isColliding(Hitzone self, Hitzone other)
        {
            float dist = Vector2.Distance(self.position, other.position);

            float totalRad = self.radius + other.radius;

            if (totalRad <= dist)
                return true;
            else return false;
        }
    }
}
