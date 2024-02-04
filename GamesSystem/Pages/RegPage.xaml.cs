using GamesSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GamesSystem.Pages
{
    /// <summary>
    /// Interaction logic for RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        RegViewModel RegViewModel { get; set; }
        public RegPage()
        {
            InitializeComponent();
            this.Loaded += RegPage_Loaded;
            
        }

        private void RegPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = RegViewModel = new RegViewModel(this.NavigationService);
        }
    }
}
