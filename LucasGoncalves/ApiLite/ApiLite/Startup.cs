using IntelitraderAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            ////Para rodar o projeto use essa connection string
            //var connectionString = "db;Database=Dbtest;User=sa;Password=Pa55word2019*;";

            //Para rodar o docker use essa connection string
            var connectionString = "Server=DESKTOP-AMSIKG3\\SQLEXPRESS;Database=Dbtest;User=sa;Password=Pa55word2019*;";

            //Conecta a api ao banco de dados
            services.AddDbContext<EntityDbContext>(
            options => options.UseSqlServer(
                connectionString,
           providerOptions => providerOptions.EnableRetryOnFailure()));


            //services.AddDbContext<EntityDbContext>(
            //options => options.UseSqlServer(Configuration.GetConnectionString("DbConnection"), providerOptions => providerOptions.EnableRetryOnFailure()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Cria um banco caso nao tenha nenhum.
            PrepDb.PropPopulation(app);

            app.UseMvc();
        }
    }
}
