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

namespace FaryTailGame
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    
    public partial class Page1 : Page
    {
        Window1 window;
        Instructions inst;
        Instructions leftbtn;
        Instructions rightbtn;
        public Page1(Window1 win)
        {
            InitializeComponent();
            window = win;
        }
        public Page1(Window1 win, Instructions i)
        {
            InitializeComponent();
            inst = i;
            window = win;

            string[] txt = inst.Text().Split('|');
            Text.Text = txt[0].Replace('&','\n');

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(inst.img, UriKind.Relative);
            bitmap.EndInit();
            img.Source = bitmap;

            if (inst.Ending())
            {
                btn1.Visibility = Visibility.Hidden;
                btn2.Visibility = Visibility.Hidden;
            }
            else
            {
                string[][] btns = { txt[1].Split('$'), txt[2].Split('$') };
                btn1.Content = btns[0][0];
                btn2.Content = btns[1][0];
                int[] btnsinst = { Convert.ToInt32(btns[0][1]), Convert.ToInt32(btns[1][1]) };
                leftbtn = window.inst[btnsinst[0]];
                rightbtn = window.inst[btnsinst[1]];
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Page1 frame = new Page1(window, leftbtn);
            window.frame1.Content = frame;
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Page1 frame = new Page1(window, rightbtn);
            window.frame1.Content = frame;
        }
    }
}
