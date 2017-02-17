using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BasicGames.ViewModels.FlappyBirdGame
{
    public class Pipe
    {
        private Canvas canvas;
        private int Width { get; set; }
        public int Height1 { get; set; }
        public int Height2 { get; set; }
        public double XCoord { get; set; }
        public double Y1Coord { get; set; }
        public double Y2Coord { get; set; }
        private Random randomGenerator;


        public Pipe(Canvas canvas, int width)
        {
            this.canvas = canvas;
            this.Width = width;
            this.XCoord = this.canvas.ActualWidth - this.Width;
            this.randomGenerator = new Random();
            this.Y1Coord = 0;
            this.Height1 = randomGenerator.Next(0, Convert.ToInt32(this.canvas.ActualHeight - 3 * width));
            this.Y2Coord = randomGenerator.Next(this.Height1 + 3 * width, Convert.ToInt32(this.canvas.ActualHeight));
            this.Height2 = Convert.ToInt32(this.canvas.ActualHeight - this.Y2Coord);
        }

        public void Draw()
        {
            DrawPipe(this.Height1, this.Y1Coord);
            DrawPipe(this.Height2, this.Y2Coord);
        }

        private void DrawPipe(int height, double YCoord)
        {
            Rectangle rect = new Rectangle();
            rect.Stroke = new SolidColorBrush(Colors.Black);
            rect.Fill = new SolidColorBrush(Colors.Black);
            rect.Width = this.Width;
            rect.Height = height;
            Canvas.SetLeft(rect, this.XCoord);
            Canvas.SetTop(rect, YCoord);
            canvas.Children.Add(rect);
        }

        public void Move()
        {
            this.XCoord -= this.canvas.ActualWidth / 130;
        }
    }
}
