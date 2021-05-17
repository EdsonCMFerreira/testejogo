using AutoMapper;
using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Domain.Entitys;

namespace RestApiModeloDDD.Application.Mappers
{
    public class ModelToDtoMappingRodada : Profile
    {

        public ModelToDtoMappingRodada()
        {
            RodadaDtoMap();
        }

        private void RodadaDtoMap()
        {
            CreateMap<Rodada, RodadaDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Dado, opt => opt.MapFrom(x => x.Dado))
                .ForMember(dest => dest.Mensagem, opt => opt.MapFrom(x => x.Mensagem));
        }
    }
}
