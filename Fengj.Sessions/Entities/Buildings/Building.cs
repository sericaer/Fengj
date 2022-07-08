using Fengj.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Sessions.Entities.Buildings
{
    public abstract class Building : IBuliding
    {
        public (int x, int y) pos { get; }

        public Dictionary<Type, IBuliding.IOutput> outputDict { get; } = new Dictionary<Type, IBuliding.IOutput>();

        public Building((int x, int y) pos)
        {
            this.pos = pos;
        }

        internal class Output : IBuliding.IOutput
        {
            public IBuliding from { get; }

            public IGood good { get; }

            public Output(IBuliding from, IGood good)
            {
                this.from = from;
                this.good = good;
            }
        }


    }
}
