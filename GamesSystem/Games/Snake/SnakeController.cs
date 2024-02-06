using GamesSystem.Models;
using GamesSystem.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace GamesSystem.Games.Snake
{
    public class SnakeController : IGameController
    {
        public Point[,] Field { get; set; }
        public int CountRows { get; set; } = 20;
        public int CountColumns { get; set; } = 20;
        public SnakeController() 
        {
            InitializeGame();
        }
        public void InitializeGame() 
        { 
            Field = new Point[CountColumns, CountRows];
        }
    }
}
