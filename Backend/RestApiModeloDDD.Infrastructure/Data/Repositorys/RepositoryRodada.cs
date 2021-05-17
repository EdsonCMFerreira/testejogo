using RestApiModeloDDD.Domain.Core.Interfaces.Repositorys;
using RestApiModeloDDD.Domain.Entitys;

namespace RestApiModeloDDD.Infrastructure.Data.Repositorys
{
    public class RepositoryRodada : RepositoryBase<Rodada>, IRepositoryRodada
    {
        private readonly SqlContext sqlContext;

        public RepositoryRodada(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}