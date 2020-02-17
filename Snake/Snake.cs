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
        }

        public ObservableCollection<SnakePart> SnakeParts { get; set; }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    break;
                case Direction.Right:
                    break;
                case Direction.Up:
                    break;
                case Direction.Down:
                    break;
            }
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
    }
}
