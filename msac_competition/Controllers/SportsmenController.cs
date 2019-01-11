using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using msac_competition.BLL.Interfaces;
using msac_competition.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace msac_competition.Controllers
{
    public class SportsmenController : Controller
    {
        private ISportmanService _sportmanService;
        private ICoachService _сoachService;
        private ITeamService _teamService;
        private IConfiguration _configuration;
        private string coachFolder { get; set; }
        private readonly IMapper _mapper;

        public SportsmenController(ITeamService teamService, ISportmanService sportmanService, ICoachService сoachService, IMapper mapper)
        {
            _teamService = teamService ?? throw new ArgumentNullException(Resources.Exceptions.teamServiceNullException);
            _sportmanService = sportmanService ?? throw new ArgumentNullException(Resources.Exceptions.sportmanServiceNullException);
            _сoachService = сoachService ?? throw new ArgumentNullException(Resources.Exceptions.coachServiceNullException);
            _mapper = mapper ?? throw new ArgumentNullException(Resources.Exceptions.mapper);
        }

        public IActionResult Index()
        {
            var itemDto = _sportmanService.GetAll();
            var items = _mapper.Map<IList<SportmanViewModel>>(itemDto);
            return View("Index", items);
        }

        public IActionResult Create()
        {
            var itemDto = _sportmanService.GetAll();
            var items = _mapper.Map<IList<SportmanViewModel>>(itemDto);
            return View("Index", items);
        }

        protected override void Dispose(bool disposing)
        {
            _teamService.Dispose();
            _сoachService.Dispose();
            base.Dispose(disposing);
        }
    }
}