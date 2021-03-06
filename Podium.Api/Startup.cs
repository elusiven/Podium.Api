using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Podium.Data;
using Podium.Data.ModuleRegistration;
using Podium.Service.MappingProfiles;
using Podium.Service.ModuleRegistration;

namespace Podium.Api
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
            services.AddControllers().AddNewtonsoftJson();

            // Add Database context
            services.AddDbContext<PodiumDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer"), x => x.MigrationsAssembly("Podium.Data")));

            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(AutoMappingProfiles));

            // Register API versioning
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // For testing purposes in this test, in production env in a real world scenario this would be more secure
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // Error handler
            app.UseExceptionHandler("/error");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Podium Data API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Register Autofac Modules
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new ServiceModule());
        }

        /// <summary>
        /// Registers custom middleware
        /// </summary>
        /// <param name="app"></param>
        private void RegisterCustomMiddlewares(IApplicationBuilder app)
        {
        }
    }
}