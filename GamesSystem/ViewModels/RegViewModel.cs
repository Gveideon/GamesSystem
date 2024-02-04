using GamesSystem.Managers;
using GamesSystem.Pages;
using GamesSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace GamesSystem.ViewModels
{
    class RegViewModel : BaseViewModel
    {
        private AuthRegManager _regManager;
        private NavigationService _navigationService;
        private ICommand _regCommand;
        private string _login;
        private string _password;
        public ICommand RegCommand =>
          _regCommand ?? (_regCommand = new RelayCommand(Reg));
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public RegViewModel(NavigationService navigateionService)
        {
            _regManager = new AuthRegManager();
            _navigationService = navigateionService;
        }
        public void Reg()
        {
            if (_regManager.Register(Login, Password) is not null)
                _navigationService.Navigate(new AuthPage());
            else
            {
                var error = new ErrorViewModel();
                error.Message = "duplicate user";
                var errorPage = new ErrorPage(error);
                _navigationService.Navigate(errorPage);
                return;
            }
            
        }
    }
}
