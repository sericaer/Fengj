using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface IRelationManager
    {
        IEnumerable<IClan2Building> clan2BuidingRelations { get; }

        void AddClan2Building(IClan clan, IBuliding buliding);
    }
}
