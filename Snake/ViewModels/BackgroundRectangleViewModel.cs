using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SnakeApp.ViewModels
{
    public class BackgroundRectangleViewModel
    {
        public Point Position { get; set; }
        public Color Color { get; set; }
        public Brush Brush => new SolidColorBrush(this.Color);
        public Size Size { get; set; }
    }
}
