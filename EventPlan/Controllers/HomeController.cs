﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Teste1.Models;

namespace Teste1.Controllers
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

        public IActionResult Sobre()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
      
        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult EventoX()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

 
    }
}