using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeopleManagement.Helpers
{
    public class Enums
    {
        public enum GenderEnum
        {
            [Display(Name = "Male")]
            Male = 'M',
            [Display(Name = "Female")]
            Female = 'F'
        }

    }
}