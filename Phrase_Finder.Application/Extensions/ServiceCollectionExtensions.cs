using Microsoft.Extensions.DependencyInjection;
using Phrase_Finder.Application.Infrastructure;
using Phrase_Finder.Application.Services;
using Phrase_Finder.Domain.Extensions;
using RestEase.HttpClientFactory;

namespace Phrase_Finder.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
        {
            services.AddDomainServices(connectionString);

            services.AddScoped<PasswordHasher>();
            services.AddScoped<IWordInfoService, WordInfoService>();
            services.AddScoped<IVideoScrappingService, VideoScrappingService>();
            services.AddScoped<IVideosService, VideosService>();
            services.AddScoped<IVideoSearchService, VideoSearchService>();
            services.AddScoped<IDictionaryService, DictionaryService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddRestEaseClient<IWordInfoApi>();
            services.AddRestEaseClient<ITEDApi>();

            return services;
        }
    }
}
