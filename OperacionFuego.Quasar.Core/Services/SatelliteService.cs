using OperacionFuego.Quasar.Core.Entities;
using OperacionFuego.Quasar.Core.Interfaces;
using OperacionFuego.Quasar.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuego.Quasar.Core.Services
{
    public class SatelliteService : ISatelliteService
    {
        private readonly ISatelliteRepository satelliteRepository;
        private readonly ICommunicationService communicationService;

        public SatelliteService(ISatelliteRepository _satelliteRepository, ICommunicationService _communicationService)
        {
            satelliteRepository = _satelliteRepository;
            communicationService = _communicationService;
        }

        public List<Satellite> GetAll()
        {
            var listSatellites = satelliteRepository.GetAll();
            if (listSatellites.Count < 3)
                throw new Exception("No hay suficiente información.");

            return listSatellites;
        }

        public List<SatellitePosition> GetAllSatellitePositions()
        {
            return satelliteRepository.GetAllSatellitePositions();
        }

        public CommunicationModel GetCommunication(IEnumerable<SatelliteModel> satelliteModels)
        {
            return communicationService.GetCommunication(satelliteModels);
        }

        public Satellite InsertUpdate(Satellite satellite)
        {
            return satelliteRepository.InsertUpdate(satellite);
        }


    }
}
