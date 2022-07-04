using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Maps
{
    public partial class Map : IMap
    {
        public Dictionary<(int x, int y), float> dictHeight
        {
            get
            {
                return _dictHeight;
            }
            set
            {
                _dictHeight = value;
                _sortedHeightPairs = dictHeight.OrderBy(x => x.Value).ToArray();
            }
        }

        public Dictionary<(int x, int y), TerrainType> dictTerrain { get; internal set; } = new Dictionary<(int x, int y), TerrainType>();

        public IMap.IToplogoy topology { get;}

        private Dictionary<(int x, int y), float> _dictHeight;
        private KeyValuePair<(int x, int y), float>[] _sortedHeightPairs;

        public Map(IMap.IToplogoy toplogoy)
        {
            this.topology = toplogoy;
        }

        public void SetTerrainPercent(int heightPercent, int humidityPercent)
        {
            dictTerrain.Clear();

            var plainEndIndex = _sortedHeightPairs.Length * heightPercent / 100;

            var hillEndIndex = plainEndIndex + _sortedHeightPairs.Length * (100 - heightPercent) / 100 * 3 / 4;

            var marshEndIndex = plainEndIndex * humidityPercent / 100;

            var waterEndIndex = marshEndIndex * 3 / 4;

            for(int i=0; i< _sortedHeightPairs.Length; i++)
            {
                var curr = _sortedHeightPairs[i];
                if (i <= waterEndIndex)
                {
                    dictTerrain.Add(curr.Key, TerrainType.Water);
                }
                else if (i <= marshEndIndex)
                {
                    dictTerrain.Add(curr.Key, TerrainType.Marsh);
                }
                else if (i <= plainEndIndex)
                {
                    dictTerrain.Add(curr.Key, TerrainType.Plain);
                }
                else if (i <= hillEndIndex)
                {
                    dictTerrain.Add(curr.Key, TerrainType.Hill);
                }
                else
                {
                    dictTerrain.Add(curr.Key, TerrainType.Mount);
                }
            }
        }
    }
}
