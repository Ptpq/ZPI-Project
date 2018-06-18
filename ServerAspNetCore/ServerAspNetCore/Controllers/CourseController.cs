using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ServerAspNetCore.Domain.Entities;
using ServerAspNetCore.Domain.Abstract;
using ServerAspNetCore.Domain.DAL;
using ServerAspNetCore.Domain.Services;
using ServerAspNetCore.Domain.ViewModel;

namespace ServerAspNetCore.Controllers
{
  [Route("api/Course")]
  public class CourseController : Controller
  {
    private IRepository<Course> _courseRepository;
      private ICourseService _courseService;

    public CourseController(IRepository<Course> courseRepository, ICourseService courseService)
    {
        _courseRepository = courseRepository;
        _courseService = courseService;
    }
    
    [HttpGet("Courses"), Produces("application/json")]
    public async Task<IActionResult> GetCourses()
    {
      var courses = await _courseRepository.Get();
      return Json(courses);
    }

    [HttpGet("SearchCourses/{searchString}"), Produces("application/json")]
    public async Task<IActionResult> GetSerachedCourses(string searchString)
    {
        List<Course> courses;
        if (String.IsNullOrEmpty(searchString) || searchString.Trim() == "undefined")
        {
            courses = await _courseRepository.Get();
            return Json(courses);
        }

        courses = (await _courseRepository.Get()).Where(x => x.Title.ToLower().Contains(searchString.Trim().ToLower())).ToList();



        return Json(courses);
    }

      [HttpGet("UserCourses/{idUser}"), Produces("application/json")]
      public async Task<IActionResult> GetCoursesOfUser(int idUser)
      {
          var courses = await _courseService.GetCoursesOfUser(idUser);
          return Json(courses);
      }

        [HttpPost("AddCourse")]
        public async Task<IActionResult> AddCourse([FromBody]CourseViewModel course)
    {
      if (_courseRepository.GetBy(x => x.Title == course.Title).Result == null)
      {
          Course courseObj = new Course()
          {
              Title = course.Title,
              Description = course.Description,
              IdCategory = course.IdCategory
          };

          await _courseRepository.Add(courseObj);
          return Ok();
      }

        return BadRequest();
    }

      [HttpGet("getCoursesByCategory/{categoryName}")]
      public async Task<IActionResult> GetCourseByCategory(string categoryName)
      {

          var courses = _courseRepository.Get(y => y.Category.CategoryName.Equals(categoryName));
          if (courses == null)
              return BadRequest();
          return Json(courses);
      }
    }
}
