using CSVToJSON.Core.Interfaces;
using CSVToJSON.Core.Services;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.DependencyBuilder
{
    public static class DependencyBuilderClient
    {
        public static ServiceProvider Configure()
        {
            return new ServiceCollection()
                .AddSingleton<IConversionService, ConversionService>()
                .AddSingleton<IDataServiceClient, DataServiceClient>()
                .BuildServiceProvider();
        }
    }
}
