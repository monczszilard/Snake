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

namespace SnakeApp.ViewModels
{
    public class GameViewModel
    {
        Game Model { get; }
        public static int SquareSize { get; set; } = 40;
        public int CanvasSize { get; set; } = 

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
                SnakePartViewModel newSnakePartViewModel = new SnakePartViewModel(newSnakePartModel.Position, new Size(SquareSize, SquareSize), newSnakePartModel.Color);
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
        //=> new ObservableCollection<object>(this.BackgroundRectangleViewModels.Concat(this.SnakePartViewModels.Cast<object>()));

        public ObservableCollection<SnakePartViewModel> SnakePartViewModels { get; set; }

        public BackgroundRectangleViewModel[] BackgroundRectangleViewModels { get; set; }

    }
}
