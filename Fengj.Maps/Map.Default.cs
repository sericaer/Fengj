using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Maps
{
    public partial class Map
    {
        public static IMap defaultHexMap;
        public static IMap defaultRectMap;

        static Map()
        {
            defaultHexMap = Builder.Build("DEFAULT", 10, MapType.Hexagon);
            defaultHexMap.SetTerrainPercent(80, 20);

            defaultRectMap = Builder.Build("DEFAULT", 10, MapType.Rectangle);
            defaultRectMap.SetTerrainPercent(80, 20);
        }
    }
}
