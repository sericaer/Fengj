using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface IClan : IPawn
    {
        public IPopulation population { get; }
        public IEnumerable<IBuliding> bulidings { get; }

        public Dictionary<Type, IGoodManager> goodMgrs { get; }

        public IEnumerable<IConsumer> consumers { get; }

        public interface IConsumer
        {
            IGood good { get; }

            IEnumerable<IEffect> effects { get; }
        }

        public interface IFoodConsume
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

        public interface IGoodManager
        {
            IGood good { get; }

            IEnumerable<(string desc, double Value)> income { get; }

            IEnumerable<(string desc, double Value)> consume { get; }

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
