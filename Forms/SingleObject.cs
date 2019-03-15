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
        public List<PlaneEnemy> planeEnemies = new List<PlaneEnemy>();
        List<EnemyBoom> enemyBooms = new List<EnemyBoom>();
        List<EnemyBullet> enemyBullets = new List<EnemyBullet>();
        List<HeroBoom> heroBooms = new List<HeroBoom>();
        public void AddGameObject(PlaneObject go)
        {
            if (go is BackGround)
                this.BG = go as BackGround;
            else if (go is PlaneHero)
                this.PH = go as PlaneHero;
            else if (go is HeroBullet)
                heroBullets.Add(go as HeroBullet);
            else if (go is PlaneEnemy)
                planeEnemies.Add(go as PlaneEnemy);
            else if (go is EnemyBoom)
                enemyBooms.Add(go as EnemyBoom);
            else if (go is EnemyBullet)
                enemyBullets.Add(go as EnemyBullet);
            else if (go is HeroBoom)
                heroBooms.Add(go as HeroBoom);
        }
        public void RemoveGameObject(PlaneObject go)
        {
            if(go is PlaneEnemy)
            {
                planeEnemies.Remove(go as PlaneEnemy);
            }
            else if(go is HeroBullet)
            {
                heroBullets.Remove(go as HeroBullet);
            }
            else if(go is EnemyBoom)
            {
                enemyBooms.Remove(go as EnemyBoom);
            }
            else if (go is EnemyBullet)
            {
                enemyBullets.Remove(go as EnemyBullet);
            }
            else if (go is HeroBoom)
            {
                heroBooms.Remove(go as HeroBoom);
            }
        }
        public void Draw(Graphics g)
        {
            this.BG.Draw(g);
            this.PH.Draw(g);
            for (int i = 0; i < heroBullets.Count; i++)
                heroBullets[i].Draw(g);
            for (int i = 0; i < planeEnemies.Count; i++)
                planeEnemies[i].Draw(g);
            for (int i = 0; i < enemyBooms.Count; i++)
                enemyBooms[i].Draw(g);
            for (int i = 0; i < enemyBullets.Count; i++)
                enemyBullets[i].Draw(g);
            for (int i = 0; i < heroBooms.Count; i++)
            {
                heroBooms[i].Draw(g);
            }
        }
        public int Score
        {
            get;
            set;
        }
        public void Collision()
        {
            for (int i = 0; i < heroBullets.Count; i++)
            {
                for(int j = 0; j < planeEnemies.Count; j++)
                    if(heroBullets[i].GetRectangle().IntersectsWith(planeEnemies[j].GetRectangle()))
                    {
                        if (planeEnemies[j].invulnerable == false)
                        {
                            planeEnemies[j].Life -= heroBullets[i].Power;
                            planeEnemies[j].IsOver();
                            heroBullets.Remove(heroBullets[i]);
                            break;
                        }
                    }
            }

            for (int i = 0; i < heroBullets.Count; i++)
            {
                for (int j = 0; j < enemyBullets.Count; j++)
                    if (heroBullets[i].GetRectangle().IntersectsWith(enemyBullets[j].GetRectangle()))
                    {
                        enemyBullets.Remove(enemyBullets[j]);
                        break;
                    }
            }

            for (int i = 0; i < enemyBullets.Count; i++)
            {

                if (enemyBullets[i].GetRectangle().IntersectsWith(this.PH.GetRectangle()))
                {
                    enemyBullets.Remove(enemyBullets[i]);
                    if(this.PH.Life <= 0)
                        this.PH.IsOver();
                    else
                        this.PH.Life--;
                }
            }
            for (int i = 0; i < planeEnemies.Count; i++)
            {
                if(planeEnemies[i].GetRectangle().IntersectsWith(this.PH.GetRectangle()))
                {
                    planeEnemies[i].Life = 0;
                    planeEnemies[i].IsOver();
                    this.PH.IsOver();
                    break;
                }
            }
        }
    }
}
