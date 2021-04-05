using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static PeopleManagement.Helpers.Enums;

namespace PeopleManagement.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(10)]
        public string NRIC { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1)]
        public string Gender { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public DateTime AvaiableDate { get; set; }
        public List<SubjectModel> Subjects { get; set; }
        public bool IsEdit { get; set; }
        public UserModel()
        {
            NRIC = string.Empty;
            Name = string.Empty;
            Birthday = DateTime.Now;
            AvaiableDate = DateTime.Now;
        }
    }
}