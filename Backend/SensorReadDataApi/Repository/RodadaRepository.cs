using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using SensorReadDataApi.Domain;

namespace RodadaReadDataApi.Repository
{

    public sealed class RodadaRepository : IRodadaRepository
    {
        private readonly string _connectionString;

        public RodadaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SensorDataServer");
        }

        public IEnumerable<Rodada> ListAll()
        {
            using var connection = new SqlConnection(_connectionString);

            var rodadaData = connection.Query<Rodada>("select * from rodada");

            return rodadaData;
        }

        public int Insert(int dado, string mensagem)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "INSERT INTO Rodada (dado,mensagem) VALUES (@dado, @mensagem)";

            var result = connection.Execute(query, new { dado = dado, mensagem = mensagem});

            return result;
        }
    }
}
