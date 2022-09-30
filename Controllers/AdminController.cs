using AdityaSoftwares.Data;
using AdityaSoftwares.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdityaSoftwares.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicatinUsers> objCatlist = _context.ApplicationUser;
            return View(objCatlist);
            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicatinUsers apuobj)
        {
            if (ModelState.IsValid)
            {
                _context.ApplicationUser.Add(apuobj);
                _context.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(apuobj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var appufromdb = _context.ApplicationUser.Find(id);

            if (appufromdb == null)
            {
                return NotFound();
            }
            return View(appufromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicatinUsers apuobj)
        {
            if (ModelState.IsValid)
            {
                _context.ApplicationUser.Update(apuobj);
                _context.SaveChanges();
                TempData["ResultOk"] = "Data Updated Successfully !";
                return RedirectToAction("Index");
            }

            return View(apuobj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var apufromdb = _context.ApplicationUser.Find(id);

            if (apufromdb == null)
            {
                return NotFound();
            }
            return View(apufromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmp(int? id)
        {
            var deleterecord = _context.ApplicationUser.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _context.ApplicationUser.Remove(deleterecord);
            _context.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }
    }
}
