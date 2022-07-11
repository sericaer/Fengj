namespace Fengj.Interfaces
{
    public interface IClan2Building
    {
        IClan clan { get; }
        IBuliding buliding { get; }

        IClan.ILabor labor { get; }
    }
}