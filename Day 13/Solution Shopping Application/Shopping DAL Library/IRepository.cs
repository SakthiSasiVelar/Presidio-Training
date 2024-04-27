using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_DAL_Library
{
    public interface IRepository<K,T>where T : class
    {
        Task<T> Add(T item);
        Task<T> GetByKey(K key);
        Task<ICollection<T>> GetAll();
        Task<T> Update(T item);
        Task<T> Delete(K key);
    }
}
