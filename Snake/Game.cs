using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeApp
{
    public class Game
    {
        const int initialSnakeSize = 3;

        public Game(Size boardSize, int seed)
        {
            BoardSize = boardSize;
            Seed = seed;
            this.random = new Random(this.Seed);

            // initial food count
            FoodCount = (int)(BoardSize.Height * BoardSize.Width * 0.15) + 1;
            this.Snake = new Snake();
            //this.GenerateSnake();
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

        public void GenerateSnake()
        {
            Point startPoint = new Point(this.BoardSize.Width / 2d - initialSnakeSize / 2d, this.BoardSize.Height / 2);
            this.Snake.GenerateSnake(initialSnakeSize, startPoint);
        }
    }
}
