using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OperacionFuego.Quasar.Api.Dto.Request;
using OperacionFuego.Quasar.Api.Dto.Response;
using OperacionFuego.Quasar.Core.Interfaces;

namespace OperacionFuego.Quasar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        private readonly ILogger<CommunicationController> logger;
        private readonly ICommunicationService communicationService;
        private readonly IMapper mapper;

        public CommunicationController(ILogger<CommunicationController> _logger, ICommunicationService _communicationService, IMapper _mapper, ISatelliteService satelliteService)
        {
            mapper = _mapper;
            logger = _logger;
            communicationService = _communicationService;
        }

        // POST api/<CommunicationController>/topsecret
        [HttpPost]
        [Route("topsecret")]
        public CommuniqueDto Post([FromBody] SatellitesDto satellitesDto)
        {

            var communication = communicationService.GetCommunication(satellitesDto.satellites);

            if (communication.position == null )
                Response.StatusCode = 404;

            var satelliteDto = mapper.Map<CommuniqueDto>(communication);

            return satelliteDto;
        }

    }
}
