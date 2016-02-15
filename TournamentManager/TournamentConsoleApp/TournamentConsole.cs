using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace TournamentConsoleApp
{
    class TournamentConsole
    {
        static void Main(string[] args)
        {
            var ctx = new DataBaseContext();
            var p = ctx.Players.ToList();
        }
    }
}
