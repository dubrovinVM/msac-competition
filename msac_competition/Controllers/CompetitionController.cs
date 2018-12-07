using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using msac_competition.BLL.Interfaces;
using msac_competition.Models;
using Microsoft.AspNetCore.Mvc;

namespace msac_competition.Controllers
{
    public class CompetitionController : Controller
    {
        private ITeamService _teamService;
        private ICompetitionService _competitionService;
        private readonly IMapper _mapper;

        public CompetitionController(ITeamService teamService, ICompetitionService competitionService, IMapper mapper)
        {
            _teamService = teamService ?? throw new ArgumentNullException(Resources.Exceptions.teamServiceNullException);
            _competitionService = competitionService ?? throw new ArgumentNullException(Resources.Exceptions.competitionServiceNullException);
            _mapper = mapper ?? throw new ArgumentNullException(Resources.Exceptions.mapper);
        }

        public IActionResult Index()
        {
            var competitionsDto = _competitionService.GetAll();
            var competitions = _mapper.Map<IList<CompetitionViewModel>>(competitionsDto);
            return View("Index", competitions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{
        //    //db.Phones.Add(phone);
        //    //await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}