using Newtonsoft.Json.Linq;
using Petra_Zelić___PMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petra_Zelić___PMA.DbMapper
{
    public class FilmMapper
    {
        public static Film FromJson(JObject json)
        {
            var id = json["id"].ToObject<int>();
            var naziv = json["naziv"].ToObject<string>();
            var godina = json["godina"].ToObject<int>();
            var slika = json["slika"].ToObject<string>();
            var cijena = json["cijena"].ToObject<decimal>();
            var zanrId = json["zanrId"].ToObject<int>();
            var redateljId = json["redateljId"].ToObject<int>();

            var zanr = new Zanr(zanrId, ""); 
            var redatelj = new Redatelj(redateljId, "", "");

            return new Film(id, naziv, godina, slika, cijena, zanr, redatelj);
        }
    }
}
