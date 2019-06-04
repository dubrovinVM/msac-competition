using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using msac_competition.BLL.Interfaces;
using msac_competition.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace msac_competition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachApiController : ControllerBase
    {
        private ICoachService _сoachService;
        private ITeamService _teamService;
        private ICityService _cityService;
        private IConfiguration _configuration;
        private string coachFolder { get; set; }
        private readonly IMapper _mapper;

        public CoachApiController(ITeamService teamService, ICoachService сoachService, IMapper mapper, IConfiguration configuration, ICityService cityService)
        {
            _teamService = teamService ?? throw new ArgumentNullException(Resources.Exceptions.teamServiceNullException);
            _сoachService = сoachService ?? throw new ArgumentNullException(Resources.Exceptions.coachServiceNullException);
            _cityService = cityService ?? throw new ArgumentNullException(Resources.Exceptions.coachServiceNullException);
            _mapper = mapper ?? throw new ArgumentNullException(Resources.Exceptions.mapper);
            _configuration = configuration;
            coachFolder = _configuration.GetValue<string>("avatar:coach");
            _сoachService.CoachFolder = coachFolder;
        }
        // GET: api/CoachApi
        [HttpGet]
        public IEnumerable<CoachViewModel> Get()
        {
            var itemDto = _сoachService.GetAll();
            var items = _mapper.Map<IList<CoachViewModel>>(itemDto);
            return items;
        }

        // GET: api/CoachApi/5
        [HttpGet("{id}", Name = "GetCoachById")]
        public string GetById(int id)
        {
            return "value";
        }

        // POST: api/CoachApi
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CoachApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
