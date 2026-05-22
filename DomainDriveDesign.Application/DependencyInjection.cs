using DomainDriveDesign.Domain.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DomainDriveDesign.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(cfr =>
        {
            cfr.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(),typeof(Entity).Assembly);
        });
        return service;
    }
}
