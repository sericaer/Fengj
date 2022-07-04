using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fengj.Maps.HeightMapBuilders
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


            var temp = new Dictionary<(int x, int y), int>();

            var center = (0, 0);
            temp.Add(center, 50);
            foreach (var index in topology.GetNeighbors(center))
            {
                temp.TryAdd(center, 50);
            }

            foreach (var index in mountCoreIndex)
            {
                temp.TryAdd(index, 100);
            }

            IEnumerable<(int x, int y)> curr = temp.Keys;

            while (temp.Count() < positions.Length)
            {
                var needIndexs = curr.SelectMany(x => topology.GetNeighbors(x)).Distinct().Where(x => positions.Contains(x) && !temp.ContainsKey(x)).ToArray();
                foreach (var need in needIndexs)
                {
                    var neighbors = topology.GetNeighbors(need).Where(x => temp.ContainsKey(x));
                    var maxHeightCount = neighbors.Count(x => temp[x] >= 90);
                    if (maxHeightCount == 1)
                    {
                        if (random.Next(0, 100) >= 30)
                        {
                            temp.Add(need, random.Next(85, 95));
                            continue;
                        }
                    }

                    int average = (int)neighbors.SelectMany(x => topology.GetNeighbors(x).Where(x => temp.ContainsKey(x))).Concat(neighbors).Average(x => temp[x]);
                    temp.Add(need, System.Math.Min(System.Math.Max(average + nosieMap[need], -100), 100));
                }

                curr = needIndexs;
            }

            //var sortPairs = temp.OrderBy(x => x.Value).ToArray();
            //for (int i = 0; i < sortPairs.Length; i++)
            //{
            //    var key = sortPairs[i].Key;
            //    var value = sortPairs[i].Value;

            //    var neighbors = topology.GetNeighbors(key);
            //    var average = (int)neighbors.Where(x => temp.ContainsKey(x)).Average(x => temp[x]);

            //    var step = 10-(i * 10 / (sortPairs.Length));

            //    temp[key] = Math.Max((average + value) / 2 - random.Next(step*2, step*5), -100);
            //}

            return temp.ToDictionary(x => x.Key, y => (y.Value + 100) / 200f);
        }
    }
}
