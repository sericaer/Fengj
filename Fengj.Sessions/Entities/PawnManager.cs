using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Sessions.Entities
{
    public partial class PawnManager : IPawn.IManager
    {
        public IEnumerable<IPawn> all => _all;

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
