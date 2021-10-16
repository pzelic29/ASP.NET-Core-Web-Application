using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petra_Zelić___PMA.Models;
using Petra_Zelić___PMA.Repositories;

namespace Petra_Zelić___PMA.Services
{
    public class ZanrService
    {
        private readonly ZanrRepository _zanrRepository;
        public ZanrService(ZanrRepository zanrRepository)
        {
            _zanrRepository = zanrRepository;
        }

        public IEnumerable<Models.Zanr> GetAll()
        {
            return _zanrRepository.GetAll();
        }
        public void Save(Zanr zanr)
        {
            _zanrRepository.Save(zanr);
        }
    }
}
