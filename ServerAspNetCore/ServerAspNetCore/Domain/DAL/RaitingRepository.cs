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
    public class RaitingRepository: IRepository<Raiting>
    {
        private readonly ZpiDbContext _dbContext;

        public RaitingRepository(ZpiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(Raiting entity) 
        {
                Raiting raiting = _dbContext.Ratings.FirstOrDefault(x => x.IdUser == entity.IdUser &&
                                                       x.IdCourse == entity.IdCourse);

                if(raiting == null)
                {
                    _dbContext.Ratings.Add(entity);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public async Task<bool> Delete(Raiting entity)
        {
                Raiting raiting = _dbContext.Ratings.FirstOrDefault(x => x.IdUser == entity.IdUser &&
                                                       x.IdCourse == entity.IdCourse);

                if(raiting != null)
                {
                    _dbContext.Ratings.Remove(raiting);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public IQueryable<Raiting> Get(Expression<Func<Raiting, bool>> predicate)
        {
                if(predicate == null)
                    return _dbContext.Ratings;
                return _dbContext.Ratings.Where(predicate);
        }

        public Task<Raiting> Get(int idUser, int idCourse)
        {
                Raiting courseTag = _dbContext.Ratings.FirstOrDefault(x => x.IdUser == idUser &&
                                                       x.IdCourse == idCourse);

                return Task.FromResult(courseTag);
        }

        public async Task<List<Raiting>> Get()
        {
                return await _dbContext.Ratings.ToListAsync();
        }

        public Task<Raiting> GetBy(Expression<Func<Raiting, bool>> predicate)
        {
                return Task.FromResult(_dbContext.Ratings.FirstOrDefault(predicate));
        }

        public async Task<bool> Update(Raiting entity)
        {
                _dbContext.Entry(entity).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync() >= 1;
        }
    }
}