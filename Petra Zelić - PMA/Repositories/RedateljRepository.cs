using Petra_Zelić___PMA.DbModels;
using Petra_Zelić___PMA.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petra_Zelić___PMA.Repositories
{
    public class RedateljRepository
    {
        private readonly MOVIEContext _dbContext;
        public RedateljRepository(MOVIEContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Models.Redatelj> GetAll()
        {
            return _dbContext.Redateljs
                .Select(x => Mappers.RedateljDbToModelMapper.FromDatabase(x));
        }

        public void Save(Models.Redatelj redatelj)
        {
            var dbData = RedateljDbToModelMapper.ToDatabase(redatelj);
            _dbContext.Redateljs.Add(dbData);
            _dbContext.SaveChanges();
        }
    }
}
