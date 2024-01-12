using BLL.Forms;
using BLL.Mapper;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User>? Create(RegisterForm form)
        {
            User? u = await _userRepository.GetByEmail(form.Email);

            if (u == null)
            {
                User user = form.ToUser();

                user.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);

                await _userRepository.Create(user);
                return user;
            }

            return null;
            
        }

        public bool EmailAlreadyUsed(string email)
        {
            return _userRepository.GetByEmail(email) != null;
        }

        public User? GetById(int id)
        {
            return _userRepository.GetById(id).Result;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll().Result;
        }

        public async Task<bool> UpdatePassword(UpdatePasswordForm form)
        {
            User? u = await _userRepository.GetById(form.Id);

            if (u != null)
            {
                if (BCrypt.Net.BCrypt.Verify(form.OldPassword, u.Password))
                {
                    u.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);
                    return _userRepository.Update(u).Result;
                }
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            User? u = await _userRepository.GetById(id);

            if (u is not null)
            {
                return _userRepository.Delete(u).Result;
            }

            return false;
        }

    }
}
