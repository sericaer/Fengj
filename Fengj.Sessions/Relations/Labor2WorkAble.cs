using Fengj.Interfaces;

namespace Fengj.Sessions.Relations
{
    internal class Labor2WorkAble : ILabor2WorkAble
    {
        public IClan.ILabor labor { get; }
        public IWorkAble workAble { get; }

        public Labor2WorkAble(IClan.ILabor labor, IWorkAble workAble)
        {
            this.labor = labor;
            this.workAble = workAble;
        }
    }
}