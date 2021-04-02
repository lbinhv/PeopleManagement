using System;

namespace PeopleManagement.Model.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string SubjectName { get; set; }
        public int SubjectValue { get; set; }
    }
}
