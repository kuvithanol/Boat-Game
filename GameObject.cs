using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace boatgame
{
    class GameObject
    {
        public virtual void Update(float deltaSeconds)
        {
            updateSprite();
        }


        public Texture2D spriteSheet;

        protected int spriteSheetLength = 1;

        public Rectangle? sourceRect = null;

        public Vector2 positionalCoord;

        /// <summary>
        ///  we measure angles in radians here dipshit
        /// </summary>
        public float positionalAngle;

        public int spriteIndex = 0;

        public int spriteWidth;

        public bool flipSprite;

        protected virtual void updateSprite()
        {

        }
    }
}
