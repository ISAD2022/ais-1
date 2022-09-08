﻿using InspectionSolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InspectionSolution.Controllers;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace InspectionSolution.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly DBConnection dBConnection = new DBConnection();
        private readonly SessionHandler sessionHandler = new SessionHandler();

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            sessionHandler.DisposeUserSession();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult DoLogin(LoginModel login)
        {
             var user=dBConnection.AutheticateLogin(login);
            if (user.ID != 0)
            {
                return RedirectToAction("Index", "Home");
            }else
            {
                TempData["Message"] = String.Format("Incorrect UserName or Password");
                return RedirectToAction("Index", "Login");
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}