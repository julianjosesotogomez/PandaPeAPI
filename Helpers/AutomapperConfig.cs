
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

            //Mapeos de los DTO Para validacion de data 
            //RequestCreateCandidateDTO
            CreateMap<CandidatesDTO, RequestCreateCandidateDTO>().ReverseMap();
            CreateMap<CandidateExperiencesList, ExperiencesUpdate>().ReverseMap();
            //RequestUpdateCandidateDTO
            CreateMap<CandidatesDTO, RequestUpdateCandidateDTO>().ReverseMap();
            CreateMap<CandidateExperiencesList, Expiriences>().ReverseMap();
        }

    }
}
