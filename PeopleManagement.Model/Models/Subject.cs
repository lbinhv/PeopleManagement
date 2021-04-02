using System;

namespace PeopleManagement.Model.Models
{
    public class Subject
    {
        public Guid Id { get; set; }        
        public string SubjectName { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Subject()
        {
            DateCreated = DateTime.UtcNow;
        }
    }
}
