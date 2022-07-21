namespace MVC_study.Models
{
    public interface ICatalog : IList<Product>, IEquatable<Catalog>
    {

        public void Add(Product product, CancellationToken ct = default);
        
    }

}
