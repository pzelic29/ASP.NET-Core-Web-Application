using System;
using System.Collections.Generic;

#nullable disable

namespace Petra_Zelić___PMA.DbModels
{
    public partial class Redatelj
    {
        public Redatelj()
        {
            Films = new HashSet<Film>();
        }

        public int RedateljId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
