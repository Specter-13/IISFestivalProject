using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using FestivalProject.BL.Facade;
using FestivalProject.BL.Mapper;
using FestivalProject.DAL;
using FestivalProject.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FestivalProject
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
            //services.AddDbContext<FestivalDbContext>(options => options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog = FestivalDB;MultipleActiveResultSets = True;Integrated Security = True;"));
            services.AddDbContext<FestivalDbContext>(option => option.UseSqlServer(Configuration["database:connection"]));
            services.AddControllers();

            services.AddScoped<InterpretRepository>();
            services.AddScoped<MemberRepository>();


            services.AddScoped<InterpretFacade>();
            services.AddAutoMapper(typeof(InterpretProfiles), typeof(MemberProfiles), 
                typeof(FestivalProfiles), typeof(FestivalInterpretProfiles),
                typeof(StageProfiles), typeof(StageInterpretProfiles));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpdateDatabase(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<FestivalDbContext>();
            context.Database.Migrate();
        }
    }
}
