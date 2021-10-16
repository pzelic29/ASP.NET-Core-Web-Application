using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petra_Zelić___PMA.Models
{
    public class Redatelj
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public Redatelj(int id, string ime, string prezime)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
        }
    }
}
