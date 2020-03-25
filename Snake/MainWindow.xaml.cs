using SnakeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnakeApp
{
    public partial class MainWindow : Window
    {
        private Game game;

        int Seed {get; set;}

        public MainWindow()
        {
            InitializeComponent();
            Seed = 0;
            this.Game_NewGameInitialized(null, EventArgs.Empty);
        }

        private void Game_NewGameInitialized(object sender, EventArgs e)
        {
            if (this.game != null)
            {
                Seed = this.game.random.Next();
                this.game.NewGameInitialized -= Game_NewGameInitialized;
            }
            this.game = new Game(new Size(21, 21), Seed);
            this.DataContext = new GameViewModel(game);
            game.GenerateSnake();
            game.NewGameInitialized += Game_NewGameInitialized;
        }

        private void KeyDownEventHandler(object sender, KeyEventArgs e)
        {
            (this.DataContext as GameViewModel)?.KeyDownEventHandler(e);
        }

    }
}
