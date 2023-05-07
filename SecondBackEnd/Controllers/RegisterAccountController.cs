using Microsoft.AspNetCore.Mvc;
using SecondBackEnd.Data;
using SecondBackEnd.Models;

namespace SecondBackEnd.Controllers
{
    public class RegisterAccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RegisterAccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET
        public IActionResult Register()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Test obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Tests.Add(obj);
                    _db.SaveChanges();
                    TempData["success"] = "User information is created successfully";
                    return RedirectToAction("Index", "TestHome");
                }
                catch (Exception ex)
                {
                   ModelState.AddModelError("Email", "An user has already use this Email Address");
                }
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) { 
                return NotFound();
            
            }
            var recordFromDB = _db.Tests.Find(id);
            if (recordFromDB == null)
            {
                return NotFound();
            }
            return View(recordFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Test obj)
        {
            if (ModelState.IsValid)
            {
                _db.Tests.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "User information is edited successfully";
                return RedirectToAction("Index", "TestHome");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var recordFromDB = _db.Tests.Find(id);
            if (recordFromDB == null)
            {
                return NotFound();
            }
            return View(recordFromDB);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id) {
            var obj = _db.Tests.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Tests.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "User information is deleted successfully";
            return RedirectToAction("Index", "TestHome");
        }
    }
}
