using System;
using System.Collections.Generic;

namespace Fengj.Interfaces
{
    public interface IMap
    {
        IToplogoy topology { get; }
        Dictionary<(int x, int y), float> dictHeight { get; }
        Dictionary<(int x, int y), TerrainType> dictTerrain { get; }

        void SetTerrainPercent(int heightPercent, int humidityPercent);

        public interface IToplogoy
        {
            IEnumerable<(int x, int y)> GetNeighbors((int x, int y) pos);
        }
    }

    public enum TerrainType
    {
        Plain,
        Hill,
        Mount,
        Marsh,
        Water,
    }

    
}
