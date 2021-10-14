using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace boatgame
{
    public class Hitzone
    {
        public Hitzone(float Radius, Vector2 Position)
        {
            radius = Radius;
            position = Position;
        }
        public float radius;
        public Vector2 position;

        public static bool Colliding(Hitzone self, Hitzone other)
        {
            float dist = Vector2.Distance(self.position, other.position);

            float totalRad = self.radius + other.radius;

            if (dist - totalRad/2 <= 0) return true; else return false;
        }
    }
}
