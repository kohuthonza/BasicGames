using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BasicGames.ViewModels
{
    public class Food
    {

        private Canvas canvas;
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        private int squareSize;

        public Food(Canvas canvas, int squareSize)
        {
            this.canvas = canvas;
            this.squareSize = squareSize;
        }

        public void Draw()
        {
            Rectangle rect = new Rectangle();
            rect.Stroke = new SolidColorBrush(Colors.Red);
            rect.Fill = new SolidColorBrush(Colors.Red);
            rect.Width = this.squareSize;
            rect.Height = this.squareSize;
            Canvas.SetLeft(rect, this.XCoord);
            Canvas.SetTop(rect, this.YCoord);
            canvas.Children.Add(rect);
        }
    }
}
