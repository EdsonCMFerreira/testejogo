using RestApiModeloDDD.Application.Dtos;
using System.Collections.Generic;

namespace RestApiModeloDDD.Application.Interfaces
{
    public interface IApplicationServiceRodada
    {
        void Add(RodadaDto rodadaDto);

        void Update(RodadaDto rodadaDto);

        void Remove(RodadaDto rodadaDto);

        IEnumerable<RodadaDto> GetAll();

        RodadaDto GetById(int id);
    }
}