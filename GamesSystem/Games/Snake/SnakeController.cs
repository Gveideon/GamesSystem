using GamesSystem.Models;
using GamesSystem.Utils;
using GamesSystem.ViewModels;
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
        public List<Point> Field { get; set; }
        public List<Point> Body { get; set; }
        public Point Head { get; set; } = new Point(3,3);
        public Point PreviusHead { get; set; } 
        public Point Food { get; set; } = new Point(-1,-1);
        public DirectionType Direction { get; set; } = DirectionType.Right;
        public bool IsGameWork { get; set; } = false;
        public int CountRows { get; set; } = 20;
        public int CountColumns { get; set; } = 20;
        public int Score { get; set; }
        public SnakeController() 
        {
            InitializeGame();
        }
        public void InitializeGame() 
        { 
            Field = Enumerable
                .Range(0,CountRows)
                .Select(x => Enumerable
                            .Range(0,CountColumns)
                            .Select(y => new Point(x,y)))
                .SelectMany(pl => pl)
                .ToList();
            Body = new List<Point> {new Point(Head.X-1,Head.Y),new Point(Head.X-2,Head.Y) };
            GenerateFood();
        }
        public void Update() 
        {
            if (!IsGameWork) return;
            PreviusHead = Head;
            MoveHead();
            if(CheckGameOver())
            {
                IsGameWork = false;
                return;
            }
            if (CheckFood())
            {
                Body.Add(new Point());
                MoveBody();
                GenerateFood();
                return;
            }
            MoveBody();
        }
        private bool CheckGameOver() => Body.Contains(Head);  
        private void MoveHead()
        {
            switch (Direction)
            {
                case DirectionType.Left:
                    Head = new Point(Head.X - 1, Head.Y);
                    break;
                case DirectionType.Right:
                    Head = new Point(Head.X + 1, Head.Y);
                    break;
                case DirectionType.Up:
                    Head = new Point(Head.X, Head.Y - 1);
                    break;
                case DirectionType.Down:
                    Head = new Point(Head.X, Head.Y + 1);
                    break;
                default:
                    break;
            }
            if(Head.X >= CountColumns) Head = new Point(0,Head.Y);
            if(Head.X < 0) Head = new Point(CountColumns-1, Head.Y);
            if(Head.Y >= CountRows) Head = new Point(Head.X, 0);
            if(Head.Y < 0) Head = new Point(Head.X, CountRows-1);
        }
        private bool CheckFood() => Head.Equals(Food);
        private void GenerateFood()
        {
            var freePoint = Field.Except(Body).Except([Head]).ToList();
            var r = new Random();
            Food = freePoint[r.Next(0, freePoint.Count - 1)];
        }
        private void MoveBody()
        {
            for (int i = Body.Count - 1; i > 0; i--)
                Body[i] = Body[i - 1];
            Body[0] = PreviusHead;
        }
    }
}
