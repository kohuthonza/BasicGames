using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using BasicGames.Models;
using BasicGames.ViewModels.Commands;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BasicGames.ViewModels
{
    public class Snake : INotifyPropertyChanged
    {

        public string Direction { get; set; }
        private int squareSize;
        private int stepSize;
        private Canvas canvas;

        private MoveHeadUpCommand moveHeadUpCommand;
        public MoveHeadUpCommand MoveHeadUpCommand
        {
            get
            {
                return moveHeadUpCommand;
            }
            set
            {
                moveHeadUpCommand = value;
                OnPropertyChanged();
            }
        }
        private MoveHeadDownCommand moveHeadDownCommand;
        public MoveHeadDownCommand MoveHeadDownCommand
        {
            get
            {
                return moveHeadDownCommand;
            }
            set
            {
                moveHeadDownCommand = value;
                OnPropertyChanged();
            }
        }
        private MoveHeadRightCommand moveHeadRightCommand;
        public MoveHeadRightCommand MoveHeadRightCommand
        {
            get
            {
                return moveHeadRightCommand;
            }
            set
            {
                moveHeadRightCommand = value;
                OnPropertyChanged();
            }
        }
        private MoveHeadLeftCommand moveHeadLeftCommand;
        public MoveHeadLeftCommand MoveHeadLeftCommand
        {
            get
            {
                return moveHeadLeftCommand;
            }
            set
            {
                moveHeadLeftCommand = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<SnakeRectangle> body;

        public event PropertyChangedEventHandler PropertyChanged;

        public void Init(Canvas canvas, int squareSize)
        {
            this.canvas = canvas;
            this.Direction = "Up";
            this.squareSize = squareSize;
            this.stepSize = this.squareSize + 1;

            this.MoveHeadUpCommand = new MoveHeadUpCommand(this);
            this.MoveHeadDownCommand = new MoveHeadDownCommand(this);
            this.MoveHeadRightCommand = new MoveHeadRightCommand(this);
            this.MoveHeadLeftCommand = new MoveHeadLeftCommand(this);

            body = new ObservableCollection<SnakeRectangle>();
            body.Add(new SnakeRectangle(Convert.ToInt32(canvas.ActualHeight / 2 - this.squareSize / 2), Convert.ToInt32(canvas.ActualWidth / 2 - this.squareSize / 2)));
            body.Add(new SnakeRectangle(Convert.ToInt32(canvas.ActualHeight / 2 - this.squareSize / 2), Convert.ToInt32(canvas.ActualWidth / 2 - this.squareSize / 2 + this.stepSize)));
            body.Add(new SnakeRectangle(Convert.ToInt32(canvas.ActualHeight / 2 - this.squareSize / 2), Convert.ToInt32(canvas.ActualWidth / 2 - this.squareSize / 2 + this.stepSize * 2)));
            body.Add(new SnakeRectangle(Convert.ToInt32(canvas.ActualHeight / 2 - this.squareSize / 2), Convert.ToInt32(canvas.ActualWidth / 2 - this.squareSize / 2 + this.stepSize * 3)));
        }

        public void Draw()
        {
            foreach (SnakeRectangle rectangle in body)
            {
                Rectangle rect = new Rectangle();
                rect.Stroke = new SolidColorBrush(Colors.Black);
                rect.Fill = new SolidColorBrush(Colors.Black);
                rect.Width = this.squareSize;
                rect.Height = this.squareSize;
                Canvas.SetLeft(rect, rectangle.XCoord);
                Canvas.SetTop(rect, rectangle.YCoord);
                canvas.Children.Add(rect);
            }
        }

        public void Move()
        {
            
            SnakeRectangle snakeHead = new SnakeRectangle(body.First().XCoord, body.First().YCoord);

            if (this.Direction.Equals("Up"))
            {
                snakeHead.YCoord -= this.stepSize;
            }
            if (this.Direction.Equals("Down"))
            {
                snakeHead.YCoord += this.stepSize;
            }
            if (this.Direction.Equals("Right"))
            {
                snakeHead.XCoord += this.stepSize;
            }
            if (this.Direction.Equals("Left"))
            {
                snakeHead.XCoord -= this.stepSize;
            }

            for (int i = this.body.Count() - 2; i >= 0; i--)
            {
                this.body[i + 1].XCoord = this.body[i].XCoord;
                this.body[i + 1].YCoord = this.body[i].YCoord;
            }
            this.body[0] = snakeHead;        
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
