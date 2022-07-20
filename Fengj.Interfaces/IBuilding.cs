using Fengj.Interfaces.Mods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface IBuilding : IPawn, IWorkAble, IInteractiveAble
    {
        bool isProducing { get; }
        IEnumerable<IClan2Building> toClansRelations { get; }

        IEnumerable<ILabor2WorkAble> toLaborRelations { get; }

        IEnumerable<IOutput> outputs { get; } 

        public interface IOutput
        {
            IBuilding from { get; }
            IGood good { get; }
        }
    }

    public interface ILabor2WorkAble
    {
        IClan.ILabor labor { get; }
        IWorkAble workAble { get; }
    }

    public interface IWorkAble
    {
        string name { get; }
    }
}
