using Fengj.Interfaces;
using Fengj.Sessions.Goods;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Sessions.Entities
{
    public partial class Clan
    {
        public class GoodManager : IClan.IGoodManager
        {
            public IGood good { get; }

            public IEnumerable<(string desc, double Value)> income 
            { 
                get
                {
                    return owner.toBuildingRelations.SelectMany(x => x.buliding.outputDict.Values)
                        .Where(x => x.good.GetType() == good.GetType())
                        .Select(x => (x.from.ToString(), x.good.Value));
                }
            }

            public IEnumerable<(string desc, double Value)> consume 
            { 
                get
                {
                    return owner.consumers.Where(x=>x.good.GetType() == good.GetType())
                        .Select(x => (x.ToString(), x.good.Value));
                }
            }

            private IClan owner;

            public void OnDaysInc(IDate date)
            {
                if (date.day == 30)
                {
                    good.Value += income.Sum(x => x.Value) - consume.Sum(x => x.Value);
                }
            }

            public GoodManager(IClan clan, IGood good)
            {
                this.owner = clan;
                this.good = good;
            }
        }
    }
}
