﻿using PeopleManagement.Data.Infrastructure;
using PeopleManagement.Model.Models;

namespace PeopleManagement.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByName(string userName);
    }
}
