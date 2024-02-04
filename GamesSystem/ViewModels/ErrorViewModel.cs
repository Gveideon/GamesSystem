using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesSystem.ViewModels
{
    public class ErrorViewModel : BaseViewModel
    {
        private string _message = "Default Error";
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        public ErrorViewModel() 
        {

        }
    }
}
