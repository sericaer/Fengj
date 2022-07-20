using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Interfaces
{
    public interface IPawn
    {
        string name { get; }

        (int x, int y) pos { get; set; }

        public interface IManager
        {
            IEnumerable<IPawn> all { get; }

            IEnumerable<IClan> clans { get; }

            IEnumerable<IBuilding> bulidings { get; }

            void AddPawn(IPawn pawn);
            void RemovePawn(IPawn pawn);
        }

        void OnDaysInc(IDate date);
    }
}
