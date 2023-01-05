namespace Q2P.Challenge.Domain.Core.DTO.Requests
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; } = string.Empty;

        public string Occupation { get; set; } = string.Empty;

        public decimal Remuneration { get; set; }

        public int CompanyId { get; set; } 
    }
}
