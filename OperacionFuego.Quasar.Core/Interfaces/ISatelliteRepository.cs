using OperacionFuego.Quasar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuego.Quasar.Core.Interfaces
{
    public interface ISatelliteRepository
    {
        public List<Satellite> GetAll();

        public Satellite InsertUpdate(Satellite satellite);

        public List<SatellitePosition> GetAllSatellitePositions();
    }
}
