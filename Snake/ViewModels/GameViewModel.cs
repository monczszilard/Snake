using System;
using System.Collections.Generic;
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

        public GameViewModel(Game game)
        {
            this.Game = game;
            this.BackgroundRectangleViewModels = new BackgroundRectangleViewModel[((int)(game.BoardSize.Height * game.BoardSize.Width))];
            GenerateBackGround();
        }

        private void GenerateBackGround()
        {
            for(int row = 0; row < this.Game.BoardSize.Height; row++)
            {
                for (int column = 0; column < this.Game.BoardSize.Width; column++)
                {
                    this.BackgroundRectangleViewModels[column + row * (int)this.Game.BoardSize.Width] =
                        new BackgroundRectangleViewModel() { Position = new Point(row, column), Color = Colors.Black };
                }
            }
        } 

        public BackgroundRectangleViewModel[] BackgroundRectangleViewModels { get; set; }

    }
}
