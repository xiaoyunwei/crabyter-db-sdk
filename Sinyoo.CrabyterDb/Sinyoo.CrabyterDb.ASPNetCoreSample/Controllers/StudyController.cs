using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sinyoo.CrabyterDb.ASPNetCoreSample.Services;

namespace Sinyoo.CrabyterDb.ASPNetCoreSample.Controllers
{
    public class StudyController : Controller
    {
        private readonly ICrabyterDbServiceProvider crabyterDbService;

        public StudyController(ICrabyterDbServiceProvider crabyterDbServiceProvider)
        {
            crabyterDbService = crabyterDbServiceProvider;
        }

        [Authorize]
        public IActionResult List()
        {
            return View();
        }
    }
}