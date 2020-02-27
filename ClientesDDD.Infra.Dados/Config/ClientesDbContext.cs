using ClientesDDD.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesDDD.Infra.Dados.Config
{
   public class ClientesDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public ClientesDbContext()
        {

        }

        public ClientesDbContext(DbContextOptions<ClientesDbContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetConnectionString());

            base.OnConfiguring(optionsBuilder);
        }

        private string GetConnectionString()
        {
            //Alterar para configurações desejadas:
            return @"Data Source=(localdb)\MSSQLLocalDB;
                     Connect Timeout=30;
                     Integrated Security=True;
                     Database=ClientesDDD_RD;
                     Trusted_Connection=True;
                     MultipleActiveResultSets=True;
                     ";        
        }

    }
}
