using System.Core.Abstractions;
using System.Linq;

namespace System.Core.Persistence
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {        
        protected readonly IUnitOfWork _unitOfWork;
//        private readonly IEventBus _eventBus;

        protected Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
//            _eventBus = eventBus;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _unitOfWork.FindAll<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {            
            return _unitOfWork.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _unitOfWork.Delete<TEntity>(entity.Id);
        }

        public TEntity FindById(Guid id)
        {
            return _unitOfWork.FindById<TEntity>(id);
        }
    }
}