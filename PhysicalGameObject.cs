using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace boatgame
{
    class PhysicalGameObject : GameObject
    {
        public PhysicalGameObject(Vector2 coord, float angle)
        {
            posCoord = coord;
            posAngle = angle;
        }

        public override void Update(float deltaSeconds)
        {
            base.Update(deltaSeconds);

            foreach (Hitzone hitzone in hitzones) //for each of my own hitzones...
            {
                foreach (PhysicalGameObject physicalGameObject in Game1.iGameObjects) //for every object's...
                {
                    foreach (Hitzone otherZone in physicalGameObject.hitzones) //every hitzone...
                    {
                        if (hitzone != otherZone && Hitzone.Colliding(hitzone, otherZone)) //if it isnt mine and it is touching...
                        {
                            //momentum = Vector2.Lerp(momentum, physicalGameObject.momentum, 0.5f);
                            //momentum += Vector2.Subtract(hitzone.position, otherZone.position) * 0.002f;
                            //   bad physical collision code ^

                            Collide(physicalGameObject);
                        }
                    }
                }
            }
        }

        public virtual void Collide(PhysicalGameObject otherObject)
        {

        }


        public bool isSolid = true;

        public Vector2 momentum = new Vector2(0, 0);

        public List<Hitzone> hitzones = new List<Hitzone>();
    }
}