
using AutoMapper;
using PandaPeAPI.Domain.DTOs;
using PandaPeAPI.Domain.Entities.SelectionProcessEntities;

namespace PandaPeAPI.Helpers
{
    public class AutomapperConfig : Profile
    {

        public AutomapperConfig()
        {
                
            CreateMap<CandidatesDTO, Candidates>().ReverseMap();
            CreateMap<CandidateExperiencesList, CandidateExperiences>().ReverseMap();
        }

    }
}
