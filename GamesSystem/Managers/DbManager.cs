using GamesSystem.Contexts;
using GamesSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesSystem.Managers
{
    public class DbManager
    {
        public GeneralContext Context { get; private set; }
        private string _path;
        public DbManager(string path = @"Data Source = general.db")
        {
            _path = path;
            Context = new GeneralContext(_path);
            Context.Database.EnsureCreated();
            Context.Users.Load();
        }
        public IEnumerable<User> GetAllUsers() => Context.Users;
        public void AddUser(User user)
        {
            if (user is null) return;
            Context.Users.Add(user);
        }
        public void RemoveUser(User user)
        {
            if(user is null) return;
            if (Context.Users.Find(user.Id) is null) return;  
            Context.Users.Remove(user);
        }
        public void SaveChanges() => Context.SaveChanges();
    }
}
