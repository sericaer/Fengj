using Fengj.Interfaces.Mods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface IInteractiveAble
    {
        IEnumerable<IInteractionDef> GetVaildInteractionDefs(IContext context);
    }

    public interface IContext
    {
        ISession session { get; }
        IInteractiveAble target { get; }
    }
}
