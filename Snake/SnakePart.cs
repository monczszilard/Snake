using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;


namespace Snake
{
    public class SnakePart
    {
        public Point Position { get; set; }

        public virtual Color Color { get; set; }
    }
}
