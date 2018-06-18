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
    public class CourseRepository : IRepository<Course>
    {
        private readonly ZpiDbContext _dbContext;

        public CourseRepository(ZpiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(Course entity)
        {
                Course course = _dbContext.Courses.FirstOrDefault(x => x.IdCourse == entity.IdCourse);

                if(course == null)
                {
                    _dbContext.Courses.Add(entity);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public async Task<bool> Delete(Course entity)
        {
                Course course = _dbContext.Courses.FirstOrDefault(x => x.IdCourse == entity.IdCourse);

                if(course != null)
                {
                    _dbContext.Courses.Remove(course);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public IQueryable<Course> Get(Expression<Func<Course, bool>> predicate)
        {
                if(predicate == null)
                    return _dbContext.Courses;
                return _dbContext.Courses.Where(predicate);
        }

        public Task<Course> Get(int idCourse, int notRequired = 0)
        {
                Course course = _dbContext.Courses.FirstOrDefault(x => x.IdCourse == idCourse);

                return Task.FromResult(course);
        }

        public async Task<List<Course>> Get()
        {
                return await _dbContext.Courses.ToListAsync();
        }

        public Task<Course> GetBy(Expression<Func<Course, bool>> predicate)
        {
                return Task.FromResult(_dbContext.Courses.FirstOrDefault(predicate));
        }

        public async Task<bool> Update(Course entity)
        {
                _dbContext.Entry(entity).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync() >= 1;
        }
    }
}