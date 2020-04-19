using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repos.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T Get(string id);
        T Create(T _);
        void Update(string id, T _in);
        void Remove(T _in);
        void Remove(string id);
    }
}
