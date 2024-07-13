using CVA.Entity.Entities;

namespace CVA.Repository.Interface.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity?> GetById(object id);
        Task<List<TEntity>> GetAll();
        Task<TEntity> Insert(TEntity entidade);
        Task<TEntity> Update(TEntity entidade);
        Task Delete(TEntity entidade);
        Task DeleteById(object id);
    }
}
