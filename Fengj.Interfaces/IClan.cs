using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface IClan : IPawn
    {
        public IConsume consume { get; }
        public IPopulation population { get; }

        public double supplies { get; }

        public interface IConsume
        {
            double total { get; }
            double average { get; }

            IEnumerable<IEffect> effects { get; }
        }

        public interface IPopulation
        {
            int total { get; set; }

            public IEnumerable<(string desc, double percent)> populationChangeds { get; }

            void OnDaysInc(IDate date);
        }
    }

    public interface IEffect
    {
        object from { get; }

        string desc { get; }
        double value { get; }
    }
}
