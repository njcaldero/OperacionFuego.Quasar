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
    public class PositionService : IPositionService
    {
        private readonly IUtilService utilService;

        private readonly ISatelliteRepository satelliteRepository;

        public PositionService(IUtilService _utilService, ISatelliteRepository _satelliteRepository)
        {
            utilService = _utilService;
            satelliteRepository = _satelliteRepository;
        }

        public PositionModel GetLocation(IEnumerable<SatelliteModel> satelites)
        {
            try
            {
                if (satelites == null || satelites.Count() < 3)
                    return null;

                return utilService.GetPosition(satelites, satelliteRepository.GetAllSatellitePositions());
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
