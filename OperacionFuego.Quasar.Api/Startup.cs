using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OperacionFuego.Quasar.Core.Interfaces;
using OperacionFuego.Quasar.Core.Services;
using OperacionFuego.Quasar.Data.Data;
using OperacionFuego.Quasar.Data.Repository;
using OperacionFuego.Quasar.Util.trilateration;
using System;

namespace OperacionFuego.Quasar.Api
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
            var c = AppDomain.CurrentDomain.GetAssemblies();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "OperacionFuego.Quasar.Api",
                    Version = "v1",
                    Description = "Web API para operaciones de satélite, Operación de fuego Quasar",
                    TermsOfService = new Uri("https://www.linkedin.com/in/nestorcalderon/"),
                    License = new OpenApiLicense()
                    {
                        Name = "MIT"
                    },
                    Contact = new OpenApiContact()
                    {
                        Name = "Nestor Calderón",
                        Email = "njcaldero@hotmail.com",
                        Url = new Uri("https://www.linkedin.com/in/nestorcalderon/")
                    }
                });
            });

            services.AddTransient<ICommunicationService, CommunicationService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IPositionService, PositionService>();
            services.AddTransient<ISatelliteRepository, SatelliteRepository>();
            services.AddTransient<ISatelliteService, SatelliteService>();
            services.AddTransient<IUtilService, UtilService>();

            //simulación de persistencia de DB en memoria
            services.AddSingleton<DataInMemory, DataInMemory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OperacionFuego.Quasar.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
