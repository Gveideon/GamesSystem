using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GamesSystem.Utils
{
    public class Render :FrameworkElement
    {
        private protected List<Visual> _visuals = new List<Visual>();
        
        protected override int VisualChildrenCount
        {
            get { return _visuals.Count; }
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _visuals.Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            return _visuals[index];
        }
        public Render(Canvas canvas, IGameController game)
        {

        }
        public virtual void Update() { }
    }
}
