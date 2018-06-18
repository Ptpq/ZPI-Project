using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerAspNetCore.Domain.Abstract;
using ServerAspNetCore.Domain.DAL;
using ServerAspNetCore.Domain.Entities;

namespace ServerAspNetCore.Controllers
{
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private IRepository<Category> _categoryRepository;
        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("Categories"), Produces("application/json")]
        public async Task<IActionResult> GetCategories()
        {
            var courses = await _categoryRepository.Get();
            return Json(courses);
        }
    }
}