using GamesSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GamesSystem.Managers
{
    public class Painter
    {
        public Render Render {  get; set; }   
        public IGameController Controller { get; set; }
        private DispatcherTimer _timer;
        public Painter(Render render, IGameController gameController)
        {
            Render = render;
            Controller = gameController;
            InitTimer();    
        }

        public void InitTimer(int interval = 33)
        {
            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Tick += new EventHandler(Refresh);
            _timer.Interval = new TimeSpan(0,0,0,0,interval);
        }
        public void StartTimer()=> _timer?.Start();
        public void StopTimer() => _timer?.Stop();
        public void Refresh(object sender, EventArgs e)
        {
            Controller?.Update();
            Render?.Update();
        }
        
    }
}
