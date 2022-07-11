using Fengj.Interfaces;
using Fengj.Sessions.Effects;
using Fengj.Sessions.Goods;
using System;
using System.Collections.Generic;

namespace Fengj.Sessions.Entities
{
    public class LivingConsumer : IClan.IConsumer
    {
        public IGood good { get; } = new Food();

        public double average
        {
            get
            {
                var foodMgr = owner.goodMgrs[typeof(Food)];
                
                var rslt = Math.Round(Math.Min(Math.Max(foodMgr.good.Value / 6 / owner.population.total, minPerConsume), maxPerConsume), 1);

                good.Value = rslt * owner.population.total;
                return rslt;
            }
        }

        public IEnumerable<IEffect> effects => _effects;

        private List<IEffect> _effects = new List<IEffect>();

        private Clan owner;


        private const double maxPerConsume = 2;
        private const double minPerConsume = 0.1;

        public LivingConsumer(Clan clan)
        {
            this.owner = clan;


            var popChangeEffect = new ClanPopChangeEffect(
                from: this,
                funcGetDesc: () =>
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
                funcGetValue: () =>
                {
                    if (average < 0.3)
                    {
                        return -11;
                    }
                    if (average < 0.8)
                    {
                        return -6;
                    }
                    if (average < 0.9)
                    {
                        return -1;
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
