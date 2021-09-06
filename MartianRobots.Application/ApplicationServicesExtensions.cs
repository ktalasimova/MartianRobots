using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MartianRobots.Application
{
    public static class ApplicationServicesExtensions
    {
        private static readonly Assembly _assembly = typeof(ApplicationServicesExtensions).Assembly;

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                .AddMediatR(_assembly)
                .AddAutoMapper(_assembly);
        }
    }
}
