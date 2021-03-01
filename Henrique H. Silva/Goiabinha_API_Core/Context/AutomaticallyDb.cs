using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goiabinha_API_Core.Context
{
    public static class AutomaticallyDb
    {
        public static void population(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                seed(scope.ServiceProvider.GetService<GoiabinhaContext>());
            }
        }

        public static void seed(GoiabinhaContext context)
        {
            context.Database.Migrate();
        }
    }
}
