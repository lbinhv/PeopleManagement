using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleManagement.Models
{
    public class SubjectModel
    {
        public Guid Id { get; set; }
        public string SubjectName { get; set; }
        public bool IsChecked { get; set; }
    }
}