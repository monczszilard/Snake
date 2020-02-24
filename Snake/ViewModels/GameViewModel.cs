using SnakeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Collections.Specialized;
using System.Windows.Input;

namespace SnakeApp.ViewModels
{
    public class GameViewModel
    {
        Game Model { get; }
        public static int SquareSize { get; set; } = 40;
        public int CanvasWidth => (int)this.Model.BoardSize.Width * SquareSize;
        public int CanvasHeight => (int)this.Model.BoardSize.Height * SquareSize;

        public void KeyDownEventHandler(KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.D:
                case Key.Left:
                    this.Model.Snake.NewDirection = Direction.Left;
                    break;
                case Key.A:
                case Key.Right:
                    this.Model.Snake.NewDirection = Direction.Right;
                    break;
                case Key.W:
                case Key.Up:
                    this.Model.Snake.NewDirection = Direction.Up;
                    break;
                case Key.S:
                case Key.Down:
                    this.Model.Snake.NewDirection = Direction.Down;
                    break;
                default:
                    break;
            }
        }

        public GameViewModel(Game game)
        {
            this.Model = game;
            this.CompositeCollection = new ObservableCollection<object>();
            this.BackgroundRectangleViewModels = new BackgroundRectangleViewModel[((int)(game.BoardSize.Height * game.BoardSize.Width))];
            this.SnakePartViewModels = new ObservableCollection<SnakePartViewModel>();
            GenerateBackGround();
            this.Model.Snake.SnakeParts.CollectionChanged += SnakeParts_CollectionChanged;
            GenerateSnake();
        }

        private void SnakeParts_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var newSnakePartModel = (SnakePart)e.NewItems[0];
                SnakePartViewModel newSnakePartViewModel = new SnakePartViewModel(newSnakePartModel, new Size(SquareSize, SquareSize));
                SnakePartViewModels.Add(newSnakePartViewModel);
                CompositeCollection.Add(newSnakePartViewModel);
            }
        }

        private void GenerateBackGround()
        {
            for (int row = 0; row < this.Model.BoardSize.Height; row++)
            {
                for (int column = 0; column < this.Model.BoardSize.Width; column++)
                {
                    this.BackgroundRectangleViewModels[column + row * (int)this.Model.BoardSize.Width] =
                        new BackgroundRectangleViewModel() { Position = new Point(row, column), Color = Colors.Black };

                    CompositeCollection.Add(this.BackgroundRectangleViewModels[column + row * (int)this.Model.BoardSize.Width]);

                }
            }
        }

        private void GenerateSnake()
        {
            foreach (SnakePart snakePart in this.Model.Snake.SnakeParts)
            {

            }
        }

        public ObservableCollection<object> CompositeCollection { get; set; }
        /*=> new ObservableCollection<object>(this.BackgroundRectangleViewModels.Concat(this.SnakePartViewModels.Cast<object>()));*/

        public ObservableCollection<SnakePartViewModel> SnakePartViewModels { get; set; }

        public BackgroundRectangleViewModel[] BackgroundRectangleViewModels { get; set; }

    }
}
