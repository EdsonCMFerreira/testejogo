using AutoMapper;
using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Domain.Entitys;

namespace RestApiModeloDDD.Application.Mappers
{
    public class DtoToModelMappingRodada : Profile
    {
        public DtoToModelMappingRodada()
        {
            RodadaMap();
        }

        private void RodadaMap()
        {
            CreateMap<RodadaDto, Rodada>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Dado, opt => opt.MapFrom(x => x.Dado))
                .ForMember(dest => dest.Mensagem, opt => opt.MapFrom(x => x.Mensagem));                

        }
    }
}
