using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petra_Zelić___PMA.Mappers
{
    public class RedateljDbToModelMapper
    {
        public static Models.Redatelj FromDatabase(DbModels.Redatelj redatelj)
        {
            return new Models.Redatelj(
                redatelj.RedateljId,
                redatelj.Ime,
                redatelj.Prezime
                );
        }

        public static DbModels.Redatelj ToDatabase(Models.Redatelj redatelj)
        {
            return new DbModels.Redatelj
            {
                RedateljId = redatelj.Id,
                Ime = redatelj.Ime,
                Prezime = redatelj.Prezime,
            };
        }
    }
}
