using Petra_Zelić___PMA.DbModels;
using Petra_Zelić___PMA.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petra_Zelić___PMA.Repositories
{
    public class ZanrRepository
    {
        private readonly MOVIEContext _dbContext;
        public ZanrRepository(MOVIEContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Models.Zanr> GetAll()
        {
            return _dbContext.Zanrs
                .Select(x => Mappers.ZanrDbToModelMapper.FromDatabase(x));
        }

        public void Save(Models.Zanr zanr)
        {
            var dbData = ZanrDbToModelMapper.ToDatabase(zanr); //podatak pogodan za bazu
            _dbContext.Zanrs.Add(dbData);
            _dbContext.SaveChanges();
        }
    }
}
