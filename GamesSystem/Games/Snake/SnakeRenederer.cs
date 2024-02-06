using GamesSystem.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GamesSystem.Games.Snake
{
    public class SnakeReneder : Render
    {
        private Canvas _canvas;
        private SnakeController _controller;
        private DrawingVisual _field;
        public Brush BrushField { get; set; } = Brushes.Beige;
        public Pen PenField { get; set; } = new Pen(Brushes.Black,0.2);
        public SnakeReneder(Canvas canvas, IGameController game) : base(canvas, game)
        {
           _canvas = canvas;
            _controller = game as SnakeController;
            canvas.Children.Add(this);
            DrawField();
        }
        private void DrawField()
        {
            RemoveVisualChild(_field);
            _visuals.Clear();
            
            _field = new DrawingVisual();
            using (DrawingContext dc = _field.RenderOpen())
            {
                dc.DrawRectangle(BrushField, PenField, new Rect(0,0, _canvas.ActualWidth, _canvas.ActualHeight));
                for (int i = 0; i < _controller.CountRows; i++)
                {
                    for (int k = 0; k < _controller.CountColumns; k++)
                    {
                        dc.DrawRectangle(BrushField, PenField,
                            new Rect(_canvas.ActualWidth / _controller.CountColumns * k,
                            _canvas.ActualHeight / _controller.CountRows * i, _canvas.ActualWidth / _controller.CountColumns,
                            _canvas.ActualHeight / _controller.CountRows));
                    }
                }
            }
            _visuals.Add(_field);
            AddVisualChild(_field);
        }

        public override void Update()
        {
            DrawField();
        }
    }
}
