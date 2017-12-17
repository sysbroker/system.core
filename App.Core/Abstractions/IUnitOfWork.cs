using System;
using System.Linq;
using System.Linq.Expressions;

namespace App.Core.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        TEntity FindById<TEntity>(Guid id) where TEntity : Entity;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IQueryable<TEntity> FindAll<TEntity>() where TEntity : Entity;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IQueryable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> predicate) 
            where TEntity : Entity;        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        TEntity Add<TEntity>(TEntity entity) where TEntity : Entity;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        TEntity Update<TEntity>(TEntity entity) where TEntity : Entity;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <typeparam name="TEntity"></typeparam>
        void Delete<TEntity>(Guid id) where TEntity : Entity;
        /// <summary>
        /// 
        /// </summary>
        void Commit();

        /// <summary>
        /// 
        /// </summary>
        void Rollback();
    }
}