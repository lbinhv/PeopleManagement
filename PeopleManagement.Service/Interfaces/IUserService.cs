using PeopleManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Service.Interfaces
{
    public interface IUserService
    {        
        IEnumerable<User> GetUsers();
        void CreateUser(User user);
        void SaveUser();
    }
}
