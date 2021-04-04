using PeopleManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PeopleManagement.Data
{
    public class PeopleManagementSeedData : DropCreateDatabaseIfModelChanges<PeopleManagementEntities>
    {
        public PeopleManagementSeedData(PeopleManagementEntities dbContext)
        {
            Seed(dbContext);
        }
        protected override void Seed(PeopleManagementEntities context)
        {
            GetUsers().ForEach(c => context.Users.Add(c));
            GetSubjects().ForEach(g => context.Subjects.Add(g));

            context.Commit();
        }

        private static List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    UserId = Guid.NewGuid(),
                    NRIC = "S1234567A",
                    Name = "Tom",
                    Gender = "M", 
                    Birthday = new DateTime(1990,01,01),
                    AvaiableDate = DateTime.Now
                },
                new User
                {
                    UserId = Guid.NewGuid(),
                    NRIC = "S7654321A",
                    Name = "Green",
                    Gender = "F", 
                    Birthday = new DateTime(1999,11,21),
                    AvaiableDate = DateTime.Now
                }
            };
        }

        private static List<Subject> GetSubjects()
        {
            return new List<Subject>
            {
                new Subject
                {
                    SubjectId = Guid.NewGuid(),
                    SubjectName = "English"
                },
                new Subject
                {
                    SubjectId = Guid.NewGuid(),
                    SubjectName = "Math"
                },
                new Subject
                {
                    SubjectId = Guid.NewGuid(),
                    SubjectName = "Science"
                }
            };
        }
    }
}
