using RestApiModeloDDD.Domain.Core.Interfaces.Repositorys;
using RestApiModeloDDD.Domain.Core.Interfaces.Services;
using RestApiModeloDDD.Domain.Entitys;

namespace RestApiModeloDDD.Domain.Services
{
    public class ServiceRodada : ServiceBase<Rodada>, IServiceRodada
    {
        private readonly IRepositoryRodada repositoryRodada;

        public ServiceRodada(IRepositoryRodada repositoryRodada)
            : base(repositoryRodada)
        {
            this.repositoryRodada = repositoryRodada;
        }
    }
}