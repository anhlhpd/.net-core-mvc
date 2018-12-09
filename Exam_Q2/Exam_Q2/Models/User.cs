using Exam_Q2.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Q2.Models
{
    public class User
    {
        public long Id { get; set; }
        [Display(Name = "FirstName", ResourceType = typeof(Views_Users_Create))]
        public string FirstName { get; set; }
        [Display(Name = "LastName", ResourceType = typeof(Views_Users_Create))]
        public string LastName { get; set; }
        [Display(Name = "Age", ResourceType = typeof(Views_Users_Create))]
        public int Age { get; set; }
        [Display(Name = "Email", ResourceType = typeof(Views_Users_Create))]
        public string Email { get; set; }
    }
}
