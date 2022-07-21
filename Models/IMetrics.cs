namespace MVC_study.Models
{
    public interface IMetrics : IList<string>
    {
        public void Add(Metrics metrics, CancellationToken ct = default);
    }
}
