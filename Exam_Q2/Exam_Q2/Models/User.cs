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
        [Display(Name = "FirstName", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FirstNameRequired")]
        public string FirstName { get; set; }
        [Display(Name = "LastName", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LastNameRequired")]
        public string LastName { get; set; }
        public int Age { get; set; }
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource))]
        public string Email { get; set; }
    }
}
