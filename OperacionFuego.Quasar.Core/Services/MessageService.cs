using OperacionFuego.Quasar.Core.Interfaces;
using OperacionFuego.Quasar.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuego.Quasar.Core.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage(IEnumerable<SatelliteModel> satellites)
        {
            if (satellites == null || satellites.Count() <= 0)
                return null;

            string[] message = new string[satellites.First().message.Count()];

            foreach (var satellite in satellites)
            {
                if (satellite.message.Count() < 5) return null;
                for (int i = 0; i < satellite.message.Count(); i++)
                {
                    message[i] = string.IsNullOrEmpty(satellite.message[i]) ? message[i] : satellite.message[i];
                }
            }

            return string.Join(' ', message);
        }
    }
}
