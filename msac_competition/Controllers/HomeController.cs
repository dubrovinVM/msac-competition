using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using msac_competition.BLL.DTO;
using msac_competition.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using msac_competition.Models;

namespace msac_competition.Controllers
{
    public class HomeController : Controller
    {
        private IBaseService<TeamDTO, int> teamService;
        private IBaseService<CompetitionDTO, int> competitionService;

        public HomeController(IBaseService<TeamDTO, int> _teamService, IBaseService<CompetitionDTO, int> _competitionService)
        {
            teamService = _teamService;
            competitionService = _competitionService;
        }

        public IActionResult Index()
        {
            var competitions = competitionService.GetAll();
            return View(competitions.ToArray());
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

        public IActionResult Privacy()
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
