using Fengj.Interfaces;
using System;

namespace Fengj.InitDatas
{

    public class InitData : IInitData
    {
        public string seed { get; set; }

        public int mapSize { get; set; }

        public int mapHeightPercent { get; set; }

        public int mapHumidityPercent { get; set; }

        public InitData()
        {
        }
    }
}
