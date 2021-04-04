using PeopleManagement.Data.Infrastructure;
using PeopleManagement.Model.Models;

namespace PeopleManagement.Data.Repositories
{
    public class UserSubjectsRepository : RepositoryBase<UserSubject>, IUserSubjectsRepository
    {
        public UserSubjectsRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}
