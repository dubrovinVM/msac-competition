using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using msac_competition.BLL.Interfaces;
using msac_competition.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace msac_competition.Controllers
{
    public class FstController : Controller
    {
        private IFstService _fstService;
        private ITeamService _teamService;
        private ICoachService _сoachService;
        private ICityService _cityService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public FstController(ITeamService teamService, ICoachService сoachService, IMapper mapper, ICityService cityService, IFstService fstService, ILogger<FstController> logger)
        {
            _fstService = fstService ?? throw new ArgumentNullException(Resources.Exceptions.fstServiceNullException);
            _teamService = teamService ?? throw new ArgumentNullException(Resources.Exceptions.teamServiceNullException);
            _сoachService = сoachService ?? throw new ArgumentNullException(Resources.Exceptions.coachServiceNullException);
            _cityService = cityService ?? throw new ArgumentNullException(Resources.Exceptions.coachServiceNullException);
            _mapper = mapper ?? throw new ArgumentNullException(Resources.Exceptions.mapper);
            _logger = logger;
        }

        public IActionResult Index()
        {
            //_logger.LogInformation("FstController started");
            var fstDto = _fstService.GetAll();
            var fsts = _mapper.Map<IList<FstViewModel>>(fstDto);
            return View("Index", fsts);
        }

        public IActionResult Create()
        {
            var fstDto = _fstService.GetAll();
            var fsts = _mapper.Map<IList<FstViewModel>>(fstDto);
            return View("Index", fsts);
        }
    }
}