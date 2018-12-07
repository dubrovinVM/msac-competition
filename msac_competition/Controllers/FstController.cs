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
    public class FstController : Controller
    {
        private IFstService _fstService;
        private ITeamService _teamService;

        private readonly IMapper _mapper;

        public FstController(ITeamService teamService, IFstService fstService, IMapper mapper)
        {
            _teamService = teamService ?? throw new ArgumentNullException(Resources.Exceptions.teamServiceNullException);
            _fstService = fstService ?? throw new ArgumentNullException(Resources.Exceptions.fstServiceNullException);
            _mapper = mapper ?? throw new ArgumentNullException(Resources.Exceptions.mapper);
        }

        public IActionResult Index()
        {
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