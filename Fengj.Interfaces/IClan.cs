using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface IClan : IPawn
    {
        public int population { get; }

        //public IEnumerable<(string desc, decimal value)> populationChangeds { get; }

        public double supplies { get; }

        public double consumes { get; }

        public double consumesPer { get; }
    }
}
