using PeopleManagement.Model.Models;
using System.Collections.Generic;

namespace PeopleManagement.Service.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetSubjects();
    }
}
