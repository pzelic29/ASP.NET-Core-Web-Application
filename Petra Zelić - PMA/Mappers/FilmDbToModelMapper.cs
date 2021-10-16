using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petra_Zelić___PMA.Mappers
{
    public class FilmDbToModelMapper
    {
        public static Models.Film FromDatabase(DbModels.Film film)
        {
            return new Models.Film(
                film.FilmId,
                film.Naziv,
                film.Godina,
                film.Slika,
                film.Cijena,
                ZanrDbToModelMapper.FromDatabase(film.Zanr),
                RedateljDbToModelMapper.FromDatabase(film.Redatelj)  //za objekt(cijeli koji primi) vraca id, ime i prezime
                );
        }

        public static DbModels.Film ToDatabase(Models.Film film)
        {
            return new DbModels.Film
            {
                FilmId = film.Id,
                Naziv = film.Naziv,
                Godina = film.Godina,
                Slika = film.Slika,
                Cijena = film.Cijena,
                RedateljId = film.Redatelj.Id, 
                ZanrId = film.Zanr.Id
            };
        }
    }
}
