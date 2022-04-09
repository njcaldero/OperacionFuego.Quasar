using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OperacionFuego.Quasar.Api.Dto.Request;
using OperacionFuego.Quasar.Api.Dto.Response;
using OperacionFuego.Quasar.Core.Entities;
using OperacionFuego.Quasar.Core.Interfaces;
using OperacionFuego.Quasar.Core.Model;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OperacionFuego.Quasar.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SatelliteController : ControllerBase
    {

        private readonly ISatelliteService satelliteService;
        private readonly IMapper mapper;
        public SatelliteController(ISatelliteService _satelliteService, IMapper _mapper)
        {
            satelliteService = _satelliteService;
            mapper = _mapper;
        }

        [HttpPost]
        [Route("topsecret_split/{satellite_name}")]
        public ActionResult Post(string satellite_name, [FromBody] SatelliteDto satelliteDto)
        {
            try
            {
                var satellite = mapper.Map<Satellite>(satelliteDto);
                satellite.name = satellite_name;

                var resp = satelliteService.InsertUpdate(satellite);

                return Ok(resp);
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("topsecret_split")]
        public ActionResult Get()
        {
            try
            {
                var satellites = satelliteService.GetAll();

                var satellitesMap = mapper.Map<IEnumerable<SatelliteModel>>(satellites);

                var communication = satelliteService.GetCommunication(satellitesMap);

                if (communication.position == null)
                    Response.StatusCode = 404;

                var satelliteDto = mapper.Map<CommuniqueDto>(communication);

                return Ok(satelliteDto);
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
