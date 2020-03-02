using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SnakeApp
{
    public class Game
    {
        const int initialSnakeSize = 3;
        double gameTick = 150;
        private DispatcherTimer timer;


        public Game(Size boardSize, int seed)
        {
            BoardSize = boardSize;
            Seed = seed;
            this.random = new Random(this.Seed);

            /*initial food count*/
            FoodCount = (int)(BoardSize.Height * BoardSize.Width * 0.15) + 1;
            this.Snake = new Snake();
            /*this.GenerateSnake();*/

            timer = new DispatcherTimer(DispatcherPriority.Send);
            timer.Tick += OnTick;
            timer.Interval = TimeSpan.FromMilliseconds(gameTick);
            timer.Start();
        }

        public int FoodCount { get; set; }

        public Size BoardSize { get; set; }
        private int Seed { get; }

        private Random random;

        public int Score { get; set; }

        public Snake Snake { get; set; }
        public List<Point> FoodPositions { get; set; }

        public void GenerateFood()
        {

        }

        private void OnTick(object sender, EventArgs e)
        {
            this.Snake.Move();
            CheckCollision();
        }

        private void CheckCollision()
        {
            if (Snake.SnakeParts[0].Position.X < 0 || Snake.SnakeParts[0].Position.Y < 0 || Snake.SnakeParts[0].Position.X >= this.BoardSize.Height || Snake.SnakeParts[0].Position.X >= this.BoardSize.Width || HitSelf())
            {
                resetGame();
            }
        }
        
        private bool HitSelf()
        {
            foreach(SnakePart sp in this.Snake.SnakeParts.Skip(3))
            {
                if(sp.Position.X == this.Snake.SnakeParts[0].Position.X && sp.Position.Y == this.Snake.SnakeParts[0].Position.Y)
                {
                    return true;
                }                
            }
            return false;
        }

        private void resetGame()
        {
            this.Snake = new Snake();
            this.GenerateSnake();
        }

        public void GenerateSnake()
        {
            Point startPoint = new Point((int)(this.BoardSize.Width / 2d - initialSnakeSize / 2d), (int) this.BoardSize.Height / 2);
            this.Snake.GenerateSnake(initialSnakeSize, startPoint);
        }
    }
}
