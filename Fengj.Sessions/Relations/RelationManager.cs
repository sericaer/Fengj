using Fengj.Interfaces;
using System.Collections.Generic;

namespace Fengj.Sessions.Relations
{
    class RelationManager : IRelationManager
    {
        public IEnumerable<IClan2Building> clan2BuidingRelations => _clan2BuidingRelations;

        private List<IClan2Building> _clan2BuidingRelations = new List<IClan2Building>();

        public void AddClan2Building(IClan clan, IBuliding buliding)
        {
            _clan2BuidingRelations.Add(new Clan2Building(clan, buliding));
        }
    }
}
