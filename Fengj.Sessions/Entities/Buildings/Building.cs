using Fengj.Interfaces;
using Fengj.Interfaces.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fengj.Sessions.Entities.Buildings
{
    public abstract class Building : IBuilding
    {
        public static Func<IBuilding, IEnumerable<IClan2Building>> GetToClanRelations;
        public static Func<IBuilding, IEnumerable<ILabor2WorkAble>> GetToLaborRelations;

        public string name { get; set; }
        public (int x, int y) pos { get; set; }

        public IEnumerable<IBuilding.IOutput> outputs => isProducing ? _outputs : _outputsNotProducting;

        public bool isProducing => toLaborRelations.Any();

        public IEnumerable<IClan2Building> toClansRelations => GetToClanRelations(this);
        public IEnumerable<ILabor2WorkAble> toLaborRelations => GetToLaborRelations(this);

        private List<IBuilding.IOutput> _outputs = new List<IBuilding.IOutput>();
        private List<IBuilding.IOutput> _outputsNotProducting = new List<IBuilding.IOutput>();

        private IBuildingDef def;
 
        public Building((int x, int y) pos, IBuildingDef def)
        {
            this.pos = pos;
            this.def = def;
        }

        internal class Output : IBuilding.IOutput
        {
            public IBuilding from { get; }

            public IGood good { get; }

            public Output(IBuilding from, IGood good)
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

        public IContext GetContext()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IInteractionDef> GetVaildInteractionDefs(IContext context)
        {
            return def.GetVailidInteractionDefs(context);
        }
    }
}
