using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface ISession
    {
        IDate date { get; }
        IMap map { get; }

        ICell.IManager cells { get; }
        IClan player { get; }
        IPawn.IManager pawns { get; }

        IRelationManager relationMgr { get; }
        void DaysInc();
    }
}
