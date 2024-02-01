using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResfulPractice.Models;
using ResfulPractice.Models.DTO;
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
            Thread.Sleep(3000);
            return Content("Hello Fetch!!", "text/plain", Encoding.UTF8);
        }

        //讀城市
        public IActionResult Cities()
        {
           
            var cities= _context.Addresses.Select(x => x.City).Distinct();  
            return Json(cities);
        }

        //根據城市名稱讀取鄉鎮區
        public IActionResult District(string city)
        {

            var districts = _context.Addresses.Where(a => a.City == city).Select(a => a.SiteId).Distinct();
            return Json(districts);
        }

        //根據鄉鎮區名稱讀取路名
        //public IActionResult Details()
        //{

        //}

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

        //public IActionResult Register(string name, int age = 28)
        //{
        //    if (string.IsNullOrEmpty(name))
        //    {
        //        name = "guest";
        //    }
        //    return Content($"Hello {name}, {age}歲了", "text/plain", Encoding.UTF8);
        //}

        //0130作業
        public IActionResult CheckAccount(string Name)
        {
            if (_context.Members.Any(x => x.Name == Name))
                return Content($"名稱 {Name} 已被註冊");
            else
                return Content($"名稱 {Name} 可以使用");
        }

        public IActionResult Register(UserDTO _user)
        {
            if (string.IsNullOrEmpty(_user.Name))
            {
                _user.Name = "guest";
            }
            // return Content($"Hello {_user.Name}, {_user.Age}歲了, 電子郵件是 {_user.Email}","text/plain", Encoding.UTF8);
            return Content($"{_user.Avatar?.FileName} - {_user.Avatar?.ContentType} - {_user.Avatar?.Length}");
        }


    }
}
