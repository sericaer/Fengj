using Fengj.Interfaces;
using System;
using System.Text;

namespace Fengj.Sessions.Entities
{
    public partial class Clan : IClan
    {
        public string name { get; internal set; }

        public (int x, int y) pos { get; set; }

        public double supplies { get; set; }

        public IClan.IPopulation population { get; }
        public IClan.IConsume consume { get; }

        public Clan()
        {
            consume = new Consume(this);
            population = new Population(this);
        }

        public Clan(string name, (int x, int y) pos, int population, int supplies) : this()
        {
            this.name = name;
            this.pos = pos;
            this.supplies = supplies;
            this.population.total = population;
        }

        public void OnDaysInc(IDate date)
        {
            population.OnDaysInc(date);

            if (date.day == 30)
            {
                supplies -= consume.total;
            }
        }
    }
}
