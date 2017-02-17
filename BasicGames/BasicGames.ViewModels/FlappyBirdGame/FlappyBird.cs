using BasicGames.ViewModels.FlappyBirdGame.FlappyBirdCommands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BasicGames.ViewModels.FlappyBirdGame
{
    public class FlappyBird : INotifyPropertyChanged
    {

        public double XCoord { get; set; }
        public double YCoord { get; set; }

        private int squareSize;

        private Canvas canvas;

        private double verticalSpeed;

        private double gravitation;

        private double stepSize;

        private JumpFlappyBirdCommand jumpFlappyBirdCommand;
        public JumpFlappyBirdCommand JumpFlappyBirdCommand
        {
            get
            {
                return jumpFlappyBirdCommand;
            }
            set
            {
                jumpFlappyBirdCommand = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public FlappyBird(Canvas canvas, int squareSize)
        {
            this.canvas = canvas;
            this.squareSize = squareSize;

            this.XCoord = this.canvas.ActualWidth / 2;
            this.YCoord = this.canvas.ActualHeight / 2 - squareSize / 2;

            this.verticalSpeed = 30;
            this.gravitation = 9.81;
            this.stepSize = 0.2;

            this.jumpFlappyBirdCommand = new JumpFlappyBirdCommand(this);
        }

        public void Jump()
        {
            this.verticalSpeed = 30;
        }

        public void Draw()
        {
            Rectangle rect = new Rectangle();
            rect.Stroke = new SolidColorBrush(Colors.Black);
            rect.Fill = new SolidColorBrush(Colors.Black);
            rect.Width = this.squareSize;
            rect.Height = this.squareSize;
            Canvas.SetLeft(rect, this.XCoord);
            Canvas.SetTop(rect, this.YCoord);
            this.canvas.Children.Add(rect);
        }

        public void Move()
        {
            this.YCoord -= this.verticalSpeed * this.stepSize;
            this.verticalSpeed -= this.gravitation * this.stepSize;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
