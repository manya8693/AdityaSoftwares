using AdityaSoftwares.Data;
using AdityaSoftwares.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdityaSoftwares.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VisitorsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Visitors> objCatlist = _context.Visitor;
            return View(objCatlist);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Visitors visobj)
        {
            if (ModelState.IsValid)
            {
                _context.Visitor.Add(visobj);
                _context.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(visobj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var appufromdb = _context.Visitor.Find(id);

            if (appufromdb == null)
            {
                return NotFound();
            }
            return View(appufromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Visitors apuobj)
        {
            if (ModelState.IsValid)
            {
                _context.Visitor.Update(apuobj);
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
            var apufromdb = _context.Visitor.Find(id);

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
            var deleterecord = _context.Visitor.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _context.Visitor.Remove(deleterecord);
            _context.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }
    }
}
