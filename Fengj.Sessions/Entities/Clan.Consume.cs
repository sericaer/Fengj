using System;
using System.Collections.Generic;
using System.Text;
using Fengj.Interfaces;
using Fengj.Sessions.Effects;

namespace Fengj.Sessions.Entities
{
    partial class Clan
    {
        public class Consume : IClan.IConsume
        {
            public double total => average * owner.population.total;

            public double average => Math.Round(Math.Min(Math.Max(owner.supplies / 6 / owner.population.total, minPerConsume), maxPerConsume), 1);

            public IEnumerable<IEffect> effects => _effects;

            private Clan owner;

            private const double maxPerConsume = 2;
            private const double minPerConsume = 0.2;

            private List<IEffect> _effects = new List<IEffect>();

            public Consume(Clan clan)
            {
                owner = clan;

                var popChangeEffect = new ClanPopChangeEffect(
                    from :this, 
                    funcGetDesc:() => 
                    {
                        if (average < 0.5)
                        {
                            return "J2";
                        }
                        if (average < 0.8)
                        {
                            return "J1";
                        }
                        if (average > 1.5)
                        {
                            return "F";
                        }
                        return "N";
                    },
                    funcGetValue:() => 
                    {
                        if (average < 0.5)
                        {
                            return -5;
                        }
                        if (average < 0.8)
                        {
                            return -2;
                        }
                        if (average > 1.5)
                        {
                            return +1;
                        }
                        return 0;
                    });

                _effects.Add(popChangeEffect);
            }
        }
    }
}
