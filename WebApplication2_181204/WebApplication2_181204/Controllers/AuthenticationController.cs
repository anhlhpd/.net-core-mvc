using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2_181204.Models;

namespace WebApplication2_181204.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly CustomerContext _context;
        public AuthenticationController(CustomerContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            var existCustomer = _context.Customer.Where(c => c.Email == customer.Email).SingleOrDefault();
            if (existCustomer != null)
            {
                customer.Salt = existCustomer.Salt;
                customer.EncryptPassword();
                if (customer.Password == existCustomer.Password)
                {
                    Credential credential = new Credential(existCustomer.Id);
                    return Json(credential);
                    //Request.HttpContext.Session.SetString("loggedUser", existCustomer.Email);
                    //return Redirect("/Home");
                }               
                
            }
            //Response.StatusCode = 403;
            return Json(customer);
            //return View(customer);
        }
    }
}