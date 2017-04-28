﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sinyoo.CrabyterDb.ASPNetCoreSample.Services;

namespace Sinyoo.CrabyterDb.ASPNetCoreSample.Controllers
{

    public class HomeController : Controller
    {
        private readonly ICrabyterDbServiceProvider crabyterDbService;

        public HomeController(ICrabyterDbServiceProvider crabyterDbServiceProvider)
        {
            crabyterDbService = crabyterDbServiceProvider;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
