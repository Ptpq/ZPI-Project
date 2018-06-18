using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerAspNetCore.Domain.Abstract;
using ServerAspNetCore.Domain.Entities;

namespace ServerAspNetCore.Domain.Services
{
    public interface ICourseService
    {
        Task<List<Course>> GetCoursesOfUser(int idUser);
    }

    public class CourseService : ICourseService
    {
        private IRepository<Course> _courseRepository;
        private IRepository<Access> _accessRepository;
        private IRepository<User> _userRepository;

        public CourseService(IRepository<Course> courseRepository, 
                             IRepository<Access> accessRepository,
                             IRepository<User> userRepository)
        {
            _courseRepository = courseRepository;
            _accessRepository = accessRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Course>> GetCoursesOfUser(int idUser)
        {
            var accesses = (await _accessRepository.Get()).Where(x => x.IdUser == idUser).ToList();
            List<Course> userCourses = new List<Course>();

            for (int i = 0; i < accesses.Count(); i++)
            {
                Course course = await _courseRepository.GetBy(x => x.IdCourse == accesses[i].IdCourse);
                userCourses.Add(course);
            }

            return userCourses;
        }
    }
}
