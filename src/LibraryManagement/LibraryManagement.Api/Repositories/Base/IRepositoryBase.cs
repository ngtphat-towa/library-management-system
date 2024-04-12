using System.Linq.Expressions;

namespace LibraryManagement.Api.Repositories.Base
{
    public interface IRepositoryBase<TEntity, TIdType>
    {
        Task<IEnumerable<TEntity>> GetAll();
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
