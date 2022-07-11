using Fengj.Interfaces;
using Fengj.Sessions.Effects;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Sessions.Entities
{
    public partial class Clan
    {
        class Population : IClan.IPopulation
        {
            public static ClanPopChangeEffect changedBase = new ClanPopChangeEffect("BASE", ()=>"BASE", ()=>1.0);

            public int total { get; set; }

            public IEnumerable<(string desc, double percent)> populationChangeds 
            { 
                get 
                { 
                    return _populationChangeds.Union(owner.consumers.SelectMany(x => x.effects).OfType<ClanPopChangeEffect>())
                        .Select(x => (x.desc, x.value)); 
                } 
            }

            private HashSet<IEffect> _populationChangeds = new HashSet<IEffect>();
            private Clan owner;

            public Population(Clan clan)
            {
                this.owner = clan;
                _populationChangeds.Add(changedBase);
            }

            public void OnDaysInc(IDate date)
            {
                if (date.day == 30)
                {
                    total += (int)(total * populationChangeds.Sum(x => x.percent) / 100);
                }
            }
        }
    }
}
