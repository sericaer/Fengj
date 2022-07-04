using Fengj.Interfaces;
using System;

namespace Fengj.Sessions
{
    public partial class Session : ISession
    {
        public IMap map { get; internal set; }
    }
}
