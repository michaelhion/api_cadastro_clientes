using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace api_cadastro_cliente.Context
{

    public class Contexto : DbContext
    {
        SqlConnection con;

        public Contexto()
        {
            var configuation = GetConfiguration();
            con = new SqlConnection(configuation.GetSection("connection2").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);            
            return builder.Build();
        }
        
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {

        }

        public DbSet<ClienteModel> ClienteModels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConfiguration().GetSection("connection2").Value);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
