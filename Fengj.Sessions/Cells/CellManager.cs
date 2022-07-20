using Fengj.Interfaces;
using Fengj.Interfaces.Mods;
using System.Collections.Generic;

namespace Fengj.Sessions.Cells
{
    partial class CellManager : ICell.IManager
    {
        private Dictionary<(int x, int y), ICell> _all = new Dictionary<(int x, int y), ICell>();

        private IMap map;
        private Dictionary<TerrainType, ITerrainDef> dictDefs;

        public ICell this[(int x, int y) key]
        {
            get
            {
                if(!_all.ContainsKey(key))
                {
                    _all.Add(key, new Cell(key, map, dictDefs));
                }

                return _all[key];
            }
        }
    }
}
