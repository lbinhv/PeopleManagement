using System;

namespace PeopleManagement.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        PeopleManagementEntities Init();
    }
}
