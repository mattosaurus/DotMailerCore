using ApiBaseClient;
using ApiBaseClient.Helpers;
using DotMailerCore.Clients;
using DotMailerCore.Helpers;
using DotMailerCore.Models;
using DotMailerCore.Models.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using RestSharp.Serialization;
using RestSharp.Serializers;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DotMailerCore.Testing
{
    class Program
    {
        public static IConfigurationRoot configuration;

        static int Main(string[] args)
        {
            try
            {
                // Start!
                MainAsync(args).Wait();
                return 0;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        static async Task MainAsync(string[] args)
        {
            try
            {
                // Create service collection
                ServiceCollection serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);

                // Create service provider
                IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

                //DotMailerCoreClient dotMailerCoreClient = (DotMailerCoreClient)serviceProvider.GetService(typeof(IDotMailerCoreClient));

                //CampaignSend campaignSend = new CampaignSend()
                //{
                //    Id = new Guid("e8224c2b-a670-461e-b060-4ec776e9e7c2"),
                //    CampaignId = 1,
                //    SendDate = DateTime.Parse("2015-10-31T00:00:00"),
                //    SplitTestOptions = new SplitTestOptions()
                //    {
                //        TestMetric = TestMetric.Opens,
                //        TestPercentage = 50,
                //        TestPeriodHours = 5
                //    }
                //};
                //await dotMailerCoreClient.SendCampaignAsync(campaignSend);

                await serviceProvider.GetService<App>().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error running tests");
                throw ex;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Add logging
            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
                loggingBuilder.AddSerilog(dispose: true);
                loggingBuilder.AddDebug();
            });

            // Build configuration
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Initialize serilog logger
            Log.Logger = new LoggerConfiguration()
                 .WriteTo.Console(Serilog.Events.LogEventLevel.Debug)
                 .MinimumLevel.Debug()
                 .Enrich.FromLogContext()
                 .CreateLogger();

            // Add options
            serviceCollection.AddOptions();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);

            // Add cache service
            serviceCollection.AddSingleton<ICacheService, InMemoryCache>();

            // Add json deserialization service
            serviceCollection.AddSingleton<IDeserializer, NewtonsoftJsonRestSerializer>();
            // Add json deserialization service
            serviceCollection.AddSingleton<IRestSerializer, NewtonsoftJsonRestSerializer>();

            // Add client
            serviceCollection.AddDotMailer(options =>
            {
                options.BaseUrl = "https://api.dotmailer.com/v2/";
                options.Authenticator = new HttpBasicAuthenticator("demo@apiconnector.com", "demo");
            });

            // Add app
            serviceCollection.AddSingleton<App>();
        }
    }
}
