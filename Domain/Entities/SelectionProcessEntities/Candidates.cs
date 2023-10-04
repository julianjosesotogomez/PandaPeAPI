using System;
using System.Collections.Generic;

namespace PandaPeAPI.Domain.Entities.SelectionProcessEntities
{
    public partial class Candidates
    {
        public Candidates()
        {
            CandidateExperiences = new HashSet<CandidateExperiences>();
        }

        public Guid IdCandidate { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Email { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<CandidateExperiences> CandidateExperiences { get; set; }
    }
}
