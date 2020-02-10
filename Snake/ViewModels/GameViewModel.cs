using Snake.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SnakeApp.ViewModels
{
    public class GameViewModel
    {
        Game Game { get; }
        public static int SquareSize { get; set; } = 50;

        public GameViewModel(Game game)
        {
            this.Game = game;
            this.BackgroundRectangleViewModels = new BackgroundRectangleViewModel[((int)(game.BoardSize.Height * game.BoardSize.Width))];
            GenerateBackGround();
            GenerateSnake();
        }

        private void GenerateBackGround()
        {
            for (int row = 0; row < this.Game.BoardSize.Height; row++)
            {
                for (int column = 0; column < this.Game.BoardSize.Width; column++)
                {
                    this.BackgroundRectangleViewModels[column + row * (int)this.Game.BoardSize.Width] =
                        new BackgroundRectangleViewModel() { Position = new Point(row, column), Color = Colors.Black };
                }
            }
        }

        private void GenerateSnake()
        {
            foreach (SnakePart snakePart in this.Game.Snake.SnakeParts)
            {

            }
        }

        public ObservableCollection<object> CompositeCollection => new ObservableCollection<object>(this.BackgroundRectangleViewModels.Concat(this.SnakePartViewModels.Cast<object>()));

        public ObservableCollection<SnakePartViewModel> SnakePartViewModels { get; set; }

        public BackgroundRectangleViewModel[] BackgroundRectangleViewModels { get; set; }

    }
}
