using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Q2P.Challenge.Data.External.Clients;
using Q2P.Challenge.Data.External.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2P.Challenge.Application
{
    public class DependencyInjector
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            RegisterExternalInfraServices(services, configuration);
        }

        public static void RegisterExternalInfraServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<ViaCepConfig>(configuration.GetSection("ViaCepSettings:url"));

            services.AddHttpClient("ViaCep", httpClient =>
            {
                var url = configuration.GetSection("ViaCepSettings:url").Value;

                httpClient.BaseAddress = new Uri(url);

                httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");

                httpClient.Timeout = TimeSpan.FromMinutes(1);
            });

            services.AddScoped<IViaCepApiClient, ViaCepApiClient>();
        }
    }
}
