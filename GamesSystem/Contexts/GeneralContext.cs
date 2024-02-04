using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesSystem.Models;

namespace GamesSystem.Contexts
{
    public class GeneralContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        private string _path;
        public GeneralContext(string path = @"Data Source = general.db")
        {
            _path = path;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_path);
        }
    }
}
