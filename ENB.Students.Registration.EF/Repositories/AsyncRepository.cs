﻿
using ENB.Students.Registration.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ErrorOr;


namespace ENB.Students.Registration.EF.Repositories
{
    /// <summary>
    /// Serves as a generic base class for concrete repositories to support basic CRUD oprations on data in the system.
    /// </summary>
    /// <typeparam name="T">The type of entity this repository works with. Must be a class inheriting DomainEntity.</typeparam>
    public abstract class AsyncRepository<T, U> : IAsyncRepository<T, int>, IAsyncDisposable where T : DomainEntity<int>
        where U :  IErrorOr<T> 
    {
        private readonly StudentsRegistrationContext _studentsRegistrationContext  ;

        public AsyncRepository(StudentsRegistrationContext studentsRegistrationContext)
        {
            _studentsRegistrationContext = studentsRegistrationContext;
        }
       
        /// <summary>
        /// Finds an item by its unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the item in the database.</param>
        /// <param name="includeProperties">An expression of additional properties to eager load. For example: x => x.SomeCollection, x => x.SomeOtherCollection.</param>
        /// <returns>The requested item when found, or null otherwise.</returns>
        public virtual async Task<T> FindById(int id, params Expression<Func<T, object>>[] includeProperties)
        {
         
               var item= await FindAll(includeProperties).SingleOrDefaultAsync(x => x.Id == id);
            
            return item!;
        }

        /// <summary>
        /// Returns an IQueryable of all items of type T.
        /// </summary>
        /// <param name="includeProperties">An expression of additional properties to eager load. For example: x => x.SomeCollection, x => x.SomeOtherCollection.</param>
        /// <returns>An IQueryable of the requested type T.</returns>
        public virtual IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> items = _studentsRegistrationContext.Set<T>();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }

            return items;
        }

        /// <summary>
        /// Returns an IQueryable of items of type T.
        /// </summary>
        /// <param name="predicate">A predicate to limit the items being returned.</param>
        /// <param name="includeProperties">An expression of additional properties to eager load. For example: x => x.SomeCollection, x => x.SomeOtherCollection.</param>
        /// <returns>An IEnumerable of the requested type T.</returns>
        public async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _studentsRegistrationContext.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }

            return await (Task<IEnumerable<T>>)(items.Where(predicate));
        }

        /// <summary>
        /// Adds an entity to the underlying DbContext.
        /// </summary>
        /// <param name="entity">The entity that should be added.</param>
        public virtual async Task Add(T entity, CancellationToken cancellationToken)
        {

            await _studentsRegistrationContext.Set<T>().AddAsync(entity,cancellationToken);

        }


        /// <summary>
        /// Removes an entity from the underlying DbContext.
        /// </summary>
        /// <param name="entity">The entity that should be removed.</param>
        public virtual  void  Remove(T entity, CancellationToken cancellationToken)
        {
          _studentsRegistrationContext.Set<T>().Remove(entity);

        }

        /// <summary>
        /// Removes an entity from the underlying DbContext. Calls <see cref="FindById" /> to resolve the item.
        /// </summary>
        /// <param name="id">The ID of the entity that should be removed.</param>
        public virtual async Task Remove(int id,CancellationToken cancellationToken)
        {
               Task<T> entity = FindById(id);
                 T castEntity = await entity;

            _studentsRegistrationContext.Set<T>().Remove(castEntity);

        }


        /// <summary>
        /// Removes an entity from the underlying DbContext. Calls <see cref="FindById" /> to resolve the item.
        /// </summary>
        /// <param name="id">The ID of the entity that should be removed.</param>
        public virtual async Task AddRange(IEnumerable<T> entities)
        {
            await _studentsRegistrationContext.Set<T>().AddRangeAsync(entities);

        }

        /// <summary>
        /// Removes an entity from the underlying DbContext. Calls <see cref="FindById" /> to resolve the item.
        /// </summary>
        /// <param name="id">The ID of the entity that should be removed.</param>
        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _studentsRegistrationContext.Set<T>().RemoveRange(entities);

        }
        /// <summary>
        /// Disposes the underlying data context.
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            if (_studentsRegistrationContext != null)
            {
                await   _studentsRegistrationContext.DisposeAsync();
            }
        }

        //public void Remove(T entity, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
