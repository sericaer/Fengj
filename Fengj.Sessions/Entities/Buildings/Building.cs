using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fengj.Sessions.Entities.Buildings
{
    public abstract class Building : IBuliding
    {
        public static Func<IBuliding, IEnumerable<IClan2Building>> GetToClanRelations;

        public string name { get; }
        public (int x, int y) pos { get; set; }

        public IEnumerable<IBuliding.IOutput> outputs => isProducing ? _outputs : _outputsNotProducting;

        public bool isProducing => toClansRelations.Any(x => x.labor != null);

        public IEnumerable<IClan2Building> toClansRelations
        {
            get
            {
                return GetToClanRelations(this);
            }
        }

        private List<IBuliding.IOutput> _outputs = new List<IBuliding.IOutput>();
        private List<IBuliding.IOutput> _outputsNotProducting = new List<IBuliding.IOutput>();

        public Building((int x, int y) pos)
        {
            this.pos = pos;
        }

        internal class Output : IBuliding.IOutput
        {
            public IBuliding from { get; }

            public IGood good { get; }

            public Output(IBuliding from, IGood good)
            {
                this.from = from;
                this.good = good;
            }
        }

        internal void AddOutput(IGood good)
        {
            _outputs.Add(new Output(this, good));

            var goodEmpty = Activator.CreateInstance(good.GetType()) as IGood;
            goodEmpty.Value = 0;

            _outputsNotProducting.Add(new Output(this, goodEmpty));
        }

        public void OnDaysInc(IDate date)
        {

        }
    }
}
