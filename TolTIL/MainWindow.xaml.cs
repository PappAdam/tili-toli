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

namespace TolTIL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[,] imgMat = new Button[4, 4];
        Button imgToSwapWith = null;
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    imgMat[i, j] = new Button();
                    imgMat[i, j].Content = i * 4 + j;
                    imgMat[i, j].MouseLeftButtonDown += new MouseButtonEventHandler(OnImgClick);
                    Grid.SetColumn(imgMat[i, j], i);
                    Grid.SetRow(imgMat[i, j], j);
                    GRTili.Children.Add(imgMat[i, j]);
                }
            }
        }

        private void OnImgClick(object sender, MouseButtonEventArgs e)
        {
            if (imgToSwapWith != null)
            {
                
            }
        }
    }
}
