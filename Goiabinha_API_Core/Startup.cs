using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goiabinha_API_Core.Interfaces;
using Goiabinha_API_Core.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Goiabinha_API_Core
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
               .AddMvc()
               .AddJsonOptions(options => {
                   options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
               })

               .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
            services.AddTransient<IUsuario, UsuarioRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
