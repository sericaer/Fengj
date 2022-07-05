using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Sessions.Entities
{
    public class Clan : IClan
    {
        public string name { get; internal set; }

        public (int x, int y) pos { get; set; }
    }
}
