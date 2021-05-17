using Microsoft.EntityFrameworkCore;
using RestApiModeloDDD.Domain.Entitys;
using System;
using System.Linq;

namespace RestApiModeloDDD.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        
        public DbSet<Rodada> Rodadas { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}