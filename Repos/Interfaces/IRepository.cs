using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repos.Interfaces
{
    public interface IRepository<T>
    {
        public IQueryable<T> Get();
        public T Get(string id);
        public T Create(T _);
        public void Update(string id, T _in);
        public void Remove(T _in);
        public void Remove(string id);
    }
}
