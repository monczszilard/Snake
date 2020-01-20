using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake.ViewModels
{
    public class GameViewModel
    {
        Game Game { get; }

        public GameViewModel(Game game)
        {
            this.Game = game;
            this.BackgroundRectangleViewModels = new BackgroundRectagleViewModel[((int)(game.BoardSize.Height * game.BoardSize.Width))];
        }

        private void GenerateBackGround()
        {
            for(int row = 0; row < this.Game.BoardSize.Height; row++)
            {
                for (int column = 0; column < this.Game.BoardSize.Width; column++)
                {
                    this.BackgroundRectangleViewModels[column + row * (int)this.Game.BoardSize.Width] =
                        new BackgroundRectagleViewModel() { Position = new Point(row, column) };
                }
            }
        } 

        BackgroundRectagleViewModel[] BackgroundRectangleViewModels { get; set; }

    }
}
