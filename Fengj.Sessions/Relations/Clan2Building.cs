using Fengj.Interfaces;

namespace Fengj.Sessions.Relations
{
    internal class Clan2Building : IClan2Building
    {
        public IClan clan { get; }
        public IBuilding buliding { get; }

        public Clan2Building(IClan clan, IBuilding buliding)
        {
            this.clan = clan;
            this.buliding = buliding;
        }
    }
}