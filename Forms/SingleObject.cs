using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Plane
{
    class SingleObject
    {
        private static SingleObject _single = null;
        public static SingleObject GetSingle()
        {
            if (_single == null)
                _single = new SingleObject();
            return _single;
        }
        public BackGround BG
        {
            get;
            set;
        }
        public PlaneHero PH
        {
            get;
            set;
        }
        List<HeroBullet> heroBullets = new List<HeroBullet>();
        public void AddGameObeject(PlaneObject go)
        {
            if (go is BackGround)
                this.BG = go as BackGround;
            else if (go is PlaneHero)
                this.PH = go as PlaneHero;
            else if (go is HeroBullet)
                heroBullets.Add(go as HeroBullet);
        }
        public void Draw(Graphics g)
        {
            this.BG.Draw(g);
            this.PH.Draw(g);
            for (int i = 0; i < heroBullets.Count; i++)
                heroBullets[i].Draw(g);
        }
    }
}
