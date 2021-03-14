using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        public static List<Students> GetStudents()
        {
            List<Students> students = new List<Students>();
            students.Add(new Students() { id = 1, first_name = "Lidi", last_name = "Derogo", age = 10 });
            students.Add(new Students() { id = 2, first_name = "Mindi", last_name = "Alo", age = 20 });
            students.Add(new Students() { id = 3, first_name = "Emeric", last_name = "Meric", age = 8 });
            students.Add(new Students() { id = 4, first_name = "Lucas", last_name = "Thenesis", age = 15 });
            return students;
        }

        [HttpGet]
        public IEnumerable<Students> GetStudents_List()
        {
            return GetStudents();
        }

        [HttpGet("{id}")]
        public ActionResult<Students> GetStudent_ById(int id)
        {
            var student = GetStudents().Find(x => x.id == id);
            if (student != null)
                return student;
            return NotFound();
        }
    }
}
