namespace Q2P.Challenge.Domain.Core.DTO.Responses
{
    public class CompanyResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? FullAddress { get; set; } = string.Empty;
        public string AddressNumber { get; set; } = string.Empty;
        public string? AddressComplement { get; set; } = string.Empty;
        public string? ZipCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
