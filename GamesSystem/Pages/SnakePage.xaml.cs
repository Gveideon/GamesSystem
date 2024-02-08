using GamesSystem.Games.Snake;
using GamesSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GamesSystem.Pages
{
    /// <summary>
    /// Interaction logic for SnakePage.xaml
    /// </summary>
    public partial class SnakePage : Page
    {
        public SnakeViewModel SnakeController { get; set; }
        public SnakePage()
        {
            InitializeComponent();
            this.Loaded += SnakePage_Loaded;
            this.Focusable = true;
            this.Loaded += (s, e) => Keyboard.Focus(this);
        }

        private void SnakePage_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = SnakeController = new SnakeViewModel(canvas);
        }
    }
}
