using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SunsetHillsCore.v2.Models;

namespace SunsetHillsCore.v2.Controllers
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

        public IActionResult Solve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solve(string input1, string input2, string input3, string input4, string input5)
        {
            var sunsetHillsModel = new SunsetHills();
            sunsetHillsModel.Height1 = Convert.ToInt32(input1);
            sunsetHillsModel.Height2 = Convert.ToInt32(input2);
            sunsetHillsModel.Height3 = Convert.ToInt32(input3);
            sunsetHillsModel.Height4 = Convert.ToInt32(input4);
            sunsetHillsModel.Height5 = Convert.ToInt32(input5);

            int[] inArray = new int[] {sunsetHillsModel.Height1, sunsetHillsModel.Height2, sunsetHillsModel.Height3, sunsetHillsModel.Height4, sunsetHillsModel.Height5};
            List<int> newArray = new List<int>();
            int count = 1;
            int currentMax = inArray[0];
            newArray.Add(currentMax);

            for (int i = 0; i < inArray.Length; i++)
            {
                if (inArray[i] > currentMax)
                {
                    count++;
                    newArray.Add(inArray[i]);
                    currentMax = inArray[i];
                }

            }

            sunsetHillsModel.Output = ($"{count} buildings can see the sun with heights of [{string.Join(", ", newArray)}]");
            return RedirectToAction("Result", sunsetHillsModel);
        }

        public IActionResult Result(SunsetHills model)
        {
            return View(model);
        }

        public IActionResult Code()
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
