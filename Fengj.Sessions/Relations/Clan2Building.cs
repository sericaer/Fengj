using Fengj.Interfaces;

namespace Fengj.Sessions.Relations
{
    internal class Clan2Building : IClan2Building
    {
        public IClan clan { get; }
        public IBuliding buliding { get; }

        public IClan.ILabor labor { get; set; }

        public Clan2Building(IClan clan, IBuliding buliding)
        {
            this.clan = clan;
            this.buliding = buliding;
        }
    }
}