﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Model.Models
{
    public class UserSubject
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
