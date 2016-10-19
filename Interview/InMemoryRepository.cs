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
            return repository.Values;
        }

        public void Delete(IComparable id)
        {
            repository.Remove(id);
        }

        public T FindById(IComparable id)
        {
            return repository[id];
        }

        public void Save(T item)
        {
            repository.Add(item.Id, item);
        }
    }
}