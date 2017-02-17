using System;
using System.Linq;
using BasicGames.Models;
using System.Threading;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BasicGames.ViewModels.SnakeGame.GameCommands;

namespace BasicGames.ViewModels.SnakeGame
{
    public class SnakeViewModel : INotifyPropertyChanged
    {
        public Food Food { get; set; }
        private Canvas canvas;
        private int squareSize;
        private Random randomGenerator;
        private Gamer gamer;
        public bool IsPaused { get; set; }
        public bool IsStarted { get; set; }
        private int score;
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                OnPropertyChanged();
            }
        }
        private Snake snake;
        public Snake Snake
        {
            get
            {
                return snake;
            }
            set
            {
                snake = value;
                OnPropertyChanged();
            }
        }
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
        private PauseSnakeCommand pauseSnakeCommand;
        public PauseSnakeCommand PauseSnakeCommand
        {
            get
            {
                return pauseSnakeCommand;
            }
            set
            {
                pauseSnakeCommand = value;
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

        public System.Windows.Forms.Timer UpdateTimer { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Init(Gamer gamer)
        {
            this.gamer = gamer;
            this.StartSnakeCommand = new StartSnakeCommand(this);
            this.PauseSnakeCommand = new PauseSnakeCommand(this);
            this.EndSnakeCommand = new EndSnakeCommand(this);
            this.IsStarted = false;
        }

        public void InitSnakeGame(Canvas canvas)
        {
            this.canvas = canvas;
            this.squareSize = Convert.ToInt32(canvas.ActualWidth / 45);
            this.Snake = new Snake(this.canvas, this.squareSize);
            this.Food = new Food(this.canvas, this.squareSize);
            this.randomGenerator = new Random();
            GenerateRandomFood();
            this.IsPaused = false;
            this.Score = 0;            
        }

        public void InitUpdateTimer()
        {
            this.UpdateTimer = new System.Windows.Forms.Timer();
            this.UpdateTimer.Tick += new EventHandler(Update);
            this.UpdateTimer.Interval = 200;
            this.UpdateTimer.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            if (IsHeadCrossFood())
            {
                EatFood();
                GenerateRandomFood();
            }

            this.Snake.Move();

            this.canvas.Children.Clear();
            this.Food.Draw();
            this.Snake.Draw();

            if (IsSnakeIntersectingBorder() || IsHeadIntersectingSnake())
            {
                this.UpdateTimer.Stop();
                this.IsStarted = false;
            }
        }

        private bool IsHeadCrossFood()
        {
            return AreSquaresIntersecting(this.Snake.Body[0].XCoord, this.Snake.Body[0].YCoord, this.Food.XCoord, this.Food.YCoord);
        }

        private void EatFood()
        {
            this.Score += 10;
            if (this.Score > this.gamer.SnakeTopScore)
            {
                this.gamer.SnakeTopScore = this.Score;
            }
            this.Snake.Body.Add(new SnakeRectangle(0, 0));
        }

        private void GenerateRandomFood()
        {
            do
            {
                this.Food.XCoord = randomGenerator.Next(0, Convert.ToInt32(this.canvas.ActualWidth - this.squareSize));
                this.Food.YCoord = randomGenerator.Next(0, Convert.ToInt32(this.canvas.ActualHeight - this.squareSize));
            } while (IsFoodIntersectingSnake());
        }

        private bool IsFoodIntersectingSnake()
        {
            foreach (SnakeRectangle rectangle in this.Snake.Body)
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
            if (this.Snake.Body[0].XCoord < 0 || 
                this.Snake.Body[0].XCoord + this.squareSize > this.canvas.ActualWidth ||
                this.Snake.Body[0].YCoord < 0 ||
                this.Snake.Body[0].YCoord + this.squareSize > this.canvas.ActualHeight)
            {
                return true;
            }
            return false;
        }

        private bool IsHeadIntersectingSnake()
        {
            int i = 0;
            if (this.Snake.Body.Count() > 1)
            {
                do
                {
                    i++;
                    if (i == this.Snake.Body.Count() - 1)
                    {
                        break;
                    }
                } while (!AreSquaresIntersecting(this.Snake.Body[0].XCoord, this.Snake.Body[0].YCoord, this.Snake.Body[i].XCoord, this.Snake.Body[i].YCoord));
            }
            if (i == (this.Snake.Body.Count() - 1))
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

        public void Pause()
        {
            this.UpdateTimer.Stop();
            this.IsPaused = true;
        }

        public void Continue()
        {
            InitUpdateTimer();
            this.IsPaused = false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
