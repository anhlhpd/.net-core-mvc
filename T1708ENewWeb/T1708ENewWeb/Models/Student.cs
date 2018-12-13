using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace T1708ENewWeb.Models
{
    public class Student
    {
        [Key]
        public string RollNumber { get; set; }
        [DauPhaiQuangAnh("QuangAnh", MessageLoiCuaHung = "Đâu phải Quang Anh.")]
        [Required(ErrorMessage = "Vui lòng nhập tên của bạn")]        
        [MaxLength(30, ErrorMessage = "Tên quá dài, lớn nhất là 30 ký tự.")]
        public string FirstName { get; set; }
        [MaxLength(30, ErrorMessage = "Họ quá dài, lớn nhất là 30 ký tự.")]
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
       
    }

    public class DauPhaiQuangAnhAttribute : ValidationAttribute, IClientModelValidator
    {
        private string _ignoreName;
        public string MessageLoiCuaHung { get; set; }

        public DauPhaiQuangAnhAttribute(string ignoreName)
        {
            _ignoreName = ignoreName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Student student = validationContext.ObjectInstance as Student;
            var firstName = value as string;
            if (firstName.Contains(_ignoreName))
            {
                return new ValidationResult(MessageLoiCuaHung);
            }
            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Attributes["data-val"] = "true";
            context.Attributes["data-val-dauphaiquanganh"] = MessageLoiCuaHung;
            context.Attributes["data-val-dauphaiquanganh-ignorename"] = _ignoreName;
            context.Attributes["data-val-dauphaiquanganh-ignorename02"] = "ThanhTung";
        }
    }

    public enum StudentStatus
    {
        Activated = 1,
        Deactivated = 0
    }
}
