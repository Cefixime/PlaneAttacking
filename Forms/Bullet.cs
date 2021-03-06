﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Forms.Properties;

namespace Plane
{


    class PlayerBullet : PlaneObject
    {
        private Image imgBullet;
        public int Power
        {
            get;
            set;
        }

        public PlayerBullet(PlaneFather pf, Image img, int speed, int power)
            : base(pf.x + 20, pf.y - 5, img.Width, img.Height, 7, 0, pf.Dir)
        {
            this.imgBullet = img;
            this.Power = power;
        }


        public override void Draw(Graphics g)
        {
            g.DrawImage(imgBullet, this.x, this.y, this.Width / 2, this.Height / 2);
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
            }
            if (this.y <= 0)
                this.y = -100;
            if (this.y >= 780)
                this.y = 1000;
        }

    }

    class Bullet : PlaneObject
    {
        private Image imgBullet;
        public int Power
        {
            get;
            set;
        }
        public Bullet(PlaneFather pf, Image img, int speed, int power) 
            : base(pf.x + 25, pf.y + 55, img.Width, img.Height, 7, 0, pf.Dir)
        {
            this.imgBullet = img;
            this.Power = power;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(imgBullet, this.x, this.y, this.Width / 2, this.Height / 2);
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
            }
            if (this.y <= 0)
                this.y = -100;
            if (this.y >= 780)
                this.y = 1000;
        }

    }
    class HeroBullet : PlayerBullet
    {
        private static Image imgHero = Resources.bullet1;

        public HeroBullet(PlaneFather pf, int speed, int power)
            : base(pf, imgHero, speed, power)
        {

        }
    }
    class EnemyBullet : Bullet
    {
        private static Image imgHero = Resources.bullet11;
        public EnemyBullet(PlaneFather pf, int speed, int power)
            : base(pf, imgHero, speed, power)
        { }
    }

}
