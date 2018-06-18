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
    public class AccessCodeRepository : IRepository<AccessCode>
    {
        private readonly ZpiDbContext _dbContext;

        public AccessCodeRepository(ZpiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(AccessCode entity)
        {
                AccessCode access = _dbContext.AccessCodes.FirstOrDefault(x =>x.IdCode == entity.IdCode ||
                                                                              (x.IdCourse == entity.IdCourse
                                                                              && x.Key.Equals(entity.Key)));

                if(access == null)
                {
                    _dbContext.AccessCodes.Add(entity);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public async Task<bool> Delete(AccessCode entity)
        {
                AccessCode access = _dbContext.AccessCodes.FirstOrDefault(x => x.IdCode == entity.IdCode);

                if(access != null)
                {
                    _dbContext.AccessCodes.Remove(entity);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public IQueryable<AccessCode> Get(Expression<Func<AccessCode, bool>> predicate)
        {
                if(predicate == null)
                    return _dbContext.AccessCodes;
                return _dbContext.AccessCodes.Where(predicate);
        }

        public Task<AccessCode> Get(int idCode, int notRequired = 0)
        {
                AccessCode access = _dbContext.AccessCodes.FirstOrDefault(x => x.IdCode == idCode);
                return Task.FromResult(access);
        }

        public async Task<List<AccessCode>> Get()
        {
                return await _dbContext.AccessCodes.ToListAsync();
        }

        public Task<AccessCode> GetBy(Expression<Func<AccessCode, bool>> predicate)
        {
            using(ZpiDbContext db = _dbContext)
            {
                return Task.FromResult(_dbContext.AccessCodes.FirstOrDefault(predicate));
            } 
        }

        public async Task<bool> Update(AccessCode entity)
        {
                _dbContext.Entry(entity).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync() >= 1;
        }
    }
}