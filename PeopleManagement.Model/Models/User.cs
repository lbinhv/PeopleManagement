using System;
using System.Collections.Generic;

namespace PeopleManagement.Model.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string NRIC { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime AvaiableDate { get; set; }
        public virtual IEnumerable<Subject> Subjects { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public User()
        {
            DateCreated = DateTime.UtcNow;
        }
    }
}
