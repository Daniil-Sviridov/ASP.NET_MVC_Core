namespace MVC_study.Models
{
    public interface ICatalog : IList<Product>
    {

        public void Add(Product product, CancellationToken ct = default);
        
    }

}
