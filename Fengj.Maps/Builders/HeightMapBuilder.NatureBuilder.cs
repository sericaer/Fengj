using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fengj.Maps.Builders
{
    partial class HeightMapBuilder
    {
        class NatureBuilder : HeightMapBuilder
        {
            public override Dictionary<(int x, int y), float> Build(int startIndex, int endIndex, IMap.IToplogoy topology, Random random)
            {
                var positions = Enumerable.Range(startIndex, endIndex - startIndex)
                    .SelectMany(x => Enumerable.Range(startIndex, endIndex - startIndex).Select(y => (x, y)))
                    .ToArray();

                var nosieMap = positions.ToDictionary(key => key, value => random.Next(-50, 20));

                var mountCoreIndex = new HashSet<(int x, int y)>();
                while (mountCoreIndex.Count < System.Math.Max(positions.Length / 200, 3))
                {
                    mountCoreIndex.Add(positions[random.Next(0, positions.Length)]);
                }


                var rslt = new Dictionary<(int x, int y), int>();

                var center = (0, 0);
                rslt.Add(center, 50);
                foreach (var index in topology.GetNeighbors(center))
                {
                    rslt.TryAdd(center, 50);
                }

                foreach (var index in mountCoreIndex)
                {
                    rslt.TryAdd(index, 100);
                }

                IEnumerable<(int x, int y)> curr = rslt.Keys;

                while (rslt.Count() < positions.Length)
                {
                    var needIndexs = curr.SelectMany(x => topology.GetNeighbors(x)).Distinct().Where(x => positions.Contains(x) && !rslt.ContainsKey(x)).ToArray();
                    foreach (var need in needIndexs)
                    {
                        var neighbors = topology.GetNeighbors(need).Where(x => rslt.ContainsKey(x));
                        var maxHeightCount = neighbors.Count(x => rslt[x] >= 90);
                        if (maxHeightCount == 1)
                        {
                            if (random.Next(0, 100) >= 30)
                            {
                                rslt.Add(need, random.Next(85, 95));
                                continue;
                            }
                        }

                        int average = (int)neighbors.SelectMany(x => topology.GetNeighbors(x).Where(x => rslt.ContainsKey(x))).Concat(neighbors).Average(x => rslt[x]);
                        rslt.Add(need, System.Math.Min(System.Math.Max(average + nosieMap[need], -100), 100));
                    }

                    curr = needIndexs;
                }


                return rslt.ToDictionary(x => x.Key, y => (y.Value + 100) / 200f);
            }
        }
    }
}
