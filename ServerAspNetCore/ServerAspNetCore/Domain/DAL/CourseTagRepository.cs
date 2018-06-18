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
    public class CourseTagRepository : IRepository<CourseTag>
    {
        private readonly ZpiDbContext _dbContext;

        public CourseTagRepository(ZpiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(CourseTag entity)
        {
                CourseTag courseTag = _dbContext.CourseTags.FirstOrDefault(x => x.IdCourse == entity.IdCourse &&
                                                       x.IdTag == entity.IdTag);

                if(courseTag == null)
                {
                    _dbContext.CourseTags.Add(entity);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public async Task<bool> Delete(CourseTag entity)
        {
                CourseTag courseTag = _dbContext.CourseTags.FirstOrDefault(x => x.IdCourse == entity.IdCourse &&
                                                       x.IdTag == entity.IdTag);

                if(courseTag != null)
                {
                    _dbContext.CourseTags.Remove(courseTag);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public IQueryable<CourseTag> Get(Expression<Func<CourseTag, bool>> predicate)
        {
                if(predicate == null)
                    return _dbContext.CourseTags;
                return _dbContext.CourseTags.Where(predicate);
        }

        public Task<CourseTag> Get(int idCourse, int idTag)
        {
                CourseTag courseTag = _dbContext.CourseTags.FirstOrDefault(x => x.IdCourse == idCourse &&
                                                       x.IdTag == idTag);
                return Task.FromResult(courseTag);
        }

        public async Task<List<CourseTag>> Get()
        {
                return await _dbContext.CourseTags.ToListAsync();
        }

        public Task<CourseTag> GetBy(Expression<Func<CourseTag, bool>> predicate)
        {
                return Task.FromResult(_dbContext.CourseTags.FirstOrDefault(predicate));
        }

        public async Task<bool> Update(CourseTag entity)
        {
                _dbContext.Entry(entity).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync() >= 1;
        }
    }
}