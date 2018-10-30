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
            if (!_context.Students.Any())
            {
                _context.Students.Add(new Student
                {
                    Name = "Xuan Hung",
                    RollNumber = "A001"
                });
            }
        }
        
        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }        

        public IActionResult Create()
        {
            return View();
        }
        
        public IActionResult Store(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult GetById(long id)
        {
            var item = _context.Students.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        
        public ActionResult<Student> Edit(long id)
        {
            var obj = _context.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        
        public IActionResult Update(Student student)
        {
            var obj = _context.Students.Find(student.Id);
            if (obj == null)
            {
                return NotFound();
            }

            obj.RollNumber = student.RollNumber;
            obj.Name = student.Name;

            _context.Students.Update(obj);
            _context.SaveChanges();
            return Redirect("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var obj = await _context.Students.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Students.Remove(obj);
            await _context.SaveChangesAsync();
            //return new JsonResult(_context.Students.Find(id));
            return Redirect("Index");
        }
    }
}