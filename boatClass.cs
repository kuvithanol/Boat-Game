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
            texture = MasterGame.boat;

            hitzones.Add(new Hitzone(50, Position));

            foreach(Hitzone hitzone in hitzones)//=========================== \/ \/ \/
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

        public override void Collide(PhysicalGameObject otherObject)
        {
            base.Collide(otherObject);
        }



        protected float turnSpeed = 5f; protected float deltaTurnSpeed = 0;
        public float speed = 150f; protected float deltaSpeed = 0;
    }
}
