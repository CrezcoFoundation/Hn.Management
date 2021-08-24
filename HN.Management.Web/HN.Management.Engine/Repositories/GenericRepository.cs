using HN.Management.Engine.Data;
using HN.Management.Engine.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HN.Management.Engine.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        private protected GenericRepository( ApplicationDbContext applicationDbContext )
        {
            ApplicationDbContext = applicationDbContext;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            var query = await ApplicationDbContext.Set<T>().AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }

        public async Task<IQueryable<T>> GetByConditionAsync( Expression<Func<T, bool>> expression )
        {
            var query = await ApplicationDbContext.Set<T>().Where( expression ).AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }

        public async Task<T> AddAsync( T entity )
        {
            if ( entity == null )
            {
                throw new ArgumentNullException( $"{ nameof( AddAsync ) } entity must not be null" );
            }

            try
            {
                await ApplicationDbContext.AddAsync(entity);
                await ApplicationDbContext.SaveChangesAsync();

                return entity;
            }
            catch ( Exception ex )
            {
                throw new Exception( $"{ nameof( entity ) } could not be saved: { ex.Message }" );
            }
        }

        public async Task<T> UpdateAsync( T entity )
        {
            if ( entity == null )
            {
                throw new ArgumentNullException( $"{ nameof( UpdateAsync ) } entity must not be null" );
            }

            try
            {
                ApplicationDbContext.Update( entity );
                await ApplicationDbContext.SaveChangesAsync();

                return entity;
            }
            catch ( Exception ex )
            {
                throw new Exception( $"{ nameof( entity ) } could not be updated: { ex.Message }" );
            }
        }

        public async Task<T> DeleteAsync( T entity )
        {
            if( entity == null )
            {
                throw new ArgumentNullException( $"{ nameof( DeleteAsync ) } entity most not be null" );
            }
            try
            {
                ApplicationDbContext.Remove( entity );
                await ApplicationDbContext.SaveChangesAsync();

                return entity;
            }
            catch ( Exception ex )
            {
                throw new ArgumentNullException( $"{ nameof( entity ) } could not be delete: { ex.Message }" );
            }
        }
    }
}
