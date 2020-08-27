using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almacen.Core.BL.Articulos.Interface;
using Almacen.Core.BL.Articulos.Services;
using Almacen.Core.BL.SalidasAlmacen.Interfaces;
using Almacen.Core.BL.SalidasAlmacen.Services;
using Almacen.Core.BL.Seguridad.Interfaces;
using Almacen.Core.BL.Seguridad.Services;
using Almacen.Core.Helpers;
using Almacen.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Almacen.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ContextConfiguration.ConexionString = Configuration.GetConnectionString("InventarioDbContext");
            services.AddControllers();
            services.AddCors(o => o.AddPolicy(MyAllowSpecificOrigins, builder =>
            {
                //Se llaman a todas las paginas web que va a usar la API
                builder.WithOrigins("https://localhost:44377", "https://sicecesba.com", "https://www.sicecesba.com")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddMvc();
            //Establecer la configuración de la autenticación de JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;

                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                };
            });

            services.Configure<JWTSettings>(Configuration.GetSection("JWT"));
            services.AddDbContext<InventarioDbContext>(options => options.UseSqlServer(ContextConfiguration.ConexionString));
            services.AddTransient<ISeguridad, SeguridadService>();
            services.AddTransient<IArticulo, ArticuloService>();
            services.AddTransient<ISalidasAlmacen, SalidasAlmacenService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {             
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(MyAllowSpecificOrigins);

            if (!env.IsDevelopment())
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
