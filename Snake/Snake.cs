using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp
{
    public class Snake
    {
        public List<SnakePart> SnakeParts { get; set; }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    break;

            }
        }
    }
}
