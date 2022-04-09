using OperacionFuego.Quasar.Core.Model;
using System.Collections.Generic;

namespace OperacionFuego.Quasar.Api.Dto.Request
{
    public class SatellitesDto
    {
        public IEnumerable<SatelliteModel> satellites { get; set; }
    }
}
