
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DirectoryOfPeopel.Service.Interface.IRepository;

namespace DirectoryOfPeople.Repository.Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{

    private readonly DirectoryOfPeopleDbContext _context;
    private readonly DbSet<T> _dbSet;

    public RepositoryBase(DirectoryOfPeopleDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }


    public T Get(params object[] id) => _dbSet.Find(id) ?? throw new KeyNotFoundException($"Record with key {id} not found");

    public IQueryable<T> set(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);

    public IQueryable<T> set() => _dbSet;

    public void Insert(T item) => _dbSet.Add(item);

    public void Update(T item)
    {
        _dbSet.Attach(item);
        _context.Entry(item).State = EntityState.Modified;
    }

    public void InsertOrUpdate(T item)
    {
        EntityEntry<T> entry = _context.Entry(item);

        if (entry == null || entry.State == EntityState.Deleted)
            Insert(item);
        else
            Update(item);
    }

    public void Delete(object id) => Delete(Get(id));

    public void Delete(T item)
    {
        if (_context.Entry(item).State == EntityState.Deleted)
            _dbSet.Attach(item);

        _dbSet.Remove(item);
    }
}