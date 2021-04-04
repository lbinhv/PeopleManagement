using PeopleManagement.Model.Models;
using System;
using System.Collections.Generic;

namespace PeopleManagement.Service.Interfaces
{
    public interface IUserSubjectsService
    {
        void CreateUserSubjects(IEnumerable<UserSubject> data, Guid userId);
    }
}
