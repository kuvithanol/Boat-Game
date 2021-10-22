using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace boatgame
{
    class Boat : PhysicalGameObject
    {
        public Boat(Vector2 Position, float Angle) : base(Position, Angle)
        {
            spriteSheet = MasterGame.boatSheet;
            spriteWidth = spriteSheet.Height;
            spriteSheetLength = spriteSheet.Width / spriteSheet.Height;

            foreach (Hitzone hitzone in hitzones)//=========================== \/ \/ \/
            {
                hitzone.position -= positionalCoord;
                CustomMath.V2Rotate(ref hitzone.position, Angle);
                hitzone.position += positionalCoord;
            }//============================================================== this code aligns all the colliders to the spawning angle
        }

        public override void Update(float deltaSeconds)
        {
            base.Update(deltaSeconds);

            deltaSpeed = deltaSeconds * speed;

            deltaTurnSpeed = deltaSeconds * turnSpeed;

        }

        protected override void Collide(PhysicalGameObject otherObject)
        {
            base.Collide(otherObject);
            if (otherObject is Projectile projectile)
            {

            }
        }

        protected virtual void hitBy(Projectile projectile)
        {

        }

        protected virtual void Attack(float angle)
        {

        }

        protected float projectileDamage = 1f; protected float collisionDamage = 1f; protected int pierce = 1; protected float projectileSpeed = 1f;
        protected float fireRate = 1f; protected float fireDelay = 0;
        protected float turnSpeed = 5f; protected float deltaTurnSpeed = 0;
        public float speed = 150f; protected float deltaSpeed = 0;
    }
}
