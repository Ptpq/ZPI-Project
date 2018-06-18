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
    public class VideoRepository : IRepository<Video>
    {
        private readonly ZpiDbContext _dbContext;

        public VideoRepository(ZpiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(Video entity)
        {
                Video video = _dbContext.Videos.FirstOrDefault(x => x.IdVideo == entity.IdVideo);

                if(video == null)
                {
                    _dbContext.Videos.Add(entity);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public async Task<bool> Delete(Video entity)
        {
                Video video = _dbContext.Videos.FirstOrDefault(x => x.IdVideo == entity.IdVideo);

                if(video != null)
                {
                    _dbContext.Videos.Remove(video);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public IQueryable<Video> Get(Expression<Func<Video, bool>> predicate)
        {
                if(predicate == null)
                    return _dbContext.Videos;
                return _dbContext.Videos.Where(predicate);
        }

        public Task<List<Video>> GetList(Expression<Func<Video, bool>> predicate)
        {
                if (predicate == null)
                    return _dbContext.Videos.ToListAsync();
                return _dbContext.Videos.Where(predicate).ToListAsync();
        }

        public Task<Video> Get(int idVideo, int notRequired = 0)
        {
                Video video = _dbContext.Videos.FirstOrDefault(x => x.IdVideo == idVideo);
                return Task.FromResult(video);
        }

        public async Task<List<Video>> Get()
        {
                return await _dbContext.Videos.ToListAsync();
        }

        public Task<Video> GetBy(Expression<Func<Video, bool>> predicate)
        {
                return Task.FromResult(_dbContext.Videos.FirstOrDefault(predicate));
        }

        public async Task<bool> Update(Video entity)
        {
                _dbContext.Entry(entity).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync() >= 1;
        }
    }
}