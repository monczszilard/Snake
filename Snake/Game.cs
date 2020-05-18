namespace SnakeApp
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Threading;

    public class Game
    {
        private const int initialSnakeSize = 3;

        public Random random;

        private readonly double gameTick = 150;

        private readonly DispatcherTimer timer;

        public Game(Size boardSize, int seed)
        {
            this.BoardSize = boardSize;
            this.Seed = seed;
            this.random = new Random(this.Seed);

            this.Snake = new Snake();
            this.MapOfFoodGenerationSpots = new bool [(int)this.BoardSize.Width * (int)this.BoardSize.Height];
            this.Food = new Food(new Point(-1, -1));

            this.GenerateFood();

            this.timer = new DispatcherTimer(DispatcherPriority.Send);
            this.timer.Tick += this.OnTick;
            this.timer.Interval = TimeSpan.FromMilliseconds(this.gameTick);
            this.timer.Start();
        }

        public event EventHandler NewGameInitialized;

        public Size BoardSize { get; set; }

        public Food Food { get; set; }

        public int Score { get; set; }

        public Snake Snake { get; set; }

        /// <summary>
        ///     <para>The mapping is: point [x,y] => map[x + y*width]</para>
        ///     <para>map[i] => point.X = i % width; point.Y = i / width;</para>
        /// </summary>
        private bool[] MapOfFoodGenerationSpots { get; }

        private int Seed { get; }

        public void GenerateFood()
        {
            for (var i = 0; i < this.MapOfFoodGenerationSpots.Length; i++) // reset values => everywhere true
                this.MapOfFoodGenerationSpots[i] = true;

            foreach (var sp in this.Snake.SnakeParts) // set places where is currently snake to false
                this.MapOfFoodGenerationSpots[(int)sp.Position.X + (int)this.BoardSize.Width * (int)sp.Position.Y] =
                    false;

            var randomInt = this.random.Next(0, this.MapOfFoodGenerationSpots.Length - this.Snake.SnakeParts.Count - 1);

            var pointerInMap = 0;

            while (randomInt > 0)
            {
                if (this.MapOfFoodGenerationSpots[pointerInMap]) randomInt--;
                pointerInMap++;
            }

            this.Food.Position = new Point(
                pointerInMap % (int)this.BoardSize.Width,
                pointerInMap / (int)this.BoardSize.Width);
        }

        public void GenerateSnake()
        {
            var startPoint = new Point(
                (int)(this.BoardSize.Width / 2d - initialSnakeSize / 2d),
                (int)this.BoardSize.Height / 2);
            this.Snake.GenerateSnake(initialSnakeSize, startPoint);
        }

        private bool HitSelf()
        {
            foreach (var sp in this.Snake.SnakeParts.Skip(3))
                if (sp.Position.X == this.Snake.SnakeParts[0].Position.X
                    && sp.Position.Y == this.Snake.SnakeParts[0].Position.Y)
                    return true;
            return false;
        }

        private void CheckCollision()
        {
            if (this.Snake.SnakeParts[0].Position.X < 0 || this.Snake.SnakeParts[0].Position.Y < 0
                                                        || this.Snake.SnakeParts[0].Position.Y >= this.BoardSize.Height
                                                        || this.Snake.SnakeParts[0].Position.X >= this.BoardSize.Width
                                                        || this.HitSelf()) this.ResetGame();

            if (this.Snake.SnakeParts[0].Position.X == this.Food.Position.X
                && this.Snake.SnakeParts[0].Position.Y == this.Food.Position.Y)
            {
                this.Score++;
                this.Snake.Feed();
                this.GenerateFood();
            }
        }

        private void OnTick(object sender, EventArgs e)
        {
            this.Snake.Move();
            this.CheckCollision();
        }

        private void ResetGame()
        {
            this.NewGameInitialized?.Invoke(this, EventArgs.Empty);
        }
    }
}