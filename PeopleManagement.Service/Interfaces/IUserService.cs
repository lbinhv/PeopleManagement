using PeopleManagement.Model.Models;
using PeopleManagement.Service.CommonViewModels;
using System.Collections.Generic;

namespace PeopleManagement.Service.Interfaces
{
    public interface IUserService
    {
        bool CheckNRIC(string value);
        IEnumerable<User> GetUsers(DataTableAjaxPostModel model, out int filteredResultsCount, out int totalResultsCount);
        void CreateUser(User user);
        User GetUserByKey(string key);
    }
}
