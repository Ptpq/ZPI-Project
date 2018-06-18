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
    public class UserRepository : IRepository<User>
    {
        private readonly ZpiDbContext _dbContext;

        public UserRepository(ZpiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(User entity)
        {
                User user = _dbContext.Users.FirstOrDefault(x => x.IdUser == entity.IdUser 
                                                                 || x.Login.Equals(entity.Login));

                if(user == null)
                {
                    _dbContext.Users.Add(entity);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public async Task<bool> Delete(User entity)
        {
                User user = _dbContext.Users.FirstOrDefault(x => x.IdUser == entity.IdUser);

                if(user != null)
                {
                    _dbContext.Users.Remove(user);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        {
                if(predicate == null)
                    return _dbContext.Users;
                return _dbContext.Users.Where(predicate);
        }

        public Task<User> Get(int idUser, int notRequired = 0)
        {
                User user = _dbContext.Users.FirstOrDefault(x => x.IdUser == idUser);

                return Task.FromResult(user);
        }

        public async Task<List<User>> Get()
        {
                return await _dbContext.Users.ToListAsync();
        }

        public Task<User> GetBy(Expression<Func<User, bool>> predicate)
        {
                return Task.FromResult(_dbContext.Users.FirstOrDefault(predicate));
        }

        public async Task<bool> Update(User entity)
        {
                _dbContext.Entry(entity).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync() >= 1;
        }
    }
}