using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface IBuliding : IPawn
    {
        bool isProducing { get; }

        IEnumerable<IClan2Building> toClansRelations { get; }

        IEnumerable<IOutput> outputs { get; } 

        public interface IOutput
        {
            IBuliding from { get; }
            IGood good { get; }
        }
    }
}
