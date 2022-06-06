using System.Collections;

namespace MVC_study.Models
{

    public class Catalog : ICatalog
    {
        object singleowner = new object();

        public Product this[int index] { 
            get 
            {
                return Products[index];
            }
            set
            {
                Products[index] = value;
            }
        }

        private List<Product> Products;

        public int Count { get => Products.Count; }

        public bool IsReadOnly { get => true; }

        public Catalog()
        {
            Products = new List<Product>();
        }

        public void Add(Product item)
        {
            lock (singleowner)
            {
                Products.Add(item);
            }
        }

        public void Clear()
        {
            lock (singleowner)
            {
                Products.Clear();
            }
        }

        public bool Contains(Product item)
        {
           return Products.Contains(item);
        }

        public void CopyTo(Product[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Product> GetEnumerator()
        {
            lock (singleowner)
            {
                return Products.GetEnumerator();
            }
        }

        public int IndexOf(Product item)
        {
            lock (singleowner)
            {
                return Products.IndexOf(item);
            }
        }

        public void Insert(int index, Product item)
        {
            lock (singleowner)
            {
                Products[index] = item;
            }
        }

        public bool Remove(Product item)
        {
            lock (singleowner)
            {
                return Products.Remove(item);
            }
        }

        public void RemoveAt(int index)
        {
            lock (singleowner)
            {
                Products.RemoveAt(index);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
