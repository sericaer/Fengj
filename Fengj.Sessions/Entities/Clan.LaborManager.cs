using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WeakEvents;

namespace Fengj.Sessions.Entities
{
    public partial class Clan
    {
        public class LaborManager : IClan.ILaborManager
        {
            public static Publisher<IClan.ILabor> OnRemoveLabor = new Publisher<IClan.ILabor>();
            public static Func<IClan.ILabor, ILabor2WorkAble> GetToWorkAbleRelation;

            public IEnumerable<IClan.ILabor> all
            {
                get
                {
                    int laborCount = owner.population.total / popPerLaber;

                    while (_all.Count < laborCount)
                    {
                        _all.Add(new Labor(owner));
                    }
                    while (_all.Count > laborCount)
                    {
                        var needRemove = _all.Last();

                        OnRemoveLabor.Raise(needRemove);

                        _all.Remove(needRemove);
                    }

                    return _all;
                }
            }

            private Clan owner;
            private List<IClan.ILabor> _all = new List<IClan.ILabor>();

            private const int popPerLaber = 200;

            public LaborManager(Clan clan)
            {
                this.owner = clan;
            }
        }

        public class Labor : IClan.ILabor
        {
            public IClan from { get; }

            public bool isWorking => toWorkAbleRelation != null;

            public ILabor2WorkAble toWorkAbleRelation => LaborManager.GetToWorkAbleRelation(this);

            public Labor(IClan from)
            {
                this.from = from;
            }
        }
    }
}
