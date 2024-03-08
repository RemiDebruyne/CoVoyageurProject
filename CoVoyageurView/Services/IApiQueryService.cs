namespace CoVoyageurView.Services
{
    public interface IApiQueryService<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Get(int id);
        public Task<bool> Post(T entity);
        public Task<bool> Delete(int id);
        public Task<bool> Update(T entity, int id);

    }
}
