using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerAspNetCore.Domain.Abstract;
using ServerAspNetCore.Domain.Entities;

namespace ServerAspNetCore.Domain.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string login, string password);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Create(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(int id);
    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<User> Authenticate(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return null;

            var user = await _userRepository.GetBy(x => x.Login == login
                                                  && x.Password.Equals(password));
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.Get();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetBy(x => x.IdUser == id);
        }

        public async Task<User> Create(User user)
        {
            if (_userRepository.GetBy(x => x.Login.Equals(user.Login)).Result != null)
                throw new Exception("Login " + user.Login + " is already taken.");

            if (_userRepository.GetBy(x => x.Email.Equals(user.Email)).Result != null)
                throw new Exception("Email " + user.Email + " is already taken.");

            await _userRepository.Add(user);
            return user;
        }

        public async Task<bool> Update(User userParam)
        {
            var user = _userRepository.GetBy(x => x.IdUser == userParam.IdUser).Result;

            if (user == null)
                throw new Exception("User not found.");

            if (user.Login != userParam.Login)
            {
                if(_userRepository.GetBy(x => x.Login == userParam.Login).Result != null)
                    throw new Exception("Login " + userParam.Login + " is already taken.");
            }

            if (user.Email != userParam.Email)
            {
                if (_userRepository.GetBy(x => x.Email == userParam.Email).Result != null)
                    throw new Exception("Login " + userParam.Email + " is already taken.");
            }

            user.Name = userParam.Name;
            user.Surname = userParam.Surname;
            user.Login = userParam.Login;
            user.Password = userParam.Password;
            user.Email = userParam.Email;

            return await _userRepository.Update(user);

        }

        public async Task<bool> Delete(int id)
        {
            var user = _userRepository.GetBy(x => x.IdUser == id).Result;

            if (user == null)
            {
                throw new Exception("User of id: " + id + " doesn't exist.");
            }

            return await _userRepository.Delete(user);
        }
    }
}

