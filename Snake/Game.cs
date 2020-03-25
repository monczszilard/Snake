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


            this.Snake = new Snake();
            this.MapOfFoodGenerationSpots = new bool [(int)(this.BoardSize.Width) * (int)(this.BoardSize.Height)];
            this.Food = new Food(new Point(-1,-1));

            GenerateFood();
            
            timer = new DispatcherTimer(DispatcherPriority.Send);
            timer.Tick += OnTick;
            timer.Interval = TimeSpan.FromMilliseconds(gameTick);
            timer.Start();
        }
       
        public Size BoardSize { get; set; }
        private int Seed { get; }

        public Random random;

        public int Score { get; set; }

        public Snake Snake { get; set; }
        public Food Food { get; set; }

        private bool [] MapOfFoodGenerationSpots {get; set;}

        /*
         * The mapping is:
         *      point [x,y] => map[x + y*width]
         *      
         *      map[i] => point.X = i % width;
         *                point.Y = i / width;
         *      
         */

        public void GenerateFood()
        {
            for(int i = 0; i < MapOfFoodGenerationSpots.Length; i++){ //reset values => everywhere true
                MapOfFoodGenerationSpots[i] = true;
            }

            foreach(SnakePart sp in this.Snake.SnakeParts){ //set places where is currently snake to false
                MapOfFoodGenerationSpots[(int)(sp.Position.X) + (int)(this.BoardSize.Width)*(int)(sp.Position.Y)] = false;
            }

            int randomInt = this.random.Next(0, this.MapOfFoodGenerationSpots.Length - this.Snake.SnakeParts.Count - 1);

            int pointerInMap = 0;

            while(randomInt > 0){
                if(MapOfFoodGenerationSpots[pointerInMap]){
                    randomInt--;
                }
                pointerInMap++;
            }

            Food.Position = new Point(pointerInMap % (int)(this.BoardSize.Width), pointerInMap / (int)(this.BoardSize.Width));
        }

        private void OnTick(object sender, EventArgs e)
        {
            this.Snake.Move();
            CheckCollision();
        }

        private void CheckCollision()
        {
            if (Snake.SnakeParts[0].Position.X < 0 || Snake.SnakeParts[0].Position.Y < 0 || Snake.SnakeParts[0].Position.Y >= this.BoardSize.Height || Snake.SnakeParts[0].Position.X >= this.BoardSize.Width || HitSelf())
            {
                ResetGame();
            }

            if((this.Snake.SnakeParts[0].Position.X == this.Food.Position.X) && (this.Snake.SnakeParts[0].Position.Y == this.Food.Position.Y)){
                Score++;
                this.Snake.Feed();
                GenerateFood();
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

        public event EventHandler NewGameInitialized;

        private void ResetGame()
        {
            this.NewGameInitialized?.Invoke(this, EventArgs.Empty);
        }

        public void GenerateSnake()
        {
            Point startPoint = new Point((int)(this.BoardSize.Width / 2d - initialSnakeSize / 2d), (int) this.BoardSize.Height / 2);
            this.Snake.GenerateSnake(initialSnakeSize, startPoint);
        }
    }
}
