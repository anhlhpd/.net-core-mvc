using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace T1708ENewWeb.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the T1708ENewWebUser class
    public class T1708ENewWebUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public string Address { get; set; }
        [PersonalData]
        public int Gender { get; set; }
    }
}
