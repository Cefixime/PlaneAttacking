using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Forms.Properties;

namespace Plane
{
    abstract class PlaneFather : PlaneObject
    {
        private Image imgPlane;
        public PlaneFather(int x, int y, Image img, int speed, int life, Direction dir) 
            : base(x, y, img.Width, img.Height, speed, life, dir)
        {
            this.imgPlane = img;
        }
    }
    class PlaneHero : PlaneFather
    {
        private static Image imgPlane = Resources.hero1;
        public PlaneHero(int x, int y, int speed, int life, Direction dir)
            :base(x, y, imgPlane, speed, life, dir)
        {
        
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(imgPlane, this.x, this.y);
        }
    }
}
