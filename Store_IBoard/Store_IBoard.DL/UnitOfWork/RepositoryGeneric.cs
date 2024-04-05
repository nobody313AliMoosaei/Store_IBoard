using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.UnitOfWork
{
    public class RepositoryGeneric<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _dbSet;
        private ApplicationDbContext.ApplicationDBContext _context;
        public RepositoryGeneric(ApplicationDbContext.ApplicationDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Entity
        {
            get
            {
                return _dbSet.AsQueryable();
            }
        }

        public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> _where = null)
        {
            try
            {
                if (_where == null)
                    _where = _where = o => true;
                return await _dbSet.Where(_where).ToListAsync<TEntity>();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> _where = null)
        {
            try
            {
                if (_where == null)
                    _where = _where = o => true;
                return _dbSet.Where(_where).AsQueryable<TEntity>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //public async Task<List<TEntity>> Get()
        //{
        //    return await _dbSet.ToListAsync<TEntity>();
        //}
        public async Task<bool> InsertEntity(TEntity Entity)
        {
            _dbSet.Add(Entity);
            if ((await _context.SaveChangesAsync()) > 0)
                return true;
            return false;
        }
        public async Task<bool> UpdateEntity(TEntity Entity)
        {
            _dbSet.Update(Entity);
            if ((await _context.SaveChangesAsync()) > 0)
                return true;
            return false;
        }
        public async Task<bool> DeleteEntity(TEntity Entity)
        {
            _dbSet.Remove(Entity);
            if ((await _context.SaveChangesAsync()) > 0)
                return true;
            return false;
        }
        public async Task<bool> DeleteEntity(List<TEntity> Entity)
        {
            _dbSet.RemoveRange(Entity);
            if ((await _context.SaveChangesAsync()) > 0)
                return true;
            return false;
        }
        public async Task<bool> DeleteEntity(string Id)
        {
            var item = await Entity.Where(e => e.GetType().GetProperty("Id").ToString() == Id).FirstOrDefaultAsync();
            if (item == null) return false;
            _dbSet.Remove(item);
            if ((await _context.SaveChangesAsync()) > 0)
                return true;
            return false;
        }
    }
}
