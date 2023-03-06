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
        Rectangle[,] imgMat = new Rectangle[4, 4];
        int[] placeholderTile = {0, 0};
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    imgMat[i, j] = new Rectangle();
                    imgMat[i, j].MouseLeftButtonDown += new MouseButtonEventHandler(OnImgClick);
                    imgMat[i, j].Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(i * 20), 0, Convert.ToByte(j * 20)));
                    imgMat[i, j].Tag = i * 4 + j;
                    Grid.SetColumn(imgMat[i, j], i);
                    Grid.SetRow(imgMat[i, j], j);
                    GRTili.Children.Add(imgMat[i, j]);
                }
            }
        }

        private void OnImgClick(object sender, MouseButtonEventArgs e)
        {

            int[] senderCoords = { Grid.GetColumn((Rectangle)(sender)), Grid.GetRow((Rectangle)(sender))};
            if (Math.Abs(senderCoords[0] - placeholderTile[0]) <= 1) {
                if (Math.Abs(senderCoords[1] - placeholderTile[1]) <= 1)
                {
                    if ((senderCoords[1] - placeholderTile[1]) * (senderCoords[0] - placeholderTile[0]) == 0)
                    {
                        Grid.SetColumn((Rectangle)sender, placeholderTile[0]);
                        Grid.SetRow((Rectangle)sender, placeholderTile[1]);
                        Grid.SetColumn(imgMat[placeholderTile[0], placeholderTile[1]], senderCoords[0]);
                        Grid.SetRow(imgMat[placeholderTile[0], placeholderTile[1]], senderCoords[1]);
                        var temp = imgMat[placeholderTile[0], placeholderTile[1]];
                        imgMat[placeholderTile[0], placeholderTile[1]] = imgMat[senderCoords[0], senderCoords[1]];
                        imgMat[senderCoords[0], senderCoords[1]] = temp;
                        placeholderTile[0] = senderCoords[0];
                        placeholderTile[1] = senderCoords[1];
                    }
                }
            }

            bool a = false;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if ((int)imgMat[y, x].Tag != Grid.GetColumn(imgMat[y, x]) * 4 + Grid.GetRow(imgMat[y, x]))
                    {
                        a = true;
                    }
                }
            }

            if (!a)
            {
                MessageBox.Show("asd");
            }
        }
    }
}
