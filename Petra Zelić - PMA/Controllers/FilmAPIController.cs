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
    [Route("api/film")]
    [ApiController]
    public class FilmAPIController : ControllerBase
    {
        private FilmService _filmService;
        public FilmAPIController(FilmService filmService)
        {
            _filmService = filmService;
        }



        // GET
        [HttpGet]
        public ActionResult<List<Film>> Get()
        {
            return _filmService.GetAll().ToList();
        }

        [HttpGet("{id}")]   
        public ActionResult<Film> Get(int id) 
        {
            return _filmService.GetAll(id);
        }



        // DELETE
        [HttpDelete("delete/{id}")]  //ruta ce imati dodatni parametar zvan id
        public ActionResult DeleteAndReturnAll(int id)
        {
            var filmovi = _filmService.DeleteAndReturnAll(id);
            return Ok(filmovi); 
        }



        // POST
        [HttpPost("save")]
        public ActionResult Save([FromBody] JObject json)
        {
            var film = FilmMapper.FromJson(json);
            _filmService.Save(film);
            return Ok();
        }



        // PUT 
        [HttpPut("update")]
        public ActionResult<List<Film>> Update([FromBody] JObject json)
        {
            var film = FilmMapper.FromJson(json);
            var new_data = _filmService.Update(film);
            return Ok(new_data);
        }
    }
}
