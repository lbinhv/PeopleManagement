using PeopleManagement.Data.Infrastructure;
using PeopleManagement.Model.Models;
using System;
using System.Linq;

namespace PeopleManagement.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {}

        public User GetUserByName(string userName)
        {
            var user = this.DbContext.Users.Where(c => c.Name == userName).FirstOrDefault();

            return user;
        }

        public override void Update(Guid Id, User entity)
        {
            entity.DateUpdated = DateTime.Now;
            
            base.Update(entity.UserId, entity);
        }

    }
}
