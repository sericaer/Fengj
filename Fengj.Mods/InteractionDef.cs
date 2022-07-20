using Fengj.Interfaces;
using Fengj.Interfaces.Mods;
using System;

namespace Fengj.Mods
{
    internal class InteractionDef : IInteractionDef
    {
        public string name { get; internal set; }

        public Func<IContext, bool> isValid { get; internal set; }

        public Action<IContext> Trigger { get; internal set; }

    }
}