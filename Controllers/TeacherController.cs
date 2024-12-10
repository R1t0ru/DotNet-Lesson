using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class TeacherController : Controller
    {
        private static List<Teacher> teachers = new()
        {
            new() {Id = 1, Firstname = "John", Lastname = "Doe", Age = 25},
            new() {Id = 2, Firstname = "Max", Lastname = "Staz", Age = 22},
            new() {Id = 3, Firstname = "Max", Lastname = "Vyes", Age = 23}
        };


        public IActionResult Index()
        {
            return View(teachers);
        }

        public IActionResult ShowDetails(int id)
        {
            Teacher teacher = new Teacher();
            if (id == 10)
            {
                teacher.Firstname = "Jake";
                teacher.Lastname = "Jackson";
                teacher.Id = 10;
            }
            else
            {
                teacher.Firstname = "Patrick";
                teacher.Lastname = "Star";
                teacher.Id = 20;
            }
            return View("ShowDetails", teacher);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                // teacher.Id = teachers.Max(e => e.Id) + 1;
                teachers.Add(teacher);
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }
    }
}

