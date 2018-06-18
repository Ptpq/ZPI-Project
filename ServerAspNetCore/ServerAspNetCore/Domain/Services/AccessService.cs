using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerAspNetCore.Domain.Abstract;
using ServerAspNetCore.Domain.Entities;

namespace ServerAspNetCore.Domain.Services
{
    public interface IAccessService
    {
        Task<Access> Create(Access access);
    }

    public class AccessService : IAccessService
    {
        private IRepository<Access> _accessRepository;
        private IRepository<Course> _courseRepository;
        private IRepository<User> _userRepository;

        public AccessService(IRepository<Access> accessRepository, IRepository<Course> courseRepository, IRepository<User> userRepository)
        {
            _accessRepository = accessRepository;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }

        public async Task<Access> Create(Access newAccess)
        {
            if (_userRepository.GetBy(x => x.IdUser == newAccess.IdUser).Result == null)
            {
                throw new Exception("User o id " + newAccess.IdUser + " nie istinieje");
            }
            if (_courseRepository.GetBy(x => x.IdCourse == newAccess.IdCourse).Result == null)
            {
                throw new Exception("Kurs o id " + newAccess.IdUser + " nie istinieje");
            }
            if (_accessRepository.GetBy(x => (x.IdUser == newAccess.IdUser) && (x.IdCourse == newAccess.IdCourse)).Result != null)
            {
                throw new Exception("Access o IdUser " + newAccess.IdUser + " i idCourse " + newAccess.IdCourse + " juz istnieje");
            }

            await _accessRepository.Add(newAccess);
            return newAccess;
        }
    }
}
