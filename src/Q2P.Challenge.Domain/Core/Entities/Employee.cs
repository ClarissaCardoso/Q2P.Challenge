using System.Text.Json.Serialization;

namespace Q2P.Challenge.Domain.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public decimal Remuneration { get; set; }
        public int? CompanyId { get; set; }

        [JsonIgnore]
        public virtual Company? Company { get; set; }
    }
}
