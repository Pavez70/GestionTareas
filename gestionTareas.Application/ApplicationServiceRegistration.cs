using gestionTareas.Application.Contracts.Infrastructure;
using gestionTareas.Application.Utilies;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
           // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnHandledExceptionBehaviours<,>));
           // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviours<,>));
            services.AddTransient<IEncryptExtension, EncryptExtension>();
            services.AddTransient<IJasonWebToken, JasonWebToken>();

            return services;
        }
    }
}
