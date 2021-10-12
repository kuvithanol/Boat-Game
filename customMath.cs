using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace boatgame
{
    static class customMath
    {
        public static Vector2 AngleToVector(float angle)
        {
            return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
        }

        public static float VectorToAngle(Vector2 vector)
        {
            return (float)Math.Atan2(vector.Y, vector.X);
        }
    }

    public class Hitzone
    {
        public Hitzone(float rad, Vector2 pos)
        {
            radius = rad;
            position = pos;
        }
        float radius;
        public Vector2 position;

        public bool isColliding(Hitzone other)
        {
            float dist = Vector2.Distance(position, other.position);

            float totalRad = radius + other.radius;

            if (totalRad <= dist)
            return true;
            else return false;
        }
    }

}
