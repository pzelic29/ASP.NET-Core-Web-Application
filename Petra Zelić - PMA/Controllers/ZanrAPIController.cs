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
    [Route("api/zanr")]
    [ApiController]
    public class ZanrAPIController : ControllerBase
    {
        private ZanrService _zanrService;
        public ZanrAPIController(ZanrService zanrService)
        {
            _zanrService = zanrService;
        }


        // GET
        [HttpGet]
        public ActionResult<List<Zanr>> Get()
        {
            return _zanrService.GetAll().ToList();
        }

        
        // POST
        [HttpPost("save")]
        public ActionResult Save([FromBody] JObject json)
        {
            var zanr = ZanrMapper.FromJson(json);
            _zanrService.Save(zanr);
            return Ok();
        }

    }
}
