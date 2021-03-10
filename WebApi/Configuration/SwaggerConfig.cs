using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Configuration
{
    public static class SwaggerConfig
    {

        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "NoteCloud API",
                        Version = "v1",
                        Description = "API da aplicação de fazer gestão de notas na nuvem",
                        Contact = new OpenApiContact
                        {
                            Name = "Gerson Z. Maiamba",
                            Email = "mayambalive1999@outlook.com",
                            Url = new Uri("https://github.com/fsandrade")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "OSD",
                            Url = new Uri("https://opensource.org/osd")
                        },
                        TermsOfService = new Uri("https://opensource.org/osd")
                    });

                //c.AddFluentValidationRules();

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
                //xmlPath = Path.Combine(AppContext.BaseDirectory, "CL.Core.Shared.xml");
                //c.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "Mbongo V1");
            });
        }
    }
}
