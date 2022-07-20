using Fengj.Interfaces;
using Fengj.Interfaces.Mods;
using Fengj.Sessions.Entities.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fengj.Sessions.Entities
{
    public partial class PawnManager : IPawn.IManager
    {
        public IEnumerable<IPawn> all => _all;

        public IEnumerable<IClan> clans => all.OfType<IClan>();

        public IEnumerable<IBuilding> bulidings => all.OfType<IBuilding>();

        private List<IPawn> _all = new List<IPawn>();

        private Dictionary<Type, IModDef> dictDef = new Dictionary<Type, IModDef>();

        public PawnManager(Dictionary<Type, IModDef> modDefs)
        {
            dictDef.Add(typeof(Farm), modDefs[typeof(IFarmDef)]);
        }

        public void AddPawn<T>((int x, int y) pos) where T : class, IPawn
        {
            var pawn = Activator.CreateInstance(typeof(T), pos, dictDef[typeof(T)]) as T;
            _all.Add(pawn);
        }

        public void AddPawn(IPawn pawn)
        {
            _all.Add(pawn);
        }

        public void RemovePawn(IPawn pawn)
        {
            _all.Remove(pawn);
        }
    }
}
