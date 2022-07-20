using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces.Mods
{
    public interface IInteractionDef
    {
        string name { get; }

        Func<IContext, bool> isValid { get; }
        Action<IContext> Trigger { get; }
    }
}
