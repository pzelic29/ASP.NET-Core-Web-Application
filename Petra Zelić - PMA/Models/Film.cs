using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petra_Zelić___PMA.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Godina { get; set; }
        public string Slika { get; set; }
        public decimal Cijena { get; set; }


        public Zanr Zanr { get; set; }
        public Redatelj Redatelj { get; set; }

        public Film(int id, string naziv, int godina, string slika, decimal cijena, Zanr zanr, Redatelj redatelj)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Godina = godina;
            this.Slika = slika;
            this.Cijena = cijena;
            this.Zanr = zanr;
            this.Redatelj = redatelj;
        }
    }
}
