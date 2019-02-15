using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SGPC.Models;
using SGPC.ViewModels;


namespace SGPC.Controllers
{
    public class HomeController : BaseController
    {
		private readonly IStringLocalizer<HomeController> _localizer;
		public HomeController(IStringLocalizer<HomeController> localizer)
		{
			_localizer = localizer;
		}

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Index()
		{
			return View(new TicketViewModel());
		}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
