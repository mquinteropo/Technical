using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICAL.BUSINESS.Services.TypeService;
using TECHNICAL.MODELS;

namespace TECHNICAL.SERVICES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        public ITypeService _typeService;
        public TypesController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_typeService.GetTypes());
        }
      

        [HttpPost]
        public ActionResult Post([FromBody] TypeModel obj)
        {
            return Ok(_typeService.Create(obj));
        }
    }
}
