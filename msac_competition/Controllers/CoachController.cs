using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using msac_competition.BLL.BusinessModels;
using msac_competition.BLL.DTO;
using msac_competition.BLL.Interfaces;
using msac_competition.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace msac_competition.Controllers
{
    public class CoachController : Controller
    {
        private ICoachService _сoachService;
        private ITeamService _teamService;
        private ICityService _cityService;
        private IConfiguration _configuration;
        private string coachFolder { get; set; }
        private readonly IMapper _mapper;

        public CoachController(ITeamService teamService, ICoachService сoachService, IMapper mapper, IConfiguration configuration, ICityService cityService)
        {
            _teamService = teamService ?? throw new ArgumentNullException(Resources.Exceptions.teamServiceNullException);
            _сoachService = сoachService ?? throw new ArgumentNullException(Resources.Exceptions.coachServiceNullException);
            _cityService = cityService ?? throw new ArgumentNullException(Resources.Exceptions.coachServiceNullException);
            _mapper = mapper ?? throw new ArgumentNullException(Resources.Exceptions.mapper);
            _configuration = configuration;
            coachFolder = _configuration.GetValue<string>("avatar:coach");
            _сoachService.CoachFolder = coachFolder;
        }

        public IActionResult Index()
        {
            var itemDto = _сoachService.GetAll();
            var items = _mapper.Map<IList<CoachViewModel>>(itemDto);
            return View("Index", items);
        }

        public IActionResult Create()
        {
            ViewBag.Teams = _teamService.GetTeamsSelectList();
            ViewBag.Cities = _cityService.GetCitysSelectList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CoachViewModel coach, IFormFile ava)
        {
            if (!ModelState.IsValid || coach == null)
            {
                ViewBag.Error = CreateError();
                return View("Error");
            }
            var coachDto = _mapper.Map<CoachDTO>(coach);
            var addedCoach = await _сoachService.Create(coachDto, ava, true);
            await UpdateTeam(coach.TeamId, addedCoach.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                @TempData["Error"] = @Resources.Exceptions.notCorrectRequest;
                return RedirectToAction("Error", "Home");
            }
            var coach = _сoachService.GetAll().FirstOrDefault(a=>a.Id == id);
            if (coach == null)
            {
                @TempData["Error"] = @Resources.Exceptions.notCorrectRequest;
                return RedirectToAction("Error", "Home");
            }
            var coachViewModel = _mapper.Map<CoachDTO, CoachEditViewModel>(coach);
            coachViewModel.Teams = _teamService.GetTeamsSelectList();
            coachViewModel.Cities = _cityService.GetCitysSelectList();
            return View("Edit", coachViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CoachEditViewModel coach, IFormFile ava)
        {
            try
            {
                var coachDto = _mapper.Map<CoachEditViewModel, CoachDTO>(coach);
                coachDto.Team = await UpdateTeam(coach.TeamId, coach.Id);
                await _сoachService.UpdateCoach(coachDto, ava, true);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                @TempData["Error"] = ex.Message+"\n\n"+ex.InnerException?.Message;
                return RedirectToAction("Error","Home");
            }
        }

        public async Task<TeamDTO> UpdateTeam(int? teamId, int? coachId)
        {
            if (teamId != null)
            {
                var selectedTeamDto = await _teamService.GetById((int)teamId);
                if (selectedTeamDto != null)
                {
                    await _teamService.SetTeamCoachToNull(coachId);
                    selectedTeamDto.CoachId = coachId;
                    await _teamService.Update(selectedTeamDto, true);
                    return selectedTeamDto;
                }
            }
            else
            {
                await _teamService.SetTeamCoachToNull(coachId);
            }
            return null;
        }

       

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null)
            {
                @TempData["Error"] = @Resources.Exceptions.notCorrectRequest;
                return RedirectToAction("Error", "Home");
            }
            var coach = _сoachService.GetAll().FirstOrDefault(a => a.Id == id);
            if (coach == null)
            {
                @TempData["Error"] = @Resources.Exceptions.notCorrectRequest;
                return RedirectToAction("Error", "Home");
            }
            var coachViewModel = _mapper.Map<CoachDTO, CoachViewModel>(coach);
            return View("Delete", coachViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                @TempData["Error"] = @Resources.Exceptions.notCorrectRequest;
                return RedirectToAction("Error", "Home");
            }
            var coach = await _сoachService.GetByIdAsNoTrack((int)id);
            if (coach == null)
            {
                @TempData["Error"] = @Resources.Exceptions.notCorrectRequest;
                return RedirectToAction("Error", "Home");
            }
            await _сoachService.Delete(coach, true);
            return RedirectToAction("Index");
        }

        public string CreateError()
        {
            var errorMessage = new StringBuilder();
            foreach (var modelState in ViewData.ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    errorMessage.Append(error.ErrorMessage);
                }
            }
            return errorMessage.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            _teamService.Dispose();
            _сoachService.Dispose();
            base.Dispose(disposing);
        }


    }
}