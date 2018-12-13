using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication2_181204.Models;

namespace WebApplication2_181204.Controllers
{
    public static class CheckAdminPermissionMiddlewareExtensions
    {
        public static IApplicationBuilder CheckAdminPermission(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckAdminPermission>();
        }
    }

    public class CheckAdminPermission
    {
        private readonly RequestDelegate _next;
        private readonly CustomerContext _context;

        public CheckAdminPermission(RequestDelegate next, CustomerContext context)
        {
            _next = next;
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            bool isAdmin = context.Session.GetString("loggedUser") != null;
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("Access denied");
            }
            var tokenKey = context.Request.Headers["Authorization"].ToString();
            tokenKey.Replace("Basic ", "");
            //var credential = _context.Credential.SingleOrDefault(t => )
            //if (context.Request.Headers.ContainsKey("Authorization"))
            //{
            //    isAdmin = true;
            //}

            //if (isAdmin)
            //{
            //    await _next(context);
            //}

            //context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
            //await context.Response.WriteAsync("Access denied");
        }
    }
}
