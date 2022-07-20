using Fengj.Interfaces.Mods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface IModder
    {
        string[] seeds { get; }
        Dictionary<Type, IModDef> defs { get; }
    }
}
