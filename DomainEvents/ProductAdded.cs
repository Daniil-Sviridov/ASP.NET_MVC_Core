using MVC_study.Models;

namespace MVC_study.DomainEvents
{
    public class ProductAdded : IDomainEvent
    {
        public Product Product { get; }

        public ProductAdded(Product product)
        {
            Product = product;
        }
    }
}
