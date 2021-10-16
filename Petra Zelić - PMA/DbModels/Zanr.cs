using System;
using System.Collections.Generic;

#nullable disable

namespace Petra_Zelić___PMA.DbModels
{
    public partial class Zanr
    {
        public Zanr()
        {
            Films = new HashSet<Film>();
        }

        public int ZanrId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
