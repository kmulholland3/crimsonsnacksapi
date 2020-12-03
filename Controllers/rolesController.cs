using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class rolesController : ControllerBase
    {
        // GET: api/roles
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Roles> Get()
        {
            List<Roles> role = new List<Roles>();
            return role;
        }

        // GET: api/roles/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetRole")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/roles
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/roles/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
