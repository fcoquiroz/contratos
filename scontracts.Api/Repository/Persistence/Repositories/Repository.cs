using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Repository.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository.Persistence.Repositories
{
    /// <summary>
    /// Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// DbContext
        /// </summary>
        protected readonly DbContext Context;
        public Repository(DbContext _context)
        {
            Context = _context;
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public T Get(int _id)
        {
            return Context.Set<T>().Find(_id);
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="_entity"></param>
        public void Add(T _entity)
        {
            Context.Set<T>().Add(_entity);
        }
        /// <summary>
        /// AddRange
        /// </summary>
        /// <param name="_entities"></param>
        /// <returns></returns>
        public async Task AddRange(IEnumerable<T> _entities)
        {
            await Context.Set<T>().AddRangeAsync(_entities);
        }
        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="_entity"></param>
        public void Remove(T _entity)
        {
            Context.Set<T>().Remove(_entity);
        }
        /// <summary>
        /// RemoveRange
        /// </summary>
        /// <param name="_entities"></param>
        public void RemoveRange(IEnumerable<T> _entities)
        {
            Context.Set<T>().RemoveRange(_entities);
        }
        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        /// <summary>
        /// Find
        /// </summary>
        /// <param name="_predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> _predicate)
        {
            return Context.Set<T>().Where(_predicate).ToList();
        }
        /// <summary>
        /// Single
        /// </summary>
        /// <param name="_predicate"></param>
        /// <returns></returns>
        public T Single(Expression<Func<T, bool>> _predicate)
        {
            return Context.Set<T>().FirstOrDefault(_predicate);
        }
        /// <summary>
        /// Attach
        /// </summary>
        /// <param name="_entity"></param>
        public void Attach(T _entity)
        {
            Context.Entry(_entity).State = EntityState.Modified;
        }
        /// <summary>
        /// AttachRange
        /// </summary>
        /// <param name="_entity"></param>
        public void AttachRange(IEnumerable<T> _entity)
        {
            Context.AttachRange(_entity);
        }
    }

}

