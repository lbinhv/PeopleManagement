using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Service.Helpers
{
    public class Const
    {
        #region Error
        public const string NRICExist = "The NRIC is exist in the system";
        public const string GenderRequired = "The Gender Field is required.";
        #endregion

        #region Element
        public const string NRIC = "NRIC";
        public const string Gender = "Gender";

        #endregion
    }
}
