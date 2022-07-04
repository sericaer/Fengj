using Fengj.Interfaces;
using System;

namespace Fengj.Mods
{
    public class Modder : IModder
    {
        public string[] seeds { get; } = new string[]
        {
            "12345",
            "67890"
        };
    }
}
