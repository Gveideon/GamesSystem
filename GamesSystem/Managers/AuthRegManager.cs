using GamesSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesSystem.Managers
{
    public class AuthRegManager
    {
        private DbManager _dbManager = new DbManager();
        public  User Authorize(string login, string password)
        {
            return _dbManager.GetAllUsers().FirstOrDefault(u => u.Name == login && u.Password == password);
        }
        public User Register(string login, string password)
        {
            if (_dbManager.GetAllUsers().Where(u => u.Name == login && u.Password == password).Count() != 0)
                return null;
            User user = new User() { Name = login, Password = password, Login = login};
            _dbManager.AddUser(user);
            _dbManager.SaveChanges();
            return user;
        }
    }
}
