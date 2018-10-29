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

        [HttpGet("/Student")]
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
            return RedirectToAction("Index");
        }

        [HttpGet("/Student/{id:int}")]
        public IActionResult GetById(long id)
        {
            var item = _context.Students.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPut("/Student/{id:int}")]
        public ActionResult<Student> Edit(long id, Student student)
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
            return new JsonResult(_context);
        }

        [HttpDelete("/Student/{id:int}")]
        public IActionResult Delete(long id)
        {
            var obj = _context.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Students.Remove(obj);
            _context.SaveChanges();
            return new JsonResult(_context.Students.Find(id));
        }
    }
}