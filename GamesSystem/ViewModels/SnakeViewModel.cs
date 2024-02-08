using GamesSystem.Games.Snake;
using GamesSystem.Managers;
using GamesSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace GamesSystem.ViewModels
{
    public enum DirectionType
    {
        Up,
        Down,
        Left,
        Right
    }
    public class SnakeViewModel : BaseViewModel
    {
        public Painter Painter { get; set; }
        public SnakeController SnakeController { get; set; }
        private ICommand _moveCommand;
       
        public ICommand MoveCommand =>
    _moveCommand ?? (_moveCommand = new RelayCommand<string>(ChangeDirection));

        public SnakeViewModel(Canvas canvas)
        {
            SnakeController = new SnakeController();
            SnakeController.IsGameWork = true;
            Painter = new Painter(new SnakeReneder(canvas, SnakeController),SnakeController);
            Painter.StartTimer();   
        }
        public void ChangeDirection(string eventDirection)
        {
            if(Enum.TryParse(eventDirection, out DirectionType direction))
                SnakeController.Direction = direction;
        }

    }
}
