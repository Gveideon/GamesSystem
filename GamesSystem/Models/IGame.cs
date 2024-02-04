using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesSystem.Models
{
    public interface IGame
    {
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract string LogoPath { get; set; }
        public abstract void Run();

    }
}
