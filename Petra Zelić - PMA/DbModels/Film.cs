using System;
using System.Collections.Generic;

#nullable disable

namespace Petra_Zelić___PMA.DbModels
{
    public partial class Film
    {
        public int FilmId { get; set; }
        public string Naziv { get; set; }
        public int Godina { get; set; }
        public string Slika { get; set; }
        public decimal Cijena { get; set; }
        public int RedateljId { get; set; }
        public int ZanrId { get; set; }

        public virtual Redatelj Redatelj { get; set; }
        public virtual Zanr Zanr { get; set; }
    }
}
