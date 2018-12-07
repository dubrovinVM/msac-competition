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
    public class SportsmenController : Controller
    {
        private ISportmanService _sportmanService;
        private ITeamService _teamService;

        private readonly IMapper _mapper;

        public SportsmenController(ITeamService teamService, ISportmanService sportmanService, IMapper mapper)
        {
            _teamService = teamService ?? throw new ArgumentNullException(Resources.Exceptions.teamServiceNullException);
            _sportmanService = sportmanService ?? throw new ArgumentNullException(Resources.Exceptions.sportmanServiceNullException);
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
    }
}