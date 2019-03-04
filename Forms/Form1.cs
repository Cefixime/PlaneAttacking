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
        int colorflash = 0;
        public static int shoottimer = 0;

        public static bool lost = false;

        static Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            InitialGame();
        }

        public void InitialGame()
        {
            Cursor.Hide();
            SingleObject.GetSingle().AddGameObject(new BackGround(0, -400, 4));
            SingleObject.GetSingle().AddGameObject(new PlaneHero(100, 100, 5, 5, Direction.up));
            for(int i = 0; i < 4; i++)
            {
                SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, 281), r.Next(-400, -100), r.Next(0, 2), false));
                if (r.Next(0, 100) > 90)
                    SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, 281), r.Next(-400, -100), 2, false));
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

            shoottimer += 1;

            if (lost == true)
            {
                colorflash += 1;
                if (colorflash == 100) colorflash = 0;
                if (colorflash > 50) playagain.ForeColor = Color.Red; else playagain.ForeColor = Color.Green;

                playagain.Visible = true;
                overlabel.Visible = true;
                pressspace.Visible = true;
            }
            else
            {
                playagain.Visible = false;
                overlabel.Visible = false;
                pressspace.Visible = false;
            }

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
            if (lost == true) return;
            for (int i = 0; i < 4; i++)
            {
                SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, 281), r.Next(-400, -100), r.Next(0, 2), false));
                if (r.Next(0, 100) > 90)
                    SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, 281), r.Next(-400, -100), 2, false));
            }
        }

        private void playagain_Click(object sender, EventArgs e)
        {
            InitialGame();
            SingleObject.GetSingle().Score = 0;
            lost = false;
            Cursor.Hide();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 32)
            {
                if (lost == true)
                {
                    InitialGame();
                    SingleObject.GetSingle().Score = 0;
                    lost = false;
                }
            }

        }
    }
}
