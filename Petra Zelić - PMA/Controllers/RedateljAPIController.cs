using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petra_Zelić___PMA.Services;
using Petra_Zelić___PMA.Models;
using Newtonsoft.Json.Linq;
using Petra_Zelić___PMA.DbMapper;

namespace Petra_Zelić___PMA.Controllers
{
    [Route("api/redatelj")]
    [ApiController]
    public class RedateljAPIController : ControllerBase
    {
        private RedateljService _redateljService;
        public RedateljAPIController(RedateljService redateljService)
        {
            _redateljService = redateljService;
        }


        // GET
        [HttpGet]
        public ActionResult<List<Redatelj>> Get()
        {
            return _redateljService.GetAll().ToList();
        }


        // POST
        [HttpPost("save")]
        public ActionResult Save([FromBody] JObject json)
        {
            var redatelj = RedateljMapper.FromJson(json);
            _redateljService.Save(redatelj);
            return Ok();
        }
    }
}
