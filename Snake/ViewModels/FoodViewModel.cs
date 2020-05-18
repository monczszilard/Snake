using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnakeApp.ViewModels
{
    class FoodViewModel : SnakePartViewModel
    {
        public FoodViewModel(Food model, Size size) : base(model, size)
        {

        }
    }
}
