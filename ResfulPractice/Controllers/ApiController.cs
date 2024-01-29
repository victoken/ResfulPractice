using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResfulPractice.Models;

namespace ResfulPractice.Controllers
{
    public class ApiController : Controller
    {
        private readonly MyDBContext _context;

        public ApiController(MyDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cities()
        {
           
            var cities= _context.Addresses.Select(x => x.City).Distinct();  
            return Json(cities);
        }

    }
}
