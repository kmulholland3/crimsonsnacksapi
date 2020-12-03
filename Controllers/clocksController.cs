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
    public class clocksController : ControllerBase
    {
        // GET: api/clocks
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Clocks> Get()
        {
            IGetAllClocks readObject = new ReadClockData();
            return readObject.GetAllClocks();
        }

        // GET: api/clocks/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetClock")]
        public Clocks Get(int id)
        {
            IGetClock readObject = new ReadClockData();
            return readObject.GetClock(id);
        }

        // POST: api/clocks
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Clocks value)
        {
            
            IInsertClock saveObject = new SaveClock();
            saveObject.InsertClockIn(value);
        }

        // PUT: api/clocks/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Clocks value)
        {
            
            IEditClock updateObject = new EditClock();
            updateObject.UpdateClock(id, value.TimeIn, value.TimeOut);
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDelete deleteObject = new DeleteClock();
            deleteObject.Remove(id);
        }
    }
}
