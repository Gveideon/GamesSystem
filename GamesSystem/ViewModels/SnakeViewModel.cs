using GamesSystem.Games.Snake;
using GamesSystem.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GamesSystem.ViewModels
{
    public class SnakeViewModel : BaseViewModel
    {
        public Painter Painter { get; set; }
        public SnakeViewModel(Canvas canvas)
        {
            var game = new SnakeController();
            Painter = new Painter(new SnakeReneder(canvas, game));
            Painter.StartTimer();   
        }
    }
}
