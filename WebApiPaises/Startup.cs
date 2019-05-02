using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApiPaises.Models;

namespace WebApiPaises
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
            //habilitamos a Entity Framework para que utilice la base de datos en memoria
            services.AddDbContext<ApplicationDbContext>(Options => Options.UseInMemoryDatabase("paisDB"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(ConfigureJson);
        }

        private void ConfigureJson(MvcJsonOptions obj)
        {
            obj.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            //se agregan datos de prueba en caso de que la BD se encuentre sin elementos

                if (!context.Paises.Any())
                {
                    context.Paises.AddRange(new List<Pais>() {
                     new Pais() { Nombre = "México",Provincias = new List<Provincia>(){ 
                     new Provincia(){Nombre="Hidalgo"},
                     new Provincia(){Nombre="Guadalajara"}
                     } },
                     new Pais() { Nombre = "USA",Provincias = new List<Provincia>(){
                   new Provincia(){ Nombre="California" } } },
                     new Pais() { Nombre = "Cuba"}
                     });
                    context.SaveChanges();
                }
        }
    }
}
