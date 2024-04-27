
namespace Shopping_DAL_Library
{
    public abstract class AbstractRepository<K, T>  : IRepository<K, T> where T : class
    {
        public List<T> items = new List<T>();
        public async Task <T> Add(T item)
        {
            items.Add(item);
            return item;
        }

        public abstract  Task<T> Delete(K key);

        public async Task<ICollection<T>> GetAll()
        {
            return items.ToList();
        }

        public abstract Task<T> GetByKey(K key);


        public abstract Task<T> Update(T item);
        
    }
}
