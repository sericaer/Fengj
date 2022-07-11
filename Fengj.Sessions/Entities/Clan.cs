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
        public static Func<IClan, IEnumerable<IClan2Building>> GetToBuildingsRelations;

        public string name { get; internal set; }
        public (int x, int y) pos { get; set; }

        public IClan.IPopulation population { get; }
        public Dictionary<Type, IClan.IGoodManager> goodMgrs { get; }
        public IEnumerable<IClan.IConsumer> consumers => _consumers;
        public IEnumerable<IClan2Building> toBuildingRelations
        {
            get
            {
                return GetToBuildingsRelations(this);
            }
        }

        private List<IBuliding> _buildings;
        private List<IClan.IConsumer> _consumers;

        public Clan()
        {
            goodMgrs = new Dictionary<Type, IClan.IGoodManager>();
            _buildings = new List<IBuliding>();
            _consumers = new List<IClan.IConsumer>();

            population = new Population(this);
            _consumers.Add(new LivingConsumer(this));
            goodMgrs.Add(typeof(Food), new GoodManager(this, new Food()));
        }

        public Clan(string name, (int x, int y) pos, int population, int food) : this()
        {
            this.name = name;
            this.pos = pos;
            this.population.total = population;
            this.goodMgrs[typeof(Food)].good.Value = food;

            _buildings.Add(new Farm(pos));
        }

        public void OnDaysInc(IDate date)
        {
            population.OnDaysInc(date);

            foreach(var goodMgr in goodMgrs.Values)
            {
                goodMgr.OnDaysInc(date);
            }
        }
    }
}
