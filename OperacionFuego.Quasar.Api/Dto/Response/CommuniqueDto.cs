using OperacionFuego.Quasar.Core.Model;

namespace OperacionFuego.Quasar.Api.Dto.Response
{
    public class CommuniqueDto
    {
        public PositionModel position { get; set; }
        public string message { get; set; }
    }
}
