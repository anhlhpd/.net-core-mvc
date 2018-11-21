using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _181106.Models
{
    public class Mark : IValidatableObject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        [Range(0, 100)]
        public int SubjectMark { get; set; }
        public string StudentRollNumber { get; set; }
        [ForeignKey("StudentRollNumber")]
        public Student Student { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
