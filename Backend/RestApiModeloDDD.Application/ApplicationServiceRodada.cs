using AutoMapper;
using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Application.Interfaces;
using RestApiModeloDDD.Domain.Core.Interfaces.Services;
using RestApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;

namespace RestApiModeloDDD.Application
{
    public class ApplicationServiceRodada : IApplicationServiceRodada
    {
        private readonly IServiceRodada serviceRodada;
        private readonly IMapper mapper;

        public ApplicationServiceRodada(IServiceRodada serviceRodada
                                        , IMapper mapper)
        {
            this.serviceRodada = serviceRodada;
            this.mapper = mapper;
        }

        public void Add(RodadaDto rodadaDto)
        {
            var rodada = mapper.Map<Rodada>(rodadaDto);
            serviceRodada.Add(rodada);
        }

        public IEnumerable<RodadaDto> GetAll()
        {
            var rodadas = serviceRodada.GetAll();
            var rodadasDto = mapper.Map<IEnumerable<RodadaDto>>(rodadas);
            return rodadasDto;
        }

        public RodadaDto GetById(int id)
        {
            var rodada = serviceRodada.GetById(id);
            var rodadaDto = mapper.Map<RodadaDto>(rodada);
            return rodadaDto;
        }

        public void Remove(RodadaDto rodadaDto)
        {
            var rodada = mapper.Map<Rodada>(rodadaDto);
            serviceRodada.Remove(rodada);
        }

        public void Update(RodadaDto rodadaDto)
        {
            var rodada = mapper.Map<Rodada>(rodadaDto);
            serviceRodada.Update(rodada);
        }
    }
}