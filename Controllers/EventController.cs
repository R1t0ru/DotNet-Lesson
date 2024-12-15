using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;
using System.Linq;

namespace mvc.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Index (Read all events)
        public IActionResult Index()
        {
            var events = _context.Events.ToList();
            return View(events);
        }

        // Create (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Create (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event eventModel)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(eventModel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(eventModel);
        }

        // Edit (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var eventModel = _context.Events.Find(id);
            if (eventModel == null)
            {
                return NotFound();
            }
            return View(eventModel);
        }

        // Edit (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Event eventModel)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Update(eventModel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(eventModel);
        }

        // Delete (GET)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var eventModel = _context.Events.Find(id);
            if (eventModel == null)
            {
                return NotFound();
            }
            return View(eventModel);
        }

        // Delete (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var eventModel = _context.Events.Find(id);
            if (eventModel != null)
            {
                _context.Events.Remove(eventModel);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // Details (GET)
        [HttpGet]
        public IActionResult Details(int id)
        {
            var eventModel = _context.Events.Find(id);
            if (eventModel == null)
            {
                return NotFound();
            }
            return View(eventModel);
        }
    }
}
