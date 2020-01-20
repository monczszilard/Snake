using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Snake.ViewModels
{
    public class BackgroundRectagleViewModel
    {
        public Point Position { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
    }
}
