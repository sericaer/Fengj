using Fengj.Interfaces;
using System;
using System.Collections.Generic;

namespace Fengj.Maps
{
    public class Map : IMap
    {
        public Dictionary<(int x, int y), float> dictHeight { get; internal set; }

        public Dictionary<(int x, int y), TerrainType> dictTerrain { get; internal set; } = new Dictionary<(int x, int y), TerrainType>();

        public IMap.IToplogoy topology { get;}

        public Map(IMap.IToplogoy toplogoy)
        {
            this.topology = toplogoy;
        }

        public void SetTerrainPercent(int heightPercent, int humidityPercent)
        {
            dictTerrain.Clear();

            foreach (var elem in dictHeight)
            {
                var terrainType = TerrainType.Plain;
                if (elem.Value * 100 > heightPercent)
                {
                    terrainType = TerrainType.Hill;
                }
                if (elem.Value * 100 > heightPercent + (99 - heightPercent) * 3 / 4)
                {
                    terrainType = TerrainType.Mount;
                }
                if (elem.Value * 100 < humidityPercent)
                {
                    terrainType = TerrainType.Marsh;
                }
                if (elem.Value * 100 < humidityPercent * 3 / 4)
                {
                    terrainType = TerrainType.Water;
                }

                dictTerrain.Add(elem.Key, terrainType);
            }
        }
    }
}
