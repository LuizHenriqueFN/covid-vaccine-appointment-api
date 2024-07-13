using CVA.Entity.Entities;
using CVA.Repository;
using CVA.Repository.Interface.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ControleTarefas.Repositorio.Repositorios
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly Context _context;
        protected virtual DbSet<TEntity> EntitySet { get; }

        public BaseRepository(Context context)
        {
            _context = context;
            EntitySet = _context.Set<TEntity>();
        }

        public Task<List<TEntity>> GetAll() => EntitySet.ToListAsync();

        public async Task<TEntity?> GetById(object id)
        {
            return await EntitySet.FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entidade)
        {
            var entityEntry = await EntitySet.AddAsync(entidade);

            await _context.SaveChangesAsync();
            return entityEntry.Entity;

        }

        public async Task<TEntity> Update(TEntity entidade)
        {
            var entityEntry = EntitySet.Update(entidade);

            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task Delete(TEntity entidade)
        {
            EntitySet.Remove(entidade);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(object id)
        {
            var entity = await EntitySet.FindAsync(id);

            if (entity != null)
                await Delete(entity);
        }
    }
}

