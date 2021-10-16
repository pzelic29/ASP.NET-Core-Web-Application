using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petra_Zelić___PMA.Mappers
{
    public class ZanrDbToModelMapper
    {
        public static Models.Zanr FromDatabase(DbModels.Zanr zanr)
        {
            return new Models.Zanr(
                zanr.ZanrId,
                zanr.Naziv
                );
        }

        public static DbModels.Zanr ToDatabase(Models.Zanr zanr)
        {
            return new DbModels.Zanr
            {
                ZanrId = zanr.Id,
                Naziv = zanr.Naziv
            };
        }
    }
}
