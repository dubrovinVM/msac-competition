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
        private IConfiguration _configuration;
        private string coachFolder { get; set; }
        private readonly IMapper _mapper;

        public CoachController(ITeamService teamService, ICoachService сoachService, IMapper mapper, IConfiguration configuration)
        {
            _teamService = teamService ?? throw new ArgumentNullException(Resources.Exceptions.teamServiceNullException);
            _сoachService = сoachService ?? throw new ArgumentNullException(Resources.Exceptions.coachServiceNullException);
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

        
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var coach = await _сoachService.Get((int)id);
                if (coach != null)
                {
                    var coachViewModel = _mapper.Map<CoachDTO, CoachEditViewModel>(coach);
                    coachViewModel.Teams = _teamService.GetTeamsSelectList();
                    return View("Edit", coachViewModel);
                }
                return NotFound();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CoachEditViewModel coach, IFormFile ava)
        {
            var coachDto = _mapper.Map<CoachEditViewModel, CoachDTO>(coach);
            if (coach.TeamId != null)
            {
                var teamDto = _teamService.GetAll().FirstOrDefault(a => a.Id == coach.TeamId);
                if (teamDto != null)
                {
                    teamDto.CoachId = coach.Id;
                    //await _teamService.Update(teamDto);
                    coachDto.Team = teamDto;
                }
            }
            else
            {
                coachDto.Team = null;
            }
            await _сoachService.UpdateCoach(coachDto, true);

            if (ava != null)
            {
                _сoachService.RemoveAvatar(coachDto.Avatar, coachFolder);
                coachDto.Avatar = await _сoachService.SaveAvatarAsync(ava, coach.Surname, coachFolder);
            }
            
            return RedirectToAction("Index");
        }

        public IEnumerable<SelectListItem> CastTeams()
        {
                List<SelectListItem> teams = _teamService.GetAll().AsNoTracking()
                    .OrderBy(n => n.Name)
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.Id.ToString(),
                            Text = n.Name
                        }).ToList();
                var teams_nullable = new SelectListItem()
                {
                    Value = null,
                    Text = "--- оберіть значення ---"
                };
                teams.Insert(0, teams_nullable);
                return new SelectList(teams, "Value", "Text");
            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CoachViewModel coach, IFormFile ava)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = CreateError();
                return View("Error");
            }
            var coachDTO = _mapper.Map<CoachDTO>(coach);

            if (ava != null)
            {
                coachDTO.Avatar = await _сoachService.SaveAvatarAsync(ava, coach.Surname, coachFolder);
            }
            await _сoachService.Create(coachDTO, true);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                var coach = _сoachService.GetAll().FirstOrDefault(p => p.Id == id);
                if (coach == null) return NotFound();
                var coachViewModel = _mapper.Map<CoachDTO, CoachViewModel>(coach);
                return View("Delete", coachViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var coach = await _сoachService.GetAsNoTrack((int)id);
                if (coach != null)
                {
                    _сoachService.Delete(coach, true);
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
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


    }
}