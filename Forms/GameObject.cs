using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Plane
{
    public enum Direction
    {
        stop,
        up,
        down,
        left,
        right
    }
    /// <summary>
    /// 这是所有游戏对象的父类
    /// </summary>
    abstract public class PlaneObject
    {
        public int x
        {
            get;
            set;
        }
        public int y
        {
            get;
            set;
        }
        public int Height
        {
            get;
            set;
        }
        public int Width
        {
            get;
            set;
        }

        public int Life
        {
            get;
            set;
        }
        public int Speed
        {
            get;
            set;
        }
        public Direction Dir
        {
            get;
            set;
        }
        public PlaneObject(int x, int y, int width, int height,
            int speed, int life, Direction dir)
        {
            this.x = x;
            this.y = y;
            this.Width = width;
            this.Height = height;
            this.Life = life;
            this.Speed = speed;
            this.Dir = dir;
        }
        public abstract void Draw(Graphics g);
        public Rectangle GetRectangle()
        {
            return new Rectangle(this.x, this.y, this.Width, this.Height);
        }
        public PlaneObject(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public virtual void Move()
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
            if (this.x <= 0)
                this.x = 0;
            if (this.x > 400)
                this.x = 400;
            if (this.y <= 0)
                this.y = 0;
            if (this.y >= 700)
                this.y = 700;
        }
    }
}
