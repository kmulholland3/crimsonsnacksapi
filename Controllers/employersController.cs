using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using API.Models;
using API.Models.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employersController : ControllerBase
    {
        // GET: api/employers
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Employers> Get()
        {
            IGetAllEmployers readObject = new ReadEmployerData();
            return readObject.GetAllEmployers();
        }

        // GET: api/employers/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetEmployer")]
        public Employers Get(int id)
        {
            IGetEmployer readObject = new ReadEmployerData();
            return readObject.GetEmployer(id);
        }

        // POST: api/employers
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Employers value)
        {
            IInsertEmployer insertObject = new SaveEmployer();
            insertObject.InsertEmployer(value);
        }

        // PUT: api/employers/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employers value)
        {
            IEditEmployer updateObject = new EditEmployer();
            updateObject.UpdateEmployer(id, value.UserName, value.Password);
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDelete deleteObject = new DeleteEmployer();
            deleteObject.Remove(id);
        }
    }
}
