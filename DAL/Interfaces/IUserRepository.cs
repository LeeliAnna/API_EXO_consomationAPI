﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {

        public Task<User> Create(User user);

        public Task<User>? GetByEmail(string email);

        public Task<User>? GetById(int id);

        public Task<IEnumerable<User>> GetAll();

        public Task<bool> Update(User user);

        public Task<bool> Delete(User user);

    }
}
