using Newtonsoft.Json.Linq;
using Petra_Zelić___PMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petra_Zelić___PMA.DbMapper
{
    public class RedateljMapper
    {
        public static Redatelj FromJson(JObject json)
        {
            var id = json["id"].ToObject<int>();
            var ime = json["ime"].ToObject<string>();
            var prezime = json["prezime"].ToObject<string>();

            return new Redatelj(id, ime, prezime);
        }
    }
}
