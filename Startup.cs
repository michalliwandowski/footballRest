
using AutoMapper;
using Football.API.Domain.Services;
using Football.API.Persistance.Contexts;
using Football.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Football.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;			
		}

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

			services.AddDbContext<AppDbContext>(options => {
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
			});

			services.AddScoped<ITeamService, TeamService>();
			services.AddScoped<IPlayerService, PlayerService>();
			services.AddAutoMapper(typeof(Startup));
		}

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper mapper)
        {
			mapper.ConfigurationProvider.AssertConfigurationIsValid();
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
    }
}
