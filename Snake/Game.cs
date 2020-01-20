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
        public Game(Size boardSize, int seed)
        {
            BoardSize = boardSize;
            Seed = seed;
            this.random = new Random(this.Seed);

            // initial food count
            FoodCount = (int)(BoardSize.Height * BoardSize.Width * 0.15) + 1;
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
    }
}
