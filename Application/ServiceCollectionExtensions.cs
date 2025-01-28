using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            IServiceCollection serviceCollection = services
              .AddAutoMapper(Assembly.GetExecutingAssembly())
              .AddMediatR(Assembly.GetExecutingAssembly())
              .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
