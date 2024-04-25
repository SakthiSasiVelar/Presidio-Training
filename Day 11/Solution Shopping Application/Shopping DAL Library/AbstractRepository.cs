
namespace Shopping_DAL_Library
{
    public abstract class AbstractRepository<K, T>  : IRepository<K, T> where T : class
    {
        protected List<T> items = new List<T>();
        public T Add(T item)
        {
            items.Add(item);
            return item;
        }

        public abstract T Delete(K key);

        public ICollection<T> GetAll()
        {
            return items.ToList();
        }

        public abstract T GetByKey(K key);


        public abstract T Update(T item);
        
    }
}
