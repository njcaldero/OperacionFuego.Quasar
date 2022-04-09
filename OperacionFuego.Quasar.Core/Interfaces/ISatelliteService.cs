using OperacionFuego.Quasar.Core.Entities;
using OperacionFuego.Quasar.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuego.Quasar.Core.Interfaces
{
    public interface ISatelliteService
    {
        public List<Satellite> GetAll();

        public List<SatellitePosition> GetAllSatellitePositions();

        public Satellite InsertUpdate(Satellite satellite);

        public CommunicationModel GetCommunication(IEnumerable<SatelliteModel> satelliteModels);
    }
}
