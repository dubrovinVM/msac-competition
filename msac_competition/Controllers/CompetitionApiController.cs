using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace msac_competition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionApiController : ControllerBase
    {
        // GET: api/CompetitionApi
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        [HttpGet("{id}", Name = "GetCompetitionById")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CompetitionApi
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CompetitionApi/5
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
