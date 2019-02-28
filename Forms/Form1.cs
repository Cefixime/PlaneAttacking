using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Plane;

namespace Forms
{
    public partial class Form1 : Form
    {
        static Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            InitialGame();
        }
        public void InitialGame()
        {
            SingleObject.GetSingle().AddGameObject(new BackGround(0, -850, 5));
            SingleObject.GetSingle().AddGameObject(new PlaneHero(100, 100, 5, 3, Direction.up));
            for(int i = 0; i < 4; i++)
            {
                SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, this.Width), -400, r.Next(0, 2)));
                if (r.Next(0, 100) > 90)
                    SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, this.Width), -400, 2));
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SingleObject.GetSingle().Draw(e.Graphics);
            string score = SingleObject.GetSingle().Score.ToString();
            e.Graphics.DrawString(score, new Font("宋体", 20, FontStyle.Bold), Brushes.Red, new Point(0, 0));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.AllPaintingInWmPaint, true);
        }
        private void TimerBG_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            int count = SingleObject.GetSingle().planeEnemies.Count;
            if (count <= 1)
                InitialPlaneEnemy();
            SingleObject.GetSingle().Collision();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            SingleObject.GetSingle().PH.MouseMove(e);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            SingleObject.GetSingle().PH.Fire();
        }
        private void InitialPlaneEnemy()
        {
            for (int i = 0; i < 4; i++)
            {
                SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, this.Width), -400, r.Next(0, 2)));
                if (r.Next(0, 100) > 90)
                    SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, this.Width), -400, 2));
            }
        }
    }
}
