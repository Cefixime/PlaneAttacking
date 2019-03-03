using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hitting.Properties;
using System.Drawing;

namespace Plane
{
    abstract class Boom : PlaneObject
    {
        public Boom(int x, int y) : base(x, y)
        {

        }
    }
    class EnemyBoom : Boom
    {
        private Image[] imgs1 =
        {
            Resources.enemy0_down1,
            Resources.enemy0_down2,
            Resources.enemy0_down3,
            Resources.enemy0_down4
        };
        private Image[] imgs2 =
        {
            Resources.enemy1_down1,
            Resources.enemy1_down2,
            Resources.enemy1_down3,
            Resources.enemy1_down4,
        };
        private Image[] imgs3 =
        {
            Resources.enemy2_down1,
            Resources.enemy2_down2,
            Resources.enemy2_down3,
            Resources.enemy2_down4,
            Resources.enemy2_down5,
            Resources.enemy2_down6
        };
        public int Type
        {
            get;
            set;
        }
        public EnemyBoom(int x, int y, int type) : base(x, y)
        {
            this.Type = type;
        }
        public override void Draw(Graphics g)
        {
            switch (this.Type)
            {
                case 0:
                    for (int i = 0; i < imgs1.Length; i++)
                    {
                        g.DrawImage(imgs1[i], this.x, this.y);
                    }
                    break;
                case 1:
                    for (int i = 0; i < imgs2.Length; i++)
                    {
                        g.DrawImage(imgs2[i], this.x, this.y);
                    }
                    break;
                case 2:
                    for (int i = 0; i < imgs3.Length; i++)
                    {
                        g.DrawImage(imgs3[i], this.x, this.y);
                    }
                    break;
            }
            SingleObject.GetSingle().RemoveGameObject(this);
        }
    }
    class HeroBoom : Boom
    {
        private Image[] imgs =
        {
            Resources.hero_blowup_n1,
            Resources.hero_blowup_n2,
            Resources.hero_blowup_n3,
            Resources.hero_blowup_n4,
        };
        public HeroBoom(int x, int y) : base(x, y)
        {

        }
        public override void Draw(Graphics g)
        {
            for (int i = 0; i < imgs.Length; i++)
            {
                g.DrawImage(imgs[i], this.x, this.y, imgs[i].Width / 2, imgs[i].Height / 2);
            }
            SingleObject.GetSingle().RemoveGameObject(this);
        }
    }
}
