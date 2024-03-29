﻿using Microsoft.AspNetCore.Mvc;
using ResfulPractice.Models;
using System.Diagnostics;

namespace ResfulPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult JsonTest()
        {
            return View();
        }

        public IActionResult JsonHomework()
        {
            return View();
        }
        public IActionResult First()
        {
            
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        //0131下拉式選單
        public IActionResult Address()
        {
            return View();
        }

        //讀取二進制圖片
        public IActionResult Avatar()
        {
            return View();
        }

        public IActionResult Spots()
        {
            return View();
        }
    }
}
