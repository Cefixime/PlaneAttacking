﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hitting.Properties;

namespace Plane
{
    class BackGround : PlaneObject
    {
        private static Image imaBG = Resources.background;
        public BackGround(int x, int y, int speed)
            : base(x, y, imaBG.Width, imaBG.Height, speed, 0, Direction.down)
        {

        }
        public override void Draw(Graphics g)
        {
            this.y += this.Speed;
            if (this.y == 0)
            {
                this.y = -850;
            }
            g.DrawImage(imaBG, this.x, this.y);
        }
    }
}