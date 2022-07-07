using Fengj.Interfaces;
using System;
using System.Collections.Generic;

namespace Fengj.Sessions
{
    public partial class Session : ISession
    {
        public IDate date { get; internal set; }

        public IMap map { get; internal set; }

        public IPawn.IManager pawns { get; internal set; }

        public void DaysInc()
        {
            date.day++;

            foreach(var pawn in pawns.all)
            {
                pawn.OnDaysInc(date);
            }
        }
    }
}
