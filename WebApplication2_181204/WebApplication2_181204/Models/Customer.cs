using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2_181204.Models
{
    public class Customer
    {
        public Customer()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = CustomerStatus.Active;
        }
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CustomerStatus Status { get; set; }

        public void GenerateSalt()
        {
            this.Salt = Guid.NewGuid().ToString();
        }

        public void EncryptPassword()
        {
            this.Password += this.Salt;
            var algorithm = MD5.Create();
            var hashPassword = algorithm.ComputeHash(Encoding.UTF8.GetBytes(this.Password));
            this.Password = Convert.ToBase64String(hashPassword);
        }
    }

    public enum CustomerStatus
    {
        Active = 1,
        Inactive = 0
    }
}
