using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace boatgame
{
    class Projectile : PhysicalGameObject
    {
        public Projectile(Vector2 Coord, float Angle, int Pierce, float Damage, Vector2 momentum, Boat source) : base(Coord, Angle)
        {
            base.positionalMomentum = momentum;
            damage = Damage;
            pierce = Pierce;
        }

        int pierce;
        float damage;
    }
}
