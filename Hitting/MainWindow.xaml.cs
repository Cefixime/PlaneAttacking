using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Plane;

namespace Hitting
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
            InitialGame();
        }
        public void InitialGame()
        {
            SingleObject.GetSingle().AddGameObject(new BackGround(0, -850, 5));
            SingleObject.GetSingle().AddGameObject(new PlaneHero(100, 100, 5, 3, Direction.up));
            for (int i = 0; i < 4; i++)
            {
                SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, (int)Width), -400, r.Next(0, 2)));
                if (r.Next(0, 100) > 90)
                    SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, (int)Width), -400, 2));
            }
        }
        private void InitialPlaneEnemy()
        {
            for (int i = 0; i < 4; i++)
            {
                SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, (int)Width), -400, r.Next(0, 2)));
                if (r.Next(0, 100) > 90)
                    SingleObject.GetSingle().AddGameObject(new PlaneEnemy(r.Next(0, (int)Width), -400, 2));
            }
        }
    }
}
