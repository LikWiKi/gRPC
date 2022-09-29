namespace Service.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Create(T enitty);
        void Update(T entity);
        void Delete(int id);
    }
}
