namespace PandaPeAPI.Domain.DTOs
{
    public class CandidatesDTO
    {
        public Guid IdCandidate { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Email { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
