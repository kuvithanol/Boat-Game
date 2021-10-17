using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace boatgame
{
    class Projectile : PhysicalGameObject
    {
        public Projectile(Vector2 Coord, float Angle, int Pierce, float Damage, Vector2 Momentum, float Radius, Boat Source) : base(Coord, Angle)
        {

            MasterGame.iSlatedForCreation.Add(this);
            base.positionalMomentum = Momentum;
            damage = Damage;
            pierce = Pierce;
            radius = Radius;
            spriteSheet = null;

            hitzones.Add(new Hitzone(50, Coord));
        }

        public override void Update(float deltaSeconds)
        {
            base.Update(deltaSeconds);


            foreach (Hitzone hitzone in hitzones)
            {
                hitzone.radius = radius;
            }
        }

        float radius;
        int pierce;
        float damage;
    }
}
