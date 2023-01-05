namespace Q2P.Challenge.Domain.Core.DTO.Responses
{
    public class EmployeeResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public decimal Remuneration { get; set; }
        public int? CompanyId { get; set; }
        public CompanyResponseDto? Company { get; set; }
    }
}
