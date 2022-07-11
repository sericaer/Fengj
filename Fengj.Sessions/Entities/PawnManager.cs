using Fengj.Interfaces;
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

        public IEnumerable<IBuliding> bulidings => all.OfType<IBuliding>();

        private List<IPawn> _all = new List<IPawn>();

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
