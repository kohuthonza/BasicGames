using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BasicGames.ViewModels.Commands;
using BasicGames.Models;
using System.Threading;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BasicGames.ViewModels
{
    public class SnakeViewModel : INotifyPropertyChanged
    {
        public Snake Snake { get; set; }
        public Food Food { get; set; }
        private Canvas canvas;
        private int squareSize;
        private Random randomGenerator;
        private Gamer gamer;

        private StartSnakeCommand startSnakeCommand;
        public StartSnakeCommand StartSnakeCommand
        {
            get
            {
                return startSnakeCommand;
            }
            set
            {
                startSnakeCommand = value;
                OnPropertyChanged();
            }
        }
        private EndSnakeCommand endSnakeCommand;
        public EndSnakeCommand EndSnakeCommand
        {
            get
            {
                return endSnakeCommand;
            }
            set
            {
                endSnakeCommand = value;
                OnPropertyChanged();
            }
        }

        private System.Windows.Forms.Timer drawTimer;
        private System.Windows.Forms.Timer updateTimer;

        public event PropertyChangedEventHandler PropertyChanged;

        public SnakeViewModel()
        {
            this.Snake = new Snake();
        }

        public void Init(Gamer gamer)
        {
            this.gamer = gamer;
            this.StartSnakeCommand = new StartSnakeCommand(this);
        }

        public void InitSnakeGame(Canvas canvas)
        {
            this.canvas = canvas;
            this.squareSize = Convert.ToInt32(canvas.ActualWidth / 20);
            this.Snake.Init(this.canvas, this.squareSize);
            this.Food = new Food(this.canvas, this.squareSize);
            this.randomGenerator = new Random();
            GenerateRandomFood();
            InitDrawTimer();
            Thread.Sleep(190);
            InitUpdateTimer();
        }

        private void InitDrawTimer()
        {
            this.drawTimer = new System.Windows.Forms.Timer();
            drawTimer.Tick += new EventHandler(Draw);
            drawTimer.Interval = 200;
            drawTimer.Start();
        }

        private void InitUpdateTimer()
        {
            this.updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Tick += new EventHandler(Update);
            updateTimer.Interval = 200;
            updateTimer.Start();
        }

        private void Draw(object sender, EventArgs e)
        {
            this.canvas.Children.Clear();
            this.Food.Draw();
            this.Snake.Draw();
           
        }

        private void Update(object sender, EventArgs e)
        {
            if (IsSnakeIntersectingBorder() || IsHeadIntersectingSnake())
            {
                this.updateTimer.Stop();
                this.drawTimer.Stop();
            }

            else
            {
                if (IsHeadCrossFood())
                {
                    EatFood();
                    GenerateRandomFood();
                }
                this.Snake.Move();
            }
        }

        private bool IsHeadCrossFood()
        {
            return AreSquaresIntersecting(this.Snake.body[0].XCoord, this.Snake.body[0].YCoord, this.Food.XCoord, this.Food.YCoord);
        }

        private void EatFood()
        {
            this.gamer.SnakeScore += 10;
            this.Snake.body.Add(new SnakeRectangle(0, 0));
        }

        private void GenerateRandomFood()
        {
            do
            {
                this.Food.XCoord = randomGenerator.Next(0, Convert.ToInt32(this.canvas.ActualWidth - this.squareSize));
                this.Food.YCoord = randomGenerator.Next(0, Convert.ToInt32(this.canvas.ActualWidth - this.squareSize));
            } while (IsFoodIntersectingSnake());
        }

        private bool IsFoodIntersectingSnake()
        {
            foreach (SnakeRectangle rectangle in this.Snake.body)
            {
                if (AreSquaresIntersecting(rectangle.XCoord, rectangle.YCoord, this.Food.XCoord, this.Food.YCoord))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsSnakeIntersectingBorder()
        {
            if (this.Snake.body[0].XCoord < 0 || 
                this.Snake.body[0].XCoord + this.squareSize > this.canvas.ActualWidth ||
                this.Snake.body[0].YCoord < 0 ||
                this.Snake.body[0].YCoord + this.squareSize > this.canvas.ActualHeight)
            {
                return true;
            }
            return false;
        }

        private bool IsHeadIntersectingSnake()
        {
            int i = 0;
            do
            {
                i++;
                if (i == this.Snake.body.Count() - 1)
                {
                    break;
                }
            } while (!AreSquaresIntersecting(this.Snake.body[0].XCoord, this.Snake.body[0].YCoord, this.Snake.body[i].XCoord, this.Snake.body[i].YCoord));

            if (i == (this.Snake.body.Count() - 1))
            {
                return false;
            }

            return true;
        }

        private bool AreSquaresIntersecting(int XFirstCoord, int YFirstCoord, int XSecondCoord, int YSecondCoord)
        {
            if ((XFirstCoord + this.squareSize > XSecondCoord && XFirstCoord < XSecondCoord + this.squareSize) &&
                (YFirstCoord + this.squareSize > YSecondCoord && YFirstCoord < YSecondCoord + this.squareSize))
            {
                return true;
            }
            return false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
