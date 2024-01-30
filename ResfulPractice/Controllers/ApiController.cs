using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResfulPractice.Models;
using System.Text;

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
            return Content("Hello Fetch!!", "text/plain", Encoding.UTF8);
        }

        public IActionResult Cities()
        {
           
            var cities= _context.Addresses.Select(x => x.City).Distinct();  
            return Json(cities);
        }
        public IActionResult Avatar(int id = 1)
        {
            //不用_context.Member.Where(m=>m.MemberId=id) 因為Find會自動根據主所以見搜尋
            Member? member = _context.Members.Find(id);
            if (member != null)
            {
                byte[] img = member.FileData;
                if (img != null)
                {
                    return File(img, "image/jpeg");
                }
            }
            return NotFound();
        }
    }
}
