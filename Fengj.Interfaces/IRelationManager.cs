using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface IRelationManager
    {
        IEnumerable<IClan2Building> clan2BuidingRelations { get; }
        IEnumerable<ILabor2WorkAble> labor2WorkAbleRelations { get; }
        void AddClan2Building(IClan clan, IBuilding buliding);

        void AddLabor2WorkAble(IClan.ILabor labor, IWorkAble workAble);
        void RemoveLabor2WorkAble(Func<ILabor2WorkAble, bool> selector);
        void RemoveRelation(ILabor2WorkAble relation);
    }
}
