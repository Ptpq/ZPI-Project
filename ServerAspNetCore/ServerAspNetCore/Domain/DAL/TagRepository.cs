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
    public class TagRepository : IRepository<Tag>
    {
        private readonly ZpiDbContext _dbContext;

        public TagRepository(ZpiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(Tag entity)
        {
                Tag tag = _dbContext.Tags.FirstOrDefault(x => x.IdTag == entity.IdTag 
                                                              || x.Name.Equals(entity.Name));

                if(tag == null)
                {
                    _dbContext.Tags.Add(entity);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public async Task<bool> Delete(Tag entity)
        {
                Tag tag = _dbContext.Tags.FirstOrDefault(x => x.IdTag == entity.IdTag);

                if(tag != null)
                {
                    _dbContext.Tags.Remove(tag);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public IQueryable<Tag> Get(Expression<Func<Tag, bool>> predicate)
        {
                if(predicate == null)
                    return _dbContext.Tags;
                return _dbContext.Tags.Where(predicate);
        }

        public Task<Tag> Get(int idTag, int notRequired = 0)
        {
                Tag tag = _dbContext.Tags.FirstOrDefault(x => x.IdTag == idTag);

                return Task.FromResult(tag);
        }

        public async Task<List<Tag>> Get()
        {
                return await _dbContext.Tags.ToListAsync();
        }

        public Task<Tag> GetBy(Expression<Func<Tag, bool>> predicate)
        {
                return Task.FromResult(_dbContext.Tags.FirstOrDefault(predicate));
        }

        public async Task<bool> Update(Tag entity)
        {
                _dbContext.Entry(entity).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync() >= 1;
        }
    }
}