using Fengj.Interfaces;
using Fengj.Interfaces.Mods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Sessions.Cells
{
    class Cell : ICell
    {

        public (int x, int y) pos { get; }
        public TerrainType terrain => map.dictTerrain[pos];

        private IMap map;
        private Dictionary<TerrainType, ITerrainDef> dictDefs;

        public Cell((int x, int y) pos, IMap map, Dictionary<TerrainType, ITerrainDef> dictDefs)
        {
            this.pos = pos;
            this.map = map;
            this.dictDefs = dictDefs;
        }

        public IEnumerable<IInteractionDef> GetVaildInteractionDefs(IContext context)
        {
            return dictDefs[terrain].GetVailidInteractionDefs(context);
        }
    }
}
