using System;

namespace PeopleManagement.Models
{
    public class UserViewModel
    {
        public Guid UserId { get; set; }
        public Guid SN { get; set; }
        public string NRIC { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public DateTime AvaiableDate { get; set; }
        public int NumberOfSubjects { get; set; }
        public UserViewModel()
        {
            NRIC = string.Empty;
            Name = string.Empty;
            Birthday = DateTime.Now;
            AvaiableDate = DateTime.Now;
        }
    }
}