using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace boatgame
{
    static class CustomMath
    {
        public static Vector2 AngleToVector(float angle)
        {
            return new Vector2(MathF.Cos(angle), MathF.Sin(angle));
        }

        public static float VectorToAngle(Vector2 vector)
        {
            return MathF.Atan2(vector.Y, vector.X);
        } 

        public static void V2Rotate (ref Vector2 v, float radians)
        {
            float sin = MathF.Sin(radians);
            float cos = MathF.Cos(radians);

            float tx = v.X;
            float ty = v.Y;
            v.X = (cos * tx) - (sin * ty);
            v.Y = (sin * tx) + (cos * ty);
        }
    }
}
