using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goiabeira_WebApi.Context;
using Goiabeira_WebApi.Interfaces;
using Goiabeira_WebApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Goiabeira_WebApi
{
    public class Startup
    {
       
        public void ConfigureServices(IServiceCollection services)
        {
            services
             .AddMvc()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.IgnoreNullValues = true;
             });

            services.AddControllers();

            services.AddTransient<IUsuario, UsuarioRepository>();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var context = new GoiabinhaContext())
            {
                context.Database.Migrate();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
