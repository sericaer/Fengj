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

        public int population { get; set; }

        public double supplies { get; set; }

        public double consumes => consumesPer * population;

        public double consumesPer => Math.Round(Math.Min(Math.Max(supplies / 6 / population, minPerConsume), maxPerConsume), 1);

        private double maxPerConsume = 2;
        private double minPerConsume = 0.2;
        public void OnDaysInc(IDate date)
        {
            if(date.day == 30)
            {
                supplies -= consumes;
            }
        }
    }
}
