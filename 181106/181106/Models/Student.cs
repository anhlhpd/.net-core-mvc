using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _181106.Models
{
    public class Student : IValidatableObject
    {
        [Key]
        public string RollNumber { get; set; }
        [CantBeMe ("AQ")]
        [Required(ErrorMessage = "Vui lòng nhập tên của bạn.")]
        [MaxLength(100, ErrorMessage = "Tên quá dài.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Vui lòng nhập email đúng định dạng.")]
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public StudentStatus Status { get; set; }

        public List<Mark> Marks { get; set; }

        public Student()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = StudentStatus.Activated;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (FirstName.Contains("Hung"))
            {
                return new List<ValidationResult>()
                {
                    new ValidationResult("Wrong name", new []{ "FirstName"})
                };
            }
            return new List<ValidationResult>()
            {
                ValidationResult.Success;
            }
    
    }
    public class CantBeMeAttribute : ValidationAttribute
    {
        private string _ignoreName;
        public CantBeMeAttribute (string ignoreName)
        {
            _ignoreName = ignoreName;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Student student = validationContext.ObjectInstance as Student;
            var firstName = value as string;
            if (firstName.Contains("Me"))
            {
                return new ValidationResult("Blac blac");
            }
            return ValidationResult.Success;
        }
    }
    public enum StudentStatus
    {
        Activated = 1,
        Deactivated = 0
    }
}
