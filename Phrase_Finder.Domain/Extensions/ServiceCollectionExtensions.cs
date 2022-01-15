using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Phrase_Finder.Domain.Infrastructure;
using Phrase_Finder.Domain.Repositories;

namespace Phrase_Finder.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(
                options => options.UseNpgsql(connectionString));

            services.AddScoped<IVideosRepository, VideosRepository>();

            return services;
        }
    }
}
