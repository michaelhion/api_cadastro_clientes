using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goiabinha_WebApi.Context;
using Goiabinha_WebApi.Interfaces;
using Goiabinha_WebApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Goiabinha_WebApi
{
    public class Startup
    {    
        public void ConfigureServices(IServiceCollection services)
        {
            services
             // Adiciona o MVC ao projeto
             .AddMvc()
             .AddJsonOptions(options => {
                   // Ignora valores nulos ao fazer junções nas consultas
                   options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                   // Ignora os loopings nas consultas
                   options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
             })

             // Define a versão do .NET Core
             .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
            services.AddTransient<IUsuario, UsuarioRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            using (var context = new GoiabinhaContext())
            {
                context.Database.Migrate();
            }
            
            app.UseMvc();
        }
    }
}
