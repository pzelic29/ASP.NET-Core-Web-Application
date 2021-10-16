using Newtonsoft.Json.Linq;
using Petra_Zelić___PMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petra_Zelić___PMA.DbMapper
{
    public class ZanrMapper
    {
        public static Zanr FromJson(JObject json)
        {
            var id = json["id"].ToObject<int>();
            var naziv = json["naziv"].ToObject<string>();

            return new Zanr(id, naziv);
        }
    }
}
