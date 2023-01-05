//using Microsoft.Net.Http.Headers;
//using Q2P.Challenge.Data.External.Clients;
//using Q2P.Challenge.Data.External.Interfaces;

//namespace Q2P.Challenge.Data.External
//{
//    public class DependencyInjector
//    {
//        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
//        {
//            RegisterExternalInfraServices(services, configuration);
//        }

//        public static void RegisterExternalInfraServices(IServiceCollection services, IConfiguration configuration)
//        {
//            //services.Configure<ViaCepConfig>(configuration.GetSection("ViaCepSettings:url"));

//            services.AddHttpClient("ViaCep", httpClient =>
//            {
//                var a = configuration.GetSection("ViaCepSettings:url").Key;

//                httpClient.BaseAddress = new Uri(a);

//                httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");

//                httpClient.Timeout = TimeSpan.FromMinutes(1);
//            });

//            services.AddScoped<IViaCepApiClient, ViaCepApiClient>();
//        }
//    }
//}
