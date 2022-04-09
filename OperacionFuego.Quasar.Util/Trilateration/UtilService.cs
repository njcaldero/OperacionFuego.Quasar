using OperacionFuego.Quasar.Core.Entities;
using OperacionFuego.Quasar.Core.Interfaces;
using OperacionFuego.Quasar.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuego.Quasar.Util.trilateration
{
    public class UtilService : IUtilService
    {

        PositionModel IUtilService.GetPosition(IEnumerable<SatelliteModel> satelites, List<SatellitePosition> SatellitePositions)
        {
            try
            {
                //La solución se realiza con un algoritmo de Trilateracion

                PositionModel pUno = GetPositionModel(satelites.ToList()[0].name, SatellitePositions);
                PositionModel pDos = GetPositionModel(satelites.ToList()[1].name, SatellitePositions);
                PositionModel pTres = GetPositionModel(satelites.ToList()[2].name, SatellitePositions);

                double dUno = (float)satelites.ToList()[0].distance;
                double dDos = (float)satelites.ToList()[1].distance;
                double dTres = (float)satelites.ToList()[2].distance;

                double iUno = pUno.x;
                double iDos = pDos.x;
                double iTres = pTres.x;

                double jUno = pUno.y; double jDos = pDos.y; double jTres = pTres.y;

                float x = (float)(
                                    (((Math.Pow(dUno, 2) - Math.Pow(dDos, 2)) + (Math.Pow(iDos, 2) - Math.Pow(iUno, 2)) +
                                    (Math.Pow(jDos, 2) - Math.Pow(jUno, 2))) * ((2 * jTres) - (2 * jDos)) -
                                    ((Math.Pow(dDos, 2) - Math.Pow(dTres, 2)) + (Math.Pow(iTres, 2) - Math.Pow(iDos, 2)) +
                                    (Math.Pow(jTres, 2) - Math.Pow(jDos, 2))) * ((2 * jDos) - (2 * jUno))) /
                                    (((2 * iDos) - (2 * iTres)) * ((2 * jDos) - (2 * jUno)) -
                                    ((2 * iUno) - (2 * iDos)) * ((2 * jTres) - (2 * jDos)))
                                  );

                float y = (float)(
                                    ((Math.Pow(dUno, 2) - Math.Pow(dDos, 2)) +
                                    (Math.Pow(iDos, 2) - Math.Pow(iUno, 2)) +
                                    (Math.Pow(jDos, 2) - Math.Pow(jUno, 2)) +
                                    (x * ((2 * iUno) - (2 * iDos)))) / ((2 * jDos) - (2 * jUno))
                                );

                return new PositionModel() { x = x, y = y };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private PositionModel GetPositionModel(string satelliteName, List<SatellitePosition> SatellitePositions)
        {
            var pos = SatellitePositions.Single(x => x.name.ToLower() == satelliteName.ToLower()).position;
            return new PositionModel() { x = pos.x, y = pos.y };
        }

    }
}
