using Newtonsoft.Json;
using OperacionFuego.Quasar.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuego.Quasar.Data.Data
{
    public class DataInMemory
    {
        public List<Satellite> SatellitesDB;

        public List<SatellitePosition> SatellitePositions;


        public DataInMemory()
        {
            string pathToFiles = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            StreamReader r = new StreamReader($"{pathToFiles}/data.json");
            string jsonString = r.ReadToEnd();
            SatellitePositions = JsonConvert.DeserializeObject<List<SatellitePosition>>(jsonString);
            SatellitesDB = new List<Satellite>();
        }

    }
}
