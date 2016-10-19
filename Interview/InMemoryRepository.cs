using System;
using System.Collections.Generic;
using Interview;

namespace Interview
{
    internal class InMemoryRepository<T> : IRepository<T> 
        where T : IStoreable
    {
        private Dictionary<IComparable, T> repository;

        public InMemoryRepository()
        {
            repository = new Dictionary<IComparable, T>();
        }

        public IEnumerable<T> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(IComparable id)
        {
            throw new NotImplementedException();
        }

        public T FindById(IComparable id)
        {
            throw new NotImplementedException();
        }

        public void Save(T item)
        {
            repository.Add(item.Id, item);
        }
    }
}