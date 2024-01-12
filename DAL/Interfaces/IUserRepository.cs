using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {

        public Task Create(User user);

        public Task? GetByEmail(string email);

        public Task? GetById(int id);

        public Task GetAll();

        public Task<bool> Update(User user);

        public Task<bool> Delete(User user);

    }
}
