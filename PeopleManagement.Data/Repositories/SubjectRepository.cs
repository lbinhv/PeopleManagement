﻿using PeopleManagement.Data.Infrastructure;
using PeopleManagement.Model.Models;

namespace PeopleManagement.Data.Repositories
{
   public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository    
    {
        public SubjectRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
