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
        public async Task<IActionResult> Index()
        {
            crabyterDbService.HttpContext = this.HttpContext;
            var studyList = await crabyterDbService.GetStudyList();
            return View(studyList);
        }

        [Authorize]
        public async Task<ActionResult> Details(int id)
        {
            var study = await crabyterDbService.GetStudyById(id);
            return View(study);
        }
    }
}