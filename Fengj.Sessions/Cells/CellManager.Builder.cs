using Fengj.Interfaces;
using Fengj.Interfaces.Mods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Sessions.Cells
{
    partial class CellManager
    {
        public static class Builder
        {
            internal static ICell.IManager Build(IMap map, IEnumerable<IModDef> modDefs)
            {
                var manager = new CellManager();
                manager.map = map;
                manager.dictDefs = modDefs.OfType<ITerrainDef>().ToDictionary(x => x.terrain, y => y);
                return manager;
            }
        }
    }
}
