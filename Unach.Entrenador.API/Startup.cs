using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unach.Entrenador.API
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
            Core.Helpes.ConfiguracionesEstaticas.CadenaConexion = Configuration.GetConnectionString("EntrenadorContext");
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Unach.Entrenador.API", Version = "v1" });
            });

            services.AddTransient<Core.BL.Interfaces.IPlanes, Core.BL.Services.Planes>();
            services.AddTransient<Core.BL.Interfaces.IEnfoques, Core.BL.Services.Enfoques>();
            services.AddTransient<Core.BL.Interfaces.INiveles, Core.BL.Services.Niveles>();
            services.AddTransient<Core.BL.Interfaces.IEjercicios, Core.BL.Services.Ejercicios>();
            services.AddTransient<Core.BL.Interfaces.IUsuarios, Core.BL.Services.UsuariosService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Unach.Entrenador.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
