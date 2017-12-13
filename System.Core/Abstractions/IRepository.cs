﻿using System.Linq;

namespace System.Core.Abstractions
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {        
        IQueryable<TEntity> GetAll();    
        TEntity Add(TEntity entity);        
        void Delete(TEntity entity);
        TEntity FindById(Guid id);        
    }
}
