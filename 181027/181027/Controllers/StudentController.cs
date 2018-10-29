using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using _181027.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _181027.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _context;
        public StudentController(StudentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }        

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Store(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            //return new JsonResult(student);
            return RedirectToAction("Index");
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Student student)
        {
            var obj = _context.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            obj.RollNumber = student.RollNumber;
            obj.Name = student.Name;

            _context.Students.Update(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Debug.WriteLine(id);
            var obj = _context.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Students.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}