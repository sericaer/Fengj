using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface ISession
    {
        IDate date { get; }
        IMap map { get; }
        IPawn.IManager pawns { get; }

        void DaysInc();
    }
}
