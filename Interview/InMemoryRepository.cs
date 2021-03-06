﻿using System;
using System.Collections.Generic;

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
            if (!repository.Remove(id))
            {
                throw new KeyNotFoundException("Requested Id to remove does not exist in repository");
            }
        }

        public T FindById(IComparable id)
        {
            if (!repository.ContainsKey(id))
            {
                return default(T);
            }
            return repository[id];
        }

        public void Save(T item)
        {
            repository[item.Id] = item;
        }
    }
}