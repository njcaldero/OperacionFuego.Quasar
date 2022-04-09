

using AutoMapper;
using OperacionFuego.Quasar.Api.Dto.Response;
using OperacionFuego.Quasar.Core.Entities;
using OperacionFuego.Quasar.Core.Model;
using System.Collections.Generic;

namespace OperacionFuego.Quasar.Api.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {


            CreateMap<Satellite, SatelliteModel>().ReverseMap();

            CreateMap<Dto.Request.SatelliteDto, Satellite>().ReverseMap();

            CreateMap<CommunicationModel, CommuniqueDto>().ReverseMap();


        }

    }
}
