using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Templete.Data.Interface;
using Templete.Data.Repositories;

namespace WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {

            //INJEÇÃO DE INDEPENDECIA PARA A CAMA DO REPOSITORIO
            services.AddScoped<ICliente, ClienteRespository>();
            services.AddScoped<INota, NotaRepository>();
        }
    }
}
