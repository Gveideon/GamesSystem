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
        private DrawingVisual _food;
        private DrawingVisual _head;
        private DrawingVisual _body;
        public Brush BrushField { get; set; } = Brushes.Beige;
        public Brush BrushHead { get; set; } = Brushes.Green;
        public Brush BrushBody{ get; set; } = Brushes.LightGreen;
        public Brush BrushFood { get; set; } = Brushes.Violet;
        public Pen PenField { get; set; } = new Pen(Brushes.Black,0.2);
        public SnakeReneder(Canvas canvas, IGameController game) : base(canvas, game)
        {
           _canvas = canvas;
            _controller = game as SnakeController;
            canvas.Children.Add(this);
            DrawField();
        }
        // need remake. duplicate code
        private void DrawField()
        {
            RemoveVisualChild(_field);
            _visuals.Remove(_field);
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
        private void DrawFood()
        {
            RemoveVisualChild(_food);
            _visuals.Remove(_food);
            _food = new DrawingVisual();
            using (DrawingContext dc = _food.RenderOpen())
            {
                dc.DrawRectangle(BrushFood, PenField,
                    new Rect(_canvas.ActualWidth / _controller.CountColumns * _controller.Food.X,
                            _canvas.ActualHeight / _controller.CountRows * _controller.Food.Y,
                    _canvas.ActualWidth / _controller.CountColumns,
                            _canvas.ActualHeight / _controller.CountRows));
            }
            _visuals.Add(_food);
            AddVisualChild(_food);
        }
        private void DrawHead()
        {
            RemoveVisualChild(_head);
            _visuals.Remove(_head);
            _head = new DrawingVisual();
            using (DrawingContext dc = _head.RenderOpen())
            {
                dc.DrawRectangle(BrushHead, PenField,
                    new Rect(_canvas.ActualWidth / _controller.CountColumns * _controller.Head.X,
                            _canvas.ActualHeight / _controller.CountRows * _controller.Head.Y,
                    _canvas.ActualWidth / _controller.CountColumns,
                            _canvas.ActualHeight / _controller.CountRows));
            }
            _visuals.Add(_head);
            AddVisualChild(_head);
        }
        private void DrawBody()
        {
            RemoveVisualChild(_body);
            _visuals.Remove(_body);
            _body = new DrawingVisual();
            using (DrawingContext dc = _body.RenderOpen())
            {
                foreach(var bodyPart in _controller.Body) 
                {
                    dc.DrawRectangle(BrushBody, PenField,
                        new Rect(_canvas.ActualWidth / _controller.CountColumns * bodyPart.X,
                        _canvas.ActualHeight / _controller.CountRows * bodyPart.Y, _canvas.ActualWidth / _controller.CountColumns,
                        _canvas.ActualHeight / _controller.CountRows));
                }
            }
            _visuals.Add(_body);
            AddVisualChild(_body);
        }

        public override void Update()
        {
            DrawField();
            DrawHead();
            DrawBody();
            DrawFood();
        }
    }
}
