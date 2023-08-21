using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public static class DbConf
    {
        public static string Conect()
        {
            StreamReader r = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "ConectToString.json"));
            var json = r.ReadToEnd();
            ConnectionSettings items = JsonConvert.DeserializeObject<ConnectionSettings>(json);
            return items.ConnectionString;
        }

    }
}
