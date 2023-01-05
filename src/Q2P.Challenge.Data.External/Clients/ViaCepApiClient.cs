using Q2P.Challenge.Data.External.Interfaces;
using System.Net.Http.Headers;

namespace Q2P.Challenge.Data.External.Clients
{
    public class ViaCepApiClient : IViaCepApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ViaCepApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> GetAddress(string zipCode)
        {
            using var httpClient = _httpClientFactory.CreateClient("ViaCep");

            var request = new HttpRequestMessage(HttpMethod.Get, $"{httpClient.BaseAddress}{zipCode}/json");

            var mt = new MediaTypeWithQualityHeaderValue("application/json");

            request.Headers.Accept.Add(mt);

            var httpResponseMessage = await httpClient.SendAsync(request);

            return httpResponseMessage;
        }
    }
}
