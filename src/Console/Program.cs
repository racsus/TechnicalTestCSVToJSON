using CSVToJSON.Core.Interfaces;
using CSVToJSON.Core.Services;
using CSVToJSON.Factories;
using CSVToJSON.Helpers;
using Infrastructure.DependencyBuilder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CSVToJSON
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            try
            {
                //setup DI
                _serviceProvider = DependencyBuilderClient.Configure();

                var errorMessage = Validators.Validators.Check(args);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    ConsoleLogHelper.ShowInfoMessage(errorMessage, ConsoleColor.Red);
                    ConsoleLogHelper.WaitForUser();
                }

                var sourceFile = args[0];
                var conversionType = args[1];

                var service = _serviceProvider.GetService<IConversionService>();
                var res = service.ConvertFile(FileConversionFactory.BuildFileConversion(sourceFile, conversionType));

                ConsoleLogHelper.ShowInfoMessage(res, ConsoleColor.Yellow);
                ConsoleLogHelper.WaitForUser();
            }
            catch (Exception ex)
            {
                ConsoleLogHelper.ShowInfoMessage(ex.Message, ConsoleColor.Red);
                ConsoleLogHelper.WaitForUser();
            }
        }

    }
}
