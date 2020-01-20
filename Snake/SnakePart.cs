using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;


namespace SnakeApp
{
    public class SnakePart
    {
        public Point Position { get; set; }

        public virtual Color Color { get; set; }
    }
}
