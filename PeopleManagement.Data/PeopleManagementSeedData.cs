using PeopleManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Data
{
    public class PeopleManagementSeedData : DropCreateDatabaseIfModelChanges<PeopleManagementEntities>
    {
        protected override void Seed(PeopleManagementEntities context)
        {
            
        }

        private static List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    NRIC = "S1234567A",
                    Name = "Tom",
                    Gender = char.Parse("M"),
                    Birthday = new DateTime(1990,01,01),
                    AvaiableDate = DateTime.Now
                },
                new User
                {
                    NRIC = "S7654321A",
                    Name = "Green",
                    Gender = char.Parse("F"),
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
                    SubjectName = "English",
                    UserId = Guid.NewGuid()
                }
            };
        }
    }
}
