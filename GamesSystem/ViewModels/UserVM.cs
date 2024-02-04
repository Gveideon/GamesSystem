using GamesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesSystem.ViewModels
{
    public class UserVM : BaseViewModel
    {
        private User _user;
        public UserVM(User user) 
        {
            if(user is null) throw new ArgumentNullException("user is null");
            _user = user;
        }
        public string Name
        {
            get => _user.Name;
            set
            {
                _user.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Login
        {
            get => _user.Login;
            set
            {
                _user.Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get => _user.Password;
            set
            {
                _user.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

    }
}
