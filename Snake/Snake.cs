using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeApp
{
    public class Snake
    {

        public Snake()
        {
            this.SnakeParts = new ObservableCollection<SnakePart>();
            this.OldDirection = Direction.Right;
            this.NewDirection = Direction.Right;
            this.Fed = false;
        }

        public ObservableCollection<SnakePart> SnakeParts { get; set; } //from head to tail
        private bool Fed {get; set;}

        public Direction OldDirection { get; set; }

        public Direction newDirection;
        public Direction NewDirection
        {
            get
            {
                return this.newDirection;
            }

            set
            {
                switch (value)
                {
                    case Direction.Left:
                        if (this.OldDirection != Direction.Right)
                        {
                            this.newDirection = value;
                        }
                        break;
                    case Direction.Right:
                        if (this.OldDirection != Direction.Left)
                        {
                            this.newDirection = value;
                        }
                        break;
                    case Direction.Up:
                        if (this.OldDirection != Direction.Down)
                        {
                            this.newDirection = value;
                        }
                        break;
                    case Direction.Down:
                        if (this.OldDirection != Direction.Up)
                        {
                            this.newDirection = value;
                        }
                        break;
                }
            }
        }

        public void Move()
        {
            switch (this.NewDirection)
            {
                case Direction.Left:
                    this.ChangePosition(-1, 0);
                    break;
                case Direction.Right:
                    this.ChangePosition(1, 0);
                    break;
                case Direction.Up:
                    this.ChangePosition(0, -1);
                    break;
                case Direction.Down:
                    this.ChangePosition(0, 1);
                    break;
            }

            this.OldDirection = this.NewDirection;
        }

        private void ChangePosition(int dx, int dy)
        {
            if(Fed){ 
                Fed = false;
                this.SnakeParts.Add(new SnakePart(new Point(-1,-1))); //add a snakePart to the end of snake, the position will be correctly asigned below
            }
            this.SnakeParts[SnakeParts.Count - 1].Position = new Point(this.SnakeParts[0].Position.X, this.SnakeParts[0].Position.Y);
            this.SnakeParts.Move(SnakeParts.Count - 1, 1);
            this.SnakeParts[0].Position = new Point(this.SnakeParts[0].Position.X + dx, this.SnakeParts[0].Position.Y + dy);
        }

        public void GenerateSnake(int size, Point startPosition)
        {
            for (int i = size - 1; i >= 0; i--)
            {
                Point position = new Point(startPosition.X + i, startPosition.Y);
                SnakePart snakePart = i != size - 1 ? new SnakePart(position) : new SnakeHead(position);
                this.SnakeParts.Add(snakePart);
            }
        }

        public void Feed(){
            this.Fed = true;
        }
    }
}
