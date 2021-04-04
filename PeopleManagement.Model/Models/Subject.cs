using System;
using System.Collections.Generic;

namespace PeopleManagement.Model.Models
{
    public class Subject
    {
        public Guid SubjectId { get; set; }        
        public string SubjectName { get; set; }
      
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual IEnumerable<UserSubject> UserSubjects { get; set; }

        public Subject()
        {
            DateCreated = DateTime.UtcNow;
        }
    }
}
