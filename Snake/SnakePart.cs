using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;


namespace SnakeApp
{
    public class SnakePart : INotifyPropertyChanged
    {
        public virtual Color Color { get; set; } = Colors.Aquamarine;

        public SnakePart(Point position)
        {
            this.Position = position;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected Point position;
        public Point Position
        {
            get
            {
                return this.position;
            }

            set
            {
                if (this.position != value)
                {
                    this.position = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Position)));
                }

            }
        }
    }
}
