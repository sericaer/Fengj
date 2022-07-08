using Fengj.Interfaces;
using Fengj.Sessions.Entities.Buildings;
using Fengj.Sessions.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fengj.Sessions.Entities
{
    public partial class Clan : IClan
    {
        public string name { get; internal set; }

        public (int x, int y) pos { get; set; }

        public IEnumerable<(string desc, double Value)> foodIncome => bulidings.SelectMany(x => x.outputDict.Values).Where(x => x.good is Food).Select(x => (x.from.ToString(), x.good.Value));

        public IClan.IPopulation population { get; }
        public IClan.IConsume consume { get; }

        public Dictionary<Type, IGood> goods { get; }

        public IEnumerable<IBuliding> bulidings => _buildings;

        private List<IBuliding> _buildings;

        public Clan()
        {
            consume = new Consume(this);
            population = new Population(this);
            _buildings = new List<IBuliding>();

            goods = new Dictionary<Type, IGood>();

            goods.Add(typeof(Food), new Food());
        }

        public Clan(string name, (int x, int y) pos, int population, int food) : this()
        {
            this.name = name;
            this.pos = pos;
            this.goods[typeof(Food)].Value = food;
            this.population.total = population;

            _buildings.Add(new Farm(pos));
        }

        public void OnDaysInc(IDate date)
        {
            population.OnDaysInc(date);

            if (date.day == 30)
            {
                goods[typeof(Food)].Value += foodIncome.Sum(x=>x.Value) - consume.total;
            }

            var foodOutputs = bulidings.SelectMany(x => x.outputDict.Values).Where(x => x.good is Food);
        }
    }
}
