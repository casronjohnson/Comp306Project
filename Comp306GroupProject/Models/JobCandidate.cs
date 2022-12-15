using Microsoft.EntityFrameworkCore;

namespace Comp306GroupProject.Models

{
    [Keyless]
    public partial class JobCandidate
    {
        public int CandidateId { get; set; }
        public string? CandidateName { get; set; }
        public string? CandidateEmail { get; set; }
        public string? CandidateMajor { get; set; }
        public string? CandidateSkill { get; set; }
        public string? CandidateCity { get; set; }
        public string? CandidateCountry { get; set; }
    }
}
