using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WAD._00014432.API.DAL.Data;
using WAD._00014432.API.DAL.Interfaces;
using WAD._00014432.API.DAL.Repositories;

namespace WAD._00014432.API.DAL
{
	public static class DALConfiguration
	{
		public static IServiceCollection DALServices(
			this IServiceCollection services,
			IConfiguration configuration
		)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddDbContext<ApplicationDbContext>(options =>
					options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			services.AddScoped<IKeyStoreRepository, KeyStoreRepository>();
			services.AddScoped<IKeyRepository, KeyRepository>();

			return services;
		}
	}
}
