using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Sessions.Entities
{
    public partial class Clan
    {
        public class LaborManager : IClan.ILaborManager
        {
            public IEnumerable<IClan.ILabor> all => _all;

            private Clan owner;
            private List<IClan.ILabor> _all = new List<IClan.ILabor>();

            private const int popPerLaber = 200;

            public LaborManager(Clan clan)
            {
                this.owner = clan;
            }

            public void OnDaysInc(IDate date)
            {
                int laborCount = owner.population.total / popPerLaber;

                while(_all.Count < laborCount)
                {
                    _all.Add(new Labor(owner));
                }
                while (_all.Count > laborCount)
                {
                    _all.Remove(_all.Last());
                }
            }
        }

        public class Labor : IClan.ILabor
        {
            public IClan from { get; }

            public Labor(IClan owner)
            {
                this.from = owner;
            }
        }
    }
}
