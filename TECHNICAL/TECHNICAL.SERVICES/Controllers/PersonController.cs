using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICAL.BUSINESS.Services.PersonService;
using TECHNICAL.MODELS;

namespace TECHNICAL.SERVICES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_personService.GetPersons());
        }
        [HttpDelete("{identification}")]
        public ActionResult Delete(int identification)
        {
            return Ok(_personService.Delete(identification));
        }
        [HttpPost]
        public ActionResult Post([FromBody] PersonModel obj)
        {
            return Ok(_personService.Create(obj));
        }
        [HttpPut]
        public ActionResult Put([FromBody] PersonModel obj)
        {
            return Ok(_personService.UpdatePerson(obj));
        }
    }
}
