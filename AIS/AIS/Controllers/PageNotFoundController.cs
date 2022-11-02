﻿using AIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AIS.Controllers;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace AIS.Controllers
{
    public class PageNotFoundController : Controller
    {
        private readonly ILogger<PageNotFoundController> _logger;
        private readonly TopMenus tm;
        private readonly SessionHandler sessionHandler;
        private readonly DBConnection dBConnection;
        public PageNotFoundController(ILogger<PageNotFoundController> logger, SessionHandler _sessionHandler, DBConnection _dbCon, TopMenus _tpMenu)
        {
            _logger = logger;
            sessionHandler = _sessionHandler;
            dBConnection = _dbCon;
            tm = _tpMenu;
        }
        public IActionResult Index()
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
