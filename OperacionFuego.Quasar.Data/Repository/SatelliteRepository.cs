using OperacionFuego.Quasar.Core.Entities;
using OperacionFuego.Quasar.Core.Interfaces;
using OperacionFuego.Quasar.Core.Model;
using OperacionFuego.Quasar.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuego.Quasar.Data.Repository
{
    public class SatelliteRepository : ISatelliteRepository
    {


        private readonly DataInMemory dataInMemory;

        public SatelliteRepository(DataInMemory _dataInMemory)
        {
            dataInMemory = _dataInMemory;
        }

        public List<Satellite> GetAll()
        {
            return dataInMemory.SatellitesDB;
        }


        public List<SatellitePosition> GetAllSatellitePositions()
        {
            return dataInMemory.SatellitePositions;
        }

        public Satellite InsertUpdate(Satellite satellite)
        {
            //if (dataInMemory.SatellitesDB.Count == 3)
            //    throw new Exception("Los satelites ya estan cargados.");

            if (!dataInMemory.SatellitePositions.Exists(x => x.name.ToLower().Equals(satellite.name.ToLower())))
                throw new Exception("Nombre de satelite incorrecto...");

            var sal = dataInMemory.SatellitesDB.SingleOrDefault(x => x.name.ToLower().Equals(satellite.name.ToLower()));
            if (sal == null) dataInMemory.SatellitesDB.Add(satellite);
            else
            {
                dataInMemory.SatellitesDB.Remove(sal);
                dataInMemory.SatellitesDB.Add(satellite);
            }

            return satellite;
        }
    }


}
