using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface IInitData
    {
        string seed { get; }

        int mapSize { get; }
        int mapHeightPercent { get; }
        int mapHumidityPercent { get; }
    }
}
