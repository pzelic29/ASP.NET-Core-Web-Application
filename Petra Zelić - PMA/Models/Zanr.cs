using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petra_Zelić___PMA.Models
{
    public class Zanr
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public Zanr(int id, string naziv)
        {
            this.Id = id;
            this.Naziv = naziv;
        }
    }
}
