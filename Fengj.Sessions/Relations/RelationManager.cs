using Fengj.Interfaces;
using System;
using System.Collections.Generic;

namespace Fengj.Sessions.Relations
{
    class RelationManager : IRelationManager
    {
        public IEnumerable<IClan2Building> clan2BuidingRelations => _clan2BuidingRelations;
        public IEnumerable<ILabor2WorkAble> labor2WorkAbleRelations => _labor2WorkAbleRelations;

        private List<IClan2Building> _clan2BuidingRelations = new List<IClan2Building>();

        private List<ILabor2WorkAble> _labor2WorkAbleRelations = new List<ILabor2WorkAble>();

        public void AddClan2Building(IClan clan, IBuliding buliding)
        {
            _clan2BuidingRelations.Add(new Clan2Building(clan, buliding));
        }

        public void AddLabor2WorkAble(IClan.ILabor labor, IWorkAble workAble)
        {
            _labor2WorkAbleRelations.Add(new Labor2WorkAble(labor, workAble));
        }

        public void RemoveLabor2WorkAble(Func<ILabor2WorkAble, bool> selector)
        {
            _labor2WorkAbleRelations.RemoveAll(x => selector(x));
        }
    }
}
