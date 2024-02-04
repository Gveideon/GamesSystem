using GamesSystem.Managers;
using GamesSystem.Models;
using GamesSystem.Pages;
using GamesSystem.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;


namespace GamesSystem.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        private AuthRegManager _regManager;
        private NavigationService _navigationService;
        private ICommand _authCommand;
        private ICommand _regCommand;
        private string _login;
        private string _password;
        public ICommand AuthCommand =>
            _authCommand ?? (_authCommand = new RelayCommand(Auth));
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
        public string Password {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public AuthViewModel(NavigationService navigateionService) 
        {
            _navigationService = navigateionService;
            _regManager = new AuthRegManager();
        }
        public void Auth()
        {
            User u = _regManager.Authorize(Login, Password);
            if (u is null)
            {
                var error = new ErrorViewModel();
                error.Message = "user not exists";
                var errorPage = new ErrorPage(error);
                _navigationService.Navigate(errorPage);
                return;
            }
            _navigationService.Navigate(new LauncherPage());
        }
        public void Reg()
        {
           _navigationService.Navigate(new RegPage());
            Debug.WriteLine("reg");
        }
    }
}
