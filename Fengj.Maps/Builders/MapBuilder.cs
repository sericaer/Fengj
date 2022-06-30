using Fengj.Interfaces;
using Fengj.Maps.Toplogoies;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Fengj.Maps.Builders
{
    public class MapBuilder
    {
        public static IMap Build(string seed, int size)
        {
            var map = new Map(new RectangleTopology());

            var algo = SHA1.Create();
            var hash = BitConverter.ToInt32(algo.ComputeHash(Encoding.UTF8.GetBytes(seed)), 0);

            var random = new Random(hash);

            map.dictHeight = HeightMapBuilder.Nature.Build(size/2*-1, size/2, map.topology, random);;
            map.SetTerrainPercent(50, 50);

            return map;
        }
    }
}
