using System;
using System.Collections.Generic;
using System.Text;
using AuthenticationAuthorization.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAuthorization.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomizeUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
