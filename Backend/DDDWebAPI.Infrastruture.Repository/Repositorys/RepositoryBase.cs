using DDDWebAPI.Domain.Core.Interfaces.Repositorys;
using DDDWebAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DDDWebAPI.Infrastruture.Repository.Repositorys
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : Domain.Models.Base
    {
        private readonly MySqlContext _context;
        private DbSet<TEntity> data;
        public RepositoryBase(MySqlContext Context)
        {
            _context = Context;
            data = _context.Set<TEntity>();
        }
        string errorMessage = string.Empty;
        
        public IEnumerable<TEntity> GetAll()
        {
            return data.AsEnumerable();
        }
        public TEntity GetById(int id)
        {
            return data.SingleOrDefault(s => s.id == id);
        }
        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            data.Add(entity);
            _context.SaveChanges();
        }
        public virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.SaveChanges();
        }
        public void Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            data.Remove(entity);
            _context.SaveChanges();
        }
        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }

}
