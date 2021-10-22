using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace boatgame
{
    class PhysicalGameObject : GameObject
    {
        public PhysicalGameObject(Vector2 Coord, float Angle)
        {
            positionalCoord = Coord;
            positionalAngle = Angle;
        }

        public override void Update(float deltaSeconds)
        {
            spriteWidth = spriteSheet.Height;
            spriteSheetLength = spriteSheet.Width / spriteSheet.Height;

            base.Update(deltaSeconds);

            foreach (Hitzone hitzone in hitzones) //for each of my own hitzones...
            {
                foreach (PhysicalGameObject physicalGameObject in MasterGame.iGameObjects) //for every object's...
                {
                    foreach (Hitzone otherZone in physicalGameObject.hitzones) //every hitzone...
                    {
                        if (!hitzones.Contains(otherZone) && Hitzone.Colliding(hitzone, otherZone)) //if it isnt mine and it is touching...
                        {
                            Collide(physicalGameObject);
                            break;
                        }
                    }
                }
            }


            foreach (Hitzone hitzone in hitzones)
            {
                hitzone.position -= positionalCoord;
            }

            positionalCoord += positionalMomentum;
            positionalAngle += angularMomentum;

            foreach (Hitzone hitzone in hitzones)
            {
                CustomMath.V2Rotate(ref hitzone.position, angularMomentum);
                hitzone.position += positionalCoord;
            }

            if(positionalAngle < 0)
            {
                positionalAngle += MathHelper.Pi * 2;
            }
            else if (positionalAngle > MathHelper.Pi * 2)
            {
                positionalAngle -= MathHelper.Pi * 2;
            }
        }

        protected virtual void Collide(PhysicalGameObject otherObject)
        {

        }

        protected override void updateSprite()
        {
            base.updateSprite();
            spriteIndex = (int)((positionalAngle / MathHelper.Pi + .5f) % 2 * spriteSheetLength) % spriteSheetLength;

            flipSprite = (positionalAngle / MathHelper.Pi + .5f) % 2 > 1;

            if (flipSprite)
            {
                spriteIndex = (spriteSheetLength-1) - spriteIndex;
            }

            sourceRect = new Rectangle(new Point(0 + spriteIndex*spriteWidth, 0), new Point(spriteWidth, spriteWidth));
        }

        public float angularMomentum = 0f;

        public Vector2 positionalMomentum = new Vector2(0, 0);

        public List<Hitzone> hitzones = new List<Hitzone>();
    }
}