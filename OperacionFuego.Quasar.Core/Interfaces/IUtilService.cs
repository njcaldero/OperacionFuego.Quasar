using OperacionFuego.Quasar.Core.Entities;
using OperacionFuego.Quasar.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuego.Quasar.Core.Interfaces
{
    public interface IUtilService
    {
        public PositionModel GetPosition(IEnumerable<SatelliteModel> satelites, List<SatellitePosition> satellitePositions);
    }
}
