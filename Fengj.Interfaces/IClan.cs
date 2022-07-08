using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface IClan : IPawn
    {
        public IConsume consume { get; }
        public IPopulation population { get; }

        Dictionary<Type, IGood> goods { get; }

        IEnumerable<(string desc, double Value)> foodIncome { get; }

        public interface IConsume
        {
            double total { get; }
            double average { get; }

            IEnumerable<IEffect> effects { get; }
        }

        public interface IPopulation
        {
            int total { get; set; }

            IEnumerable<(string desc, double percent)> populationChangeds { get; }

            void OnDaysInc(IDate date);
        }
    }

    public interface IEffect
    {
        object from { get; }

        string desc { get; }
        double value { get; }
    }

    public interface IGood
    {
        double Value { get; set; }
    }

}
