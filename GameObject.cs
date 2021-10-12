﻿using Microsoft.Xna.Framework;
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

        }


        public Texture2D texture;

        public Vector2 posCoord;

        /// <summary>
        ///  we measure angles in radians here dipshit
        /// </summary>
        public float posAngle;
    }
}
