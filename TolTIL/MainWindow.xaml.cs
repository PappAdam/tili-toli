using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        Random rng = new Random();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    imgMat[i, j] = new Rectangle();
                    imgMat[i, j].MouseLeftButtonDown += new MouseButtonEventHandler(OnTileClick);
                    imgMat[i, j].Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(i * 255/5), 0, Convert.ToByte(j * 255/5)));
                    imgMat[i, j].Tag = i * 4 + j;
                    Grid.SetColumn(imgMat[i, j], i);
                    Grid.SetRow(imgMat[i, j], j);
                    GRTili.Children.Add(imgMat[i, j]);
                }
            }

            Shuffle(100);
        }

        public void Shuffle(int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                int x = rng.Next(3) - 1;
                if (x != 0) { 
                    if (placeholderTile[0] == 0)
                        x = 1;
                    else if (placeholderTile[0] == 3)
                        x = -1;
                }

                int y = 0;
                if (x == 0)
                {
                    y = rng.Next(2) * 2 - 1;
                    if (placeholderTile[1] == 0)
                        y = 1;
                    else if (placeholderTile[1] == 3)
                        y = -1;
                }
                SwapTiles(imgMat[placeholderTile[1] + y, placeholderTile[0] + x]);
            }
        }

        public void SwapTiles(UIElement sender)
        {
            int[] senderCoords = { Grid.GetColumn((sender)), Grid.GetRow((sender)) };
            if (Math.Abs(senderCoords[0] - placeholderTile[0]) <= 1)
            {
                if (Math.Abs(senderCoords[1] - placeholderTile[1]) <= 1)
                {
                    if ((senderCoords[1] - placeholderTile[1]) * (senderCoords[0] - placeholderTile[0]) == 0)
                    {
                        Grid.SetColumn(sender, placeholderTile[0]);
                        Grid.SetRow(sender, placeholderTile[1]);
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
        }

        private void OnTileClick(object sender, MouseButtonEventArgs e)
        {
            SwapTiles((UIElement)sender);
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
                MessageBox.Show("Ki lett rakva jej btw a kurva anyd");
            }
        }
    }
}
