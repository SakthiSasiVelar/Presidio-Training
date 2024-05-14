namespace ClinicManagementApp.Repository
{
    public interface IRepository<K , T> where T : class
    {
        public Task<T> Add(T  entity);

        public Task<T> Update(T entity);

        public Task<T> Delete(T entity);

        public Task<T> GetById(K key);

        public Task<List<T>> GetAll();
    }
}
