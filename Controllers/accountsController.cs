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
    public class accountsController : ControllerBase
    {
        // GET: api/accounts
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Accounts> Get()
        {
            IGetAllAccounts readObject = new ReadAccountData();
            return readObject.GetAllAccounts();
        }

        // GET: api/accounts/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetAccount")]
        public Accounts Get(int id)
        {
            IGetAccount readObject = new ReadAccountData();
            return readObject.GetAccount(id);
        }

        // POST: api/accounts
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Accounts value)
        {
            IInsertAccount insertObject = new SaveAccount();
            insertObject.InsertAccount(value);
        }

        // PUT: api/accounts/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Accounts value)
        {
            IEditAccount updateObject = new EditAccount();
            updateObject.UpdateAccount(id, value.EmpFName, value.EmpLName, value.Dept);
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDelete deleteObject = new DeleteAccount();
            deleteObject.Remove(id);
        }
    }
}
