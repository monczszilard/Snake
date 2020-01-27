using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SnakeApp
{
    public class SnakeHead : SnakePart
    {
        public SnakeHead(Point position) : base(position)
        {

        }

        public override Color Color { get; set; } = Colors.Red;
    }
}
