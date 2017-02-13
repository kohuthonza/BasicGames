using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using BasicGames.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BasicGames.ViewModels.SnakeGame.SnakeCommands;

namespace BasicGames.ViewModels.SnakeGame
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
        public ObservableCollection<SnakeRectangle> Body { get; set; }
        public ObservableCollection<string> Directions { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Snake(Canvas canvas, int squareSize)
        {
            this.canvas = canvas;
            this.Direction = "Right";
            this.squareSize = squareSize;
            this.stepSize = this.squareSize + 1;

            this.MoveHeadUpCommand = new MoveHeadUpCommand(this);
            this.MoveHeadDownCommand = new MoveHeadDownCommand(this);
            this.MoveHeadRightCommand = new MoveHeadRightCommand(this);
            this.MoveHeadLeftCommand = new MoveHeadLeftCommand(this);

            Directions = new ObservableCollection<string>();

            Body = new ObservableCollection<SnakeRectangle>();
            Body.Add(new SnakeRectangle(0, 0));
        }

        public void Draw()
        {
            foreach (SnakeRectangle rectangle in Body)
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
            
            SnakeRectangle snakeHead = new SnakeRectangle(Body.First().XCoord, Body.First().YCoord);

            if (this.Directions.Count > 0)
            {
                this.Direction = this.Directions[0];
                this.Directions.RemoveAt(0);
            }

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

            for (int i = this.Body.Count() - 2; i >= 0; i--)
            {
                this.Body[i + 1].XCoord = this.Body[i].XCoord;
                this.Body[i + 1].YCoord = this.Body[i].YCoord;
            }
            this.Body[0] = snakeHead;        
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
