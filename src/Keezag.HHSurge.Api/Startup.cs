using AutoMapper;
using Keezag.HHSurge.Application.AutoMapper;
using Keezag.HHSurge.Bootstrapper;
using Keezag.HHSurge.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;
using System.IO;

namespace Keezag.HHSurge.Api
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
            services.AddDbContext<HHSurgeDbContext>(options =>
                                options.UseSqlServer(
                                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddRepository();
            services.AddApplication();

            services.AddAutoMapper(typeof(DomainToModelMappingProfile));

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                        new OpenApiInfo
                        {
                           Title = "Keezag API",
                           Version = "v1",
                        });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });

            services.AddControllers()
                    .AddNewtonsoftJson(options=>
                        options.SerializerSettings.ReferenceLoopHandling= Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Keezag API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HHSurgeDbContext>
    {
        public HHSurgeDbContext CreateDbContext(string[] args)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("\\" + System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name, "");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<HHSurgeDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new HHSurgeDbContext(builder.Options);
        }
    }
}
