using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using msac_competition.BLL.DTO;
using msac_competition.BLL.Interfaces;
using msac_competition.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using msac_competition.Models;

namespace msac_competition.Controllers
{
    public class HomeController : Controller
    {
        private ITeamService _teamService;
        private ICompetitionService _competitionService;
        private readonly IMapper _mapper;

        public HomeController(ITeamService teamService, ICompetitionService competitionService, IMapper mapper)
        {
            _teamService = teamService ?? throw new ArgumentNullException(Recources.Exceptions.teamServiceNullException);
            _competitionService = competitionService ?? throw new ArgumentNullException(Recources.Exceptions.competitionServiceNullException);
            _mapper = mapper ?? throw new ArgumentNullException(Recources.Exceptions.mapper);
        }

        public IActionResult Index()
        {
            var competitionsDto = _competitionService.GetAll();
            var competitions = _mapper.Map<IList<CompetitionViewModel>>(competitionsDto);
            return View(competitions);
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
