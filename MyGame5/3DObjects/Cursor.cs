﻿using SharpDX;
using SharpDX.Toolkit.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isometric._3DObjects
{
    class Cursor : Shape
    {
        #region c-tor
        public Cursor(float x, float y, float z)
            : base(x, y, z) { }
       float r = 1.4f;
        #endregion

        #region func
        private Vector3 GetPosition(float t, float y, float rCurrent)
        {
            float xx = x + (float)(rCurrent * Math.Cos(t));
            float zz = z + (float)(rCurrent * Math.Sin(t));
            return new Vector3(xx, y, zz);
        }
        public override List<VertexPositionNormalTexture> Draw()
        {
            List<VertexPositionNormalTexture> listVertexPositionColor = new List<VertexPositionNormalTexture>();
            int tDiv = 32;
            int yDiv = 32;
            float maxTheta = (float)(2 * Math.PI);
            float minY = y - r;
            float dt = maxTheta / tDiv;
            float dy = 2 * r / yDiv;
            for (int yi = 0; yi <= yDiv; yi++)
            {
                float yCurrent1 = minY + yi * dy;
                float yCurrent2 = minY + (yi + 1) * dy;
                float rCurrent1 = (float)Math.Sqrt(r * r - (y - yCurrent1) * (y - yCurrent1));
                float rCurrent2 = (float)Math.Sqrt(r * r - (y - yCurrent2) * (y - yCurrent2));
                for (int ti = 0; ti <= tDiv; ti++)
                {
                    float t = ti * dt;
                    float t1 = (ti + 1) * dt;

                    listVertexPositionColor.Add(new VertexPositionNormalTexture(GetPosition(t, yCurrent1, rCurrent1),GetPosition(t, yCurrent1, rCurrent1), new Vector2(0, 1)));
                   listVertexPositionColor.Add(new VertexPositionNormalTexture(GetPosition(t1, yCurrent1, rCurrent1),GetPosition(t1, yCurrent1, rCurrent1), new Vector2(0, 1)));
                   listVertexPositionColor.Add(new VertexPositionNormalTexture(GetPosition(t, yCurrent2, rCurrent2),GetPosition(t, yCurrent2, rCurrent2), new Vector2(0, 1)));
                  
                   listVertexPositionColor.Add(new VertexPositionNormalTexture(GetPosition(t1, yCurrent2, rCurrent2),GetPosition(t1, yCurrent2, rCurrent2), new Vector2(0, 1)));
                   listVertexPositionColor.Add(new VertexPositionNormalTexture(GetPosition(t, yCurrent2, rCurrent2),GetPosition(t, yCurrent2, rCurrent2), new Vector2(0, 1)));
                   listVertexPositionColor.Add(new VertexPositionNormalTexture(GetPosition(t1, yCurrent1, rCurrent1),GetPosition(t1, yCurrent1, rCurrent1), new Vector2(0, 1)));
                  


                }
            }
            return listVertexPositionColor;
        }
        public void setPosition(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        #endregion
    }
}
