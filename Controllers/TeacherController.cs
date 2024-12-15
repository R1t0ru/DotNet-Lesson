using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Affiche la liste des enseignants
        public async Task<IActionResult> Index()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return View(teachers);
        }

        // Affiche les détails d'un enseignant
        public async Task<IActionResult> ShowDetails(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // Retourne la vue pour ajouter un enseignant
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // Ajoute un enseignant à la base de données
        [HttpPost]
        public async Task<IActionResult> Add(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Supprime un enseignant
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Retourne la vue pour modifier un enseignant
        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // Met à jour un enseignant existant
        [HttpPost]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }

            var existingTeacher = await _context.Teachers.FindAsync(teacher.Id);
            if (existingTeacher == null)
            {
                return NotFound();
            }

            existingTeacher.Firstname = teacher.Firstname;
            existingTeacher.Lastname = teacher.Lastname;
            existingTeacher.Age = teacher.Age;

            _context.Teachers.Update(existingTeacher);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
