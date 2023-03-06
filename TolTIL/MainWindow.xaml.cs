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
        Image[,] imgMat = new Image[4, 4];
        Button imgToSwapWith = null;
        public MainWindow()
        {
            InitializeComponent();
            FillGrid();
        }

        private void OnImgClick(object sender, MouseButtonEventArgs e)
        {
            if (imgToSwapWith != null)
            {
                
            }
        }

        private void FillGrid()
        {
            int imgcount = 1;
            int[] neighbours = { 1, -1, 4, -4};
            Random rnd = new Random();
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    imgMat[j, i] = new Image();
                    imgMat[j, i].Source = new BitmapImage(new Uri($"/Images/jfk{imgcount}.png", UriKind.Relative));
                    imgMat[j, i].MouseLeftButtonDown += new MouseButtonEventHandler(OnImgClick);
                    Grid.SetColumn(imgMat[j, i], j);
                    Grid.SetRow(imgMat[j, i], i);
                    GRTili.Children.Add(imgMat[j, i]);
                    imgcount++;
                }
            }
            Image blank = GRTili.Children[15] as Image;
            blank.Source = new BitmapImage(new Uri($"/Images/blank.png", UriKind.Relative));
            Image image = blank;
            for (int i = 0; i < 25; i++)
            {
                foreach (Image img in GRTili.Children)
                {
                    int rand = neighbours[rnd.Next(0, 4)];
                    if (img.Source == blank.Source && i+rand > 0 && i+rand < 16)
                    {
                        image = img;
                        Image ahh = GRTili.Children[i+rand] as Image;
                        ahh.Source = blank.Source;
                        blank.Source = image.Source;
                    }
                }
            }
        }
    }
}
