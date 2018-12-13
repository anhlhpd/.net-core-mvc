using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using T1708ENewWeb.Areas.Identity.Data;
using T1708ENewWeb.Models;

[assembly: HostingStartup(typeof(T1708ENewWeb.Areas.Identity.IdentityHostingStartup))]
namespace T1708ENewWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<T1708EIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("T1708EIdentityContextConnection")));

                services.AddDefaultIdentity<T1708ENewWebUser>()
                    .AddEntityFrameworkStores<T1708EIdentityContext>();
            });
        }
    }
}