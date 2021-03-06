﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Forms.Properties;
using System.Windows.Forms;

namespace Plane
{
    abstract class PlaneFather : PlaneObject
    {
        public static Random r = new Random();
        private Image imgPlane;
        public PlaneFather(int x, int y, Image img, int speed, int life, Direction dir, bool invulnerable) 
            : base(x, y, img.Width, img.Height, speed, life, dir)
        {
            this.imgPlane = img;
        }
        public abstract void IsOver();
    }
    class PlaneHero : PlaneFather
    {
        public Direction Dirx;
        public Direction Diry;
        private static Image imgPlane = Resources.hero1;
        public PlaneHero(int x, int y, int speed, int life, Direction dir)
            :base(x, y, imgPlane, speed, life, dir, false)
        {
        
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(imgPlane, this.x, this.y, this.Width / 2, this.Height / 2);
        }
        public void MouseMove(MouseEventArgs e)
        {
            if (Forms.Form1.lost == false)
            {
                this.x = e.X - 23;
                this.y = e.Y - 25;
            }
        }
        public void Fire()
        {
            if (Forms.Form1.shoottimer > 7)
            {
                SingleObject.GetSingle().AddGameObject(new HeroBullet(this, 10, 1));
                Forms.Form1.shoottimer = 0;
            }
        }
        public override void IsOver()
        {
            SingleObject.GetSingle().AddGameObject(new HeroBoom(this.x, this.y));
            this.y = 1000;
            Forms.Form1.lost = true;
        }
        public override void Move()
        {
            switch(Diry)
            {
                case Direction.up:
                    this.y -= this.Speed;
                    break;
                case Direction.down:
                    this.y += this.Speed;
                    break;
                case Direction.stop:
                    break;
            }
            switch(Dirx)
            {
                case Direction.left:
                    this.x -= this.Speed;
                    break;
                case Direction.right:
                    this.x += this.Speed;
                    break;
                case Direction.stop:
                    break;
            }
            if (this.x >= 440)
                this.x = 440;
            else if (this.x <= 0)
                this.x = 0;
            if (this.y >= 600)
                this.y = 600;
            else if (this.y <= 0)
                this.y = 0;
        }
    }
    class PlaneEnemy : PlaneFather
    {
        private static Image img1 = Resources.enemy0;
        private static Image img2 = Resources.enemy1;
        private static Image img3 = Resources.enemy2;

        public PlaneEnemy(int x, int y, int type, bool invulnerable)
            : base(x, y, GetImage(type), GetSpeed(type), GetLife(type), Direction.down, false)
        {
            this.EnemyType = type;
        }
        public int EnemyType
        {
            get;
            set;
        }

        public bool invulnerable = true;

        public static Image GetImage(int type)
        {
            switch(type)
            {
                case 0:
                    return img1;
                case 1:
                    return img2;
                case 2:
                    return img3;
            }
            return null;
        }
        public static int GetLife(int type)
        {
            switch(type)
            {
                case 0:
                    return 1;
                case 1:
                    return 2;
                case 2:
                    return 3;
            }
            return 0;
        }
        public static int GetSpeed(int type)
        {
            switch(type)
            {
                case 0:
                    return 5;
                case 1:
                    return 4;
                case 2:
                    return 3;
            }
            return 0;
        }
        public override void Draw(Graphics g)
        {
            switch(this. EnemyType)
            {
                case 0:
                    g.DrawImage(img1, this.x, this.y);
                    break;
                case 1:
                    g.DrawImage(img2, this.x, this.y);
                    break;
                case 2:
                    g.DrawImage(img3, this.x, this.y);
                    break;
            }
            this.Move();
        }
        public override void Move()
        {
            switch (this.Dir)
            {
                case Direction.up:
                    this.y -= this.Speed;
                    break;
                case Direction.down:
                    this.y += this.Speed;
                    break;
                case Direction.left:
                    this.x -= this.Speed;
                    break;
                case Direction.right:
                    this.x += this.Speed;
                    break;
            }
            if (this.y <= 0)
            {
                invulnerable = true;
            }
            else invulnerable = false;

            if (this.x <= 0)
                this.x = 0;
            if (this.x > 280)
                this.x = 280;
            if (this.y >= 780)
            {
                this.y = 1400;
                SingleObject.GetSingle().RemoveGameObject(this);
            }
            if (r.Next(0, 100) > 95)
            {
                Fire();
            }
        }
        public void Fire()
        {
            SingleObject.GetSingle().AddGameObject(new EnemyBullet(this, 20 , 1));
        }
        public override void IsOver()
        {
            if (this.Life <= 0)
            {
                SingleObject.GetSingle().RemoveGameObject(this);
                SingleObject.GetSingle().AddGameObject(new EnemyBoom(this.x, this.y, this.EnemyType));
                switch(this.EnemyType)
                {
                    case 0:
                        if (Forms.Form1.lost == false) SingleObject.GetSingle().Score += 10;
                        break;
                    case 1:
                        if (Forms.Form1.lost == false) SingleObject.GetSingle().Score += 20;
                        break;
                    case 2:
                        if (Forms.Form1.lost == false) SingleObject.GetSingle().Score += 30;
                        break;
                }
            }
        }
    }
}
