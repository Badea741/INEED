public interface IRepo<TEntity> where TEntity : class
{
    void Add(TEntity entity);
    IQueryable<TEntity> GetAll();
    void Update(TEntity entity);
    void Delete(TEntity entity);
}