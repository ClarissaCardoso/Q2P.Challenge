namespace Q2P.Challenge.Data.External.Interfaces
{
    public interface IViaCepApiClient
    {
        public Task<HttpResponseMessage> GetAddress(string zipCode);
    }
}
