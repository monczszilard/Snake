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
        private Point position;
        public Point Position
        {
            get
            {
                return new Point(position.X * BackgroundRectangleViewModel.SquareSize, position.Y * BackgroundRectangleViewModel.SquareSize);
            }

            set
            {
                this.position = value;
            }
        }
        public Color Color { get; set; }
        public Brush Brush => new SolidColorBrush(this.Color);
        public Size Size { get; set; }
        public static int SquareSize { get => GameViewModel.SquareSize; }
    }
}
