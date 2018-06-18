using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerAspNetCore.Domain.Entities;
using ServerAspNetCore.Domain.Abstract;

namespace ServerAspNetCore.Domain.DAL
{
    public class AccessRepository : IRepository<Access>
    {
        private readonly ZpiDbContext _dbContext;

        public AccessRepository(ZpiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(Access entity)
        {
                Access access = _dbContext.Accesses.FirstOrDefault(x => x.IdUser == entity.IdUser &&
                                                       x.IdCourse == entity.IdCourse);

                if(access == null)
                {
                    _dbContext.Accesses.Add(entity);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public async Task<bool> Delete(Access entity)
        {
                Access access = _dbContext.Accesses.FirstOrDefault(x => x.IdUser == entity.IdUser &&
                                                       x.IdCourse == entity.IdCourse);

                if(access != null)
                {
                    _dbContext.Accesses.Remove(entity);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public IQueryable<Access> Get(Expression<Func<Access, bool>> predicate)
        {
                if(predicate == null)
                    return _dbContext.Accesses;
                return _dbContext.Accesses.Where(predicate);
        }

        public Task<Access> Get(int idUser, int idCourse)
        {
                Access access = _dbContext.Accesses.FirstOrDefault(x => x.IdUser == idUser &&
                                                       x.IdCourse == idCourse);

                return Task.FromResult(access);
        }

        public async Task<List<Access>> Get()
        {
                return await _dbContext.Accesses.ToListAsync();
        }

        public Task<Access> GetBy(Expression<Func<Access, bool>> predicate)
        {
                return Task.FromResult(_dbContext.Accesses.FirstOrDefault(predicate));
        }

        public async Task<bool> Update(Access entity)
        {
                _dbContext.Entry(entity).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync() >= 1;
        }
    }
}