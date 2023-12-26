using System.Linq.Expressions;

namespace SaleManagment.Server.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T - can be any class like Orders , windows ...    
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll(); //get all T
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity); // delete multiple items
    }
}
