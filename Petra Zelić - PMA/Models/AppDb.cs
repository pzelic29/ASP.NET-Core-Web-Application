using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petra_Zelić___PMA.Models
{
    // za inMemory zapis korisnika
    public class AppDb : IdentityDbContext
    {
        public AppDb(DbContextOptions<AppDb> options)
            : base(options)
        {

        }
    }
}
