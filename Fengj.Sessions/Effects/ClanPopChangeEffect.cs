using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Sessions.Effects
{
    class ClanPopChangeEffect : IEffect
    {
        public object from { get; }

        public string desc => funcGetDesc();

        public double value => funcGetValue();


        private Func<string> funcGetDesc;
        private Func<double> funcGetValue;

        public ClanPopChangeEffect(object from, Func<string> funcGetDesc, Func<double> funcGetValue)
        {
            this.from = from;
            this.funcGetDesc = funcGetDesc;
            this.funcGetValue = funcGetValue;
        }
    }
}
