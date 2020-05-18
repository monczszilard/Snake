
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SnakeApp.ViewModels
{
    public class SnakePartViewModel : INotifyPropertyChanged
    {
        public SnakePartViewModel(SnakePart model, Size size)
        {
            this.Size = size;
            this.Model = model;

            model.PropertyChanged += ModelPropertyChangedEventHandler;
        }

        private void ModelPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Point Position
        {
            get
            {
                return new Point(Model.Position.X * GameViewModel.SquareSize, Model.Position.Y * GameViewModel.SquareSize);
            }

        }

        public Color Color => this.Model.Color;
        public Brush Brush => new SolidColorBrush(this.Color);
        public Size Size { get; set; }

        public static int SquareSize { get => GameViewModel.SquareSize; }
        public SnakePart Model { get; }
    }
}
