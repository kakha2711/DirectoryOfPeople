using System.Linq.Expressions;

namespace DirectoryOfPeopel.Service.Interface.Repository;

public interface IRepositoryBase<T> where T : class
{
    T Get(params object[] items);
    IQueryable<T> set(Expression<Func<T,bool>> predicate);
    IQueryable<T> set();
    void insert(T item);
    void update(T item);
    void InsertOrUpdate(T item);
    void delete(T item);
    void delete(object id);
}