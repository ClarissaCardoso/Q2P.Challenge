using System.Text.Json.Serialization;

namespace Q2P.Challenge.Domain.Core.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? FullAddress { get; set; } = string.Empty;
        public string AddressNumber { get; set; } = string.Empty;
        public string? AddressComplement { get; set; } = string.Empty;
        public string? ZipCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual List<Employee>? Employees { get; set; }
    }
}
