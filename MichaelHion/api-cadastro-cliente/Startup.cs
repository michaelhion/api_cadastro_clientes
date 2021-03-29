using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_cadastro_cliente.Context;
using api_cadastro_cliente.Interfaces;
using api_cadastro_cliente.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace api_cadastro_cliente
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
           Configuration = builder.Build();
        }
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IClientes, ClienteRepository>();

            services.AddDbContext<Contexto>(o => o.UseSqlServer(Configuration.GetSection("connection2").Value));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Contexto db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //db.Database.EnsureCreated();

            if (Configuration["FazerMIgration"]== "True")
            { 
            using (var context = new Contexto())
            {
                context.Database.Migrate();
            }
            }

            app.UseMvc();
        }
    }
}
