namespace PeopleManagement.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        PeopleManagementEntities dbContext;
        public PeopleManagementEntities Init()
        {
            return dbContext ?? (dbContext = new PeopleManagementEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
