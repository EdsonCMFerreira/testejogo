using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SensorReadDataApi.Domain;

namespace RodadaReadDataApi.Repository
{
  public interface IRodadaRepository
    {
        public IEnumerable<Rodada> ListAll();

        public int Insert(int dado, string mensagem);

    }
}
