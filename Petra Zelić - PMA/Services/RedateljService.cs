using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petra_Zelić___PMA.Models;
using Petra_Zelić___PMA.Repositories;

namespace Petra_Zelić___PMA.Services
{
    public class RedateljService
    {
        private readonly RedateljRepository _redateljRepository;
        public RedateljService(RedateljRepository redateljRepository)
        {
            _redateljRepository = redateljRepository;
        }

        public IEnumerable<Models.Redatelj> GetAll()
        {
            return _redateljRepository.GetAll();
        }
        public void Save(Redatelj redatelj)
        {
            _redateljRepository.Save(redatelj);
        }
    }
}
