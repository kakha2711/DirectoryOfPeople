
using System.Linq.Expressions;

namespace DirectoryOfPeopel.Service.Interface.IRepository;

public interface IRepositoryBase<T> where T : class
{
     T Get(params object[] items);
    IQueryable<T> set(Expression<Func<T, bool>> predicate);
    IQueryable<T> set();
    void Insert(T item);
    void Update(T item);
    void InsertOrUpdate(T item);
    void Delete(T item);
    void Delete(object id);
}