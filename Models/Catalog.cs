using System.Collections;

namespace MVC_study.Models
{

    public class Catalog : ICatalog
    {
        private readonly ReaderWriterLockSlim _lock;
        private List<Product> _products;

        public Product this[int index]
        {
            get
            {
                try
                {
                    _lock.EnterReadLock();
                    return _products[index];
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
            set
            {

                try
                {
                    _lock.EnterWriteLock();
                    _products[index] = value;
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }
        }

        public int Count
        {
            get
            {
                try
                {
                    _lock.EnterReadLock();
                    return _products.Count;
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
        }

        public bool IsReadOnly => false;

        public Catalog()
        {
            _products = new List<Product>();
            _lock = new ReaderWriterLockSlim();
        }

        public void Add(Product item)
        {
            try
            {
                _lock.EnterWriteLock();
                _products.Add(item);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void Clear()
        {
            try
            {
                _lock.EnterWriteLock();
                _products.Clear();
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public bool Contains(Product item)
        {
            try
            {
                _lock.EnterReadLock();
                return _products.Contains(item);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public void CopyTo(Product[] array, int arrayIndex)
        {
            try
            {
                _lock.EnterReadLock();
                _products.CopyTo(array, arrayIndex);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public IEnumerator<Product> GetEnumerator()
        {
            try
            {
                _lock.EnterReadLock();
                foreach (Product item in _products)
                    yield return item;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public int IndexOf(Product item)
        {
            try
            {
                _lock.EnterReadLock();
                return _products.IndexOf(item);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public void Insert(int index, Product item)
        {
            this.Insert(index, item);
        }

        public bool Remove(Product item)
        {
            try
            {
                _lock.EnterWriteLock();
                return _products.Remove(item);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void RemoveAt(int index)
        {
            try
            {
                _lock.EnterWriteLock();
                _products.RemoveAt(index);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
