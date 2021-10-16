using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Petra_Zelić___PMA.DbModels;
using Petra_Zelić___PMA.Mappers;

namespace Petra_Zelić___PMA.Repositories
{
    public class FilmRepository
    {
        private readonly MOVIEContext _dbContext;
        public FilmRepository(MOVIEContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        // GET
        public IEnumerable<Models.Film> GetAll()
        {
            return _dbContext.Films
                .Include(z => z.Zanr)  // moramo ukljucit objekt iz druge tablice da se ne prikaze samo ID
                .Include(r => r.Redatelj)
                .Select(x => FilmDbToModelMapper.FromDatabase(x));
        }

        public Models.Film GetAll(int id)
        {
            return _dbContext.Films
                .Where(F => F.FilmId == id)
                .Include(z => z.Zanr) 
                .Include(r => r.Redatelj)
                .Select(x => FilmDbToModelMapper.FromDatabase(x))
                .FirstOrDefault();
        }


        // DELETE
        public IEnumerable<Models.Film> DeleteAndReturnAll(int id)
        {
            var dbData = _dbContext.Films
                .Where(f => f.FilmId == id) 
                .FirstOrDefault();    

            _dbContext.Films.Remove(dbData);
            _dbContext.SaveChanges();

            return _dbContext.Films
                .Include(z => z.Zanr)
                .Include(r => r.Redatelj)
                .Select(x => FilmDbToModelMapper.FromDatabase(x));
        }


        // POST == SAVE
        public void Save(Models.Film film)
        {
            var dbData = FilmDbToModelMapper.ToDatabase(film); //podatak pogodan za bazu
            _dbContext.Films.Add(dbData);
            _dbContext.SaveChanges();
        }


        // PUT == UPDATE
        public IEnumerable<Models.Film> Update(Models.Film film)
        {
            var dbData = FilmDbToModelMapper.ToDatabase(film); //podatak pogodan za bazu
            var old_data = _dbContext.Films.Find(dbData.FilmId);

            if (old_data != null) //pronasao je podatak
            {
                old_data.Naziv = dbData.Naziv;
                old_data.Godina = dbData.Godina;
                old_data.Slika = dbData.Slika;
                old_data.Cijena = dbData.Cijena;
                old_data.RedateljId = dbData.RedateljId;
                old_data.ZanrId = dbData.ZanrId;
                _dbContext.SaveChanges();
            }

            return _dbContext.Films
                .Include(z => z.Zanr)
                .Include(r => r.Redatelj)
                .Select(x => FilmDbToModelMapper.FromDatabase(x));
        }
    }
}
