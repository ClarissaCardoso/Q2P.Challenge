namespace Q2P.Challenge.Domain.Core.DTO.Requests
{
    public class CreateCompanyDto
    {
        public string Name { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string AddressNumber { get; set; } = string.Empty;
        public string? AddressComplement { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
