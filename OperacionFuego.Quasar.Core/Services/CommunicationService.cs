using OperacionFuego.Quasar.Core.Interfaces;
using OperacionFuego.Quasar.Core.Model;
using System.Collections.Generic;

namespace OperacionFuego.Quasar.Core.Services
{
    public class CommunicationService : ICommunicationService
    {
        private readonly IMessageService messageService;
        private readonly IPositionService positionService;
        public CommunicationService(IPositionService _positionService, IMessageService _messageService)
        {
            positionService = _positionService;
            messageService = _messageService;
        }

        public CommunicationModel GetCommunication(IEnumerable<SatelliteModel> satellites)
        {
            var position = positionService.GetLocation(satellites);

            var message = messageService.GetMessage(satellites);

            if (position == null || message == null)
            {
                message = "No hay suficiente información para determinar el mensaje o la posición.";
                position = null;
            }

            return new CommunicationModel()
            {
                position = position,
                message = message,
            };
        }
    }
}
