using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecondBackEnd.Data;
using SecondBackEnd.Models;

namespace SecondBackEnd.Controllers
{
    [Authorize]
    public class TestHomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TestHomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Test> objTestList = _db.Tests;
            return View(objTestList);
        }
    }
}
