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
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ZpiDbContext _dbContext;

        public CategoryRepository(ZpiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(Category entity)
        {
                Category category = _dbContext.Categories.FirstOrDefault(x => x.IdCategory == entity.IdCategory
                    || x.CategoryName.Equals(entity.CategoryName));

                if(category == null)
                {
                    _dbContext.Categories.Add(entity);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public async Task<bool> Delete(Category entity)
        {
                Category category = _dbContext.Categories.FirstOrDefault(x => x.IdCategory == entity.IdCategory);

                if(category != null)
                {
                    _dbContext.Categories.Remove(category);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
        }

        public async Task<List<Category>> Get()
        {
                return await _dbContext.Categories.ToListAsync();
        }

        public IQueryable<Category> Get(Expression<Func<Category, bool>> predicate)
        {
                if(predicate == null)
                    return _dbContext.Categories;
                return _dbContext.Categories.Where(predicate);
        }

        public Task<Category> Get(int idCategory, int notRequired = 0)
        {
                Category category = _dbContext.Categories.FirstOrDefault(x => x.IdCategory == idCategory);

                return Task.FromResult(category);
        }

        public Task<Category> GetBy(Expression<Func<Category, bool>> predicate)
        {
                return Task.FromResult(_dbContext.Categories.FirstOrDefault(predicate));
        }

        public async Task<bool> Update(Category entity)
        {
                _dbContext.Entry(entity).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync() >= 1;
        }
    }
}