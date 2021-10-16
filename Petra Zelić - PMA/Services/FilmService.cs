using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petra_Zelić___PMA.Models;
using Petra_Zelić___PMA.Repositories;

namespace Petra_Zelić___PMA.Services
{
    public class FilmService
    {
        private readonly FilmRepository _filmRepository;
        public FilmService(FilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }


        // GET
        public IEnumerable<Models.Film> GetAll()
        {
            return _filmRepository.GetAll();
        }

        public Models.Film GetAll(int id)
        {
            return _filmRepository.GetAll(id);
        }

        // DELETE 
        public IEnumerable<Models.Film> DeleteAndReturnAll(int id)
        {
            return _filmRepository.DeleteAndReturnAll(id);
        }


        // POST
        public void Save(Film film)
        {
            _filmRepository.Save(film);
        }


        // PUT
        public IEnumerable<Models.Film> Update(Film film)
        {
            return _filmRepository.Update(film);
        }

       
    }
}
