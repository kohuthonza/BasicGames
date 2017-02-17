using BasicGames.Models;
using BasicGames.ViewModels.FlappyBirdGame.GameCommands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BasicGames.ViewModels.FlappyBirdGame
{
    public class FlappyBirdViewModel : INotifyPropertyChanged
    {
        private Canvas canvas;
        private int squareSize;
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
        private FlappyBird flappyBird;
        public FlappyBird FlappyBird
        {
            get
            {
                return flappyBird;
            }
            set
            {
                flappyBird = value;
                OnPropertyChanged();
            }
        }
        private StartFlappyBirdCommand startFlappyBirdCommand;
        public StartFlappyBirdCommand StartFlappyBirdCommand
        {
            get
            {
                return startFlappyBirdCommand;
            }
            set
            {
                startFlappyBirdCommand = value;
                OnPropertyChanged();
            }
        }
        private PauseFlappyBirdCommand pauseFlappyBirdCommand;
        public PauseFlappyBirdCommand PauseFlappyBirdCommand
        {
            get
            {
                return pauseFlappyBirdCommand;
            }
            set
            {
                pauseFlappyBirdCommand = value;
                OnPropertyChanged();
            }
        }
        private EndFlappyBirdCommand endFlappyBirdCommand;
        public EndFlappyBirdCommand EndFlappyBirdCommand
        {
            get
            {
                return endFlappyBirdCommand;
            }
            set
            {
                endFlappyBirdCommand = value;
                OnPropertyChanged();
            }
        }

        public System.Windows.Forms.Timer UpdateTimer { get; set; }

        private ObservableCollection<Pipe> pipes;
        private int pipeCounter;

        public event PropertyChangedEventHandler PropertyChanged;

        public void Init(Gamer gamer)
        {
            this.gamer = gamer;
            this.StartFlappyBirdCommand = new StartFlappyBirdCommand(this);
            this.PauseFlappyBirdCommand = new PauseFlappyBirdCommand(this);
            this.EndFlappyBirdCommand = new EndFlappyBirdCommand(this);
            this.IsStarted = false;
        }

        public void InitFlappyBirdGame(Canvas canvas)
        {
            this.canvas = canvas;
            this.squareSize = Convert.ToInt32(canvas.ActualWidth / 45);
            this.FlappyBird = new FlappyBird(this.canvas, this.squareSize);
            this.pipes = new ObservableCollection<Pipe>();
            this.pipes.Add(new Pipe(this.canvas, this.squareSize));
            this.IsPaused = false;
            this.Score = 0;
            this.pipeCounter = 0;
        }

        private void Update(object sender, EventArgs e)
        {
            if (IsPipeCrossBorder())
            {
                this.pipes.RemoveAt(0);
            }

            this.pipeCounter++;
            if (this.pipeCounter % 50 == 0)
            {
                this.pipeCounter = 0;
                GenerateNewPipe();
                this.Score += 10;
                if (this.Score > this.gamer.FlappyBirdTopScore)
                {
                    this.gamer.FlappyBirdTopScore = this.Score;
                }
            }

            this.FlappyBird.Move();

            foreach(Pipe pipe in this.pipes)
            {
                pipe.Move();
            }

            this.canvas.Children.Clear();
            this.FlappyBird.Draw();
            foreach (Pipe pipe in this.pipes)
            {
                pipe.Draw();
            }

            if (IsBirdCrossPipe() || IsBirdCrossBorder())
            {
                this.UpdateTimer.Stop();
                this.IsStarted = false;
            }

        }

        private void GenerateNewPipe()
        {
            this.pipes.Add(new Pipe(this.canvas, this.squareSize));
        }

        private bool IsPipeCrossBorder()
        {
            if (this.pipes.First().XCoord < 0)
            {
                return true;
            }
            return false;
        }

        private bool IsBirdCrossPipe()
        {
            foreach (Pipe pipe in this.pipes)
            {
                if (this.FlappyBird.XCoord + this.squareSize > pipe.XCoord &&
                    this.FlappyBird.XCoord < pipe.XCoord + this.squareSize &&
                    (this.FlappyBird.YCoord < pipe.Y1Coord + pipe.Height1 ||
                     this.FlappyBird.YCoord + this.squareSize > pipe.Y2Coord))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsBirdCrossBorder()
        {
            if (this.FlappyBird.YCoord < 0 || this.FlappyBird.YCoord + this.squareSize > this.canvas.ActualHeight)
            {
                return true;
            }
            return false;
        }

        public void InitUpdateTimer()
        {
            this.UpdateTimer = new System.Windows.Forms.Timer();
            this.UpdateTimer.Tick += new EventHandler(Update);
            this.UpdateTimer.Interval = 20;
            this.UpdateTimer.Start();
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
