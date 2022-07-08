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

            public IEnumerable<(string desc, double percent)> populationChangeds => _populationChangeds.Select(x => (x.desc, x.value));

            private HashSet<IEffect> _populationChangeds = new HashSet<IEffect>();

            public Population(Clan clan)
            {
                _populationChangeds.Add(changedBase);
                _populationChangeds.UnionWith(clan.consume.effects.OfType<ClanPopChangeEffect>());
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
