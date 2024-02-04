using GamesSystem.Games.Snake;
using GamesSystem.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesSystem.ViewModels
{
    public class SnakeGameViewModel : BaseViewModel
    {
        public Painter Painter { get; set; }
        //public SnakeGameViewModel(GraphicsView view)
        //{
        //    Painter = new Painter(view, new SnakeRenederer());
        //}   
    }
}
