using MlkPwgen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2_181204.Models
{
    public class Credential
    {
        public Credential() { }
        public Credential(long OwnerId)
        {
            this.AccecssToken = PasswordGenerator.Generate(length: 40, allowed: Sets.Alphanumerics);
            this.RefreshToken = PasswordGenerator.Generate(length: 40, allowed: Sets.Alphanumerics);
            this.OwnerId = OwnerId;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Scope = CredentialScope.Basic;
            this.Status = CredentialStatus.Active;
            this.ExpiredAt = DateTime.Now.AddDays(7);
        }
        public string AccecssToken { get; set; }
        public string RefreshToken { get; set; }
        public long OwnerId { get; set; }
        public CredentialScope Scope { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
        public CredentialStatus Status { get; set; }

        public bool IsValid()
        {
            return this.Status != CredentialStatus.Deactive && this.ExpiredAt > DateTime.Now;
        }
    }

    public enum CredentialStatus
    {
        Active = 1,
        Deactive = 0
    }

    public enum CredentialScope
    {
        Basic = 1,
        Video = 2,
        Photo = 3
    }
}
