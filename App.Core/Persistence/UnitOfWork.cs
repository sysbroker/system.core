using System;
using System.Linq;
using System.Linq.Expressions;
using App.Core.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;        

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public TEntity FindById<TEntity>(Guid id) where TEntity : Entity
        {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(id));
        }

        public IQueryable<TEntity> FindAll<TEntity>() 
            where TEntity : Entity
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : Entity
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public TEntity Add<TEntity>(TEntity entity)
            where TEntity : Entity
        {   
            var entry = _context.Add(entity);            
            return entry.Entity;
        }

        public TEntity Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            _context.Update(entity);            
            return entity;
        }

        public void Delete<TEntity>(Guid id) where TEntity : Entity
        {
            var entity = this.FindById<TEntity>(id);
            _context.Remove(entity);
        }

        public void Commit()
        {
            _context.SaveChanges();            
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}