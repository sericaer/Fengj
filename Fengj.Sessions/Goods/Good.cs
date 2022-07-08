using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Sessions.Goods
{
    public abstract class Good : IGood
    {
        public double Value { get; set; }
    }
}
