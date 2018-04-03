using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NrdAkademija.Ef;
using NrdAkademija.Ef.repositories;

namespace NrdAkademija.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        IEmployeeRepository _employee;
        public ValuesController(IEmployeeRepository employee)
        {
            _employee = employee;
        }
        // GET api/values
        [HttpGet]
        
        // GET api/values/5
        [HttpGet]
        public void Get()
        {
            var employeesList = _employee.GetEmployees();
            /*var employee = _ctx.Employee.Where(b => b.Id == 1).FirstOrDefault();
            employee.FirstName = "Linas";
            _ctx.SaveChanges();*/
            /*var list = _ctx.Employee.ToList();
            var employee = _ctx.Employee.Where(b => b.FirstName == "Tomas");
            var employee1 = _ctx.Employee.SingleOrDefault(b => b.Id == 1);
            var list1 = _ctx.Employee.Where(b => b.FirstName == "Rytis").ToList();*/
            //return new string[] { "value1", "value2" };
        }


        /* public string Get(int id)
         {

             return "value";
         }*/

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
