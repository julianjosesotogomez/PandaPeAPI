
using PandaPeAPI.Domain.DTOs;
using PandaPeAPI.Domain.Entities.SelectionProcessEntities;
using PandaPeAPI.DTOs;

namespace PandaPeAPI.Application.Interface
{
    public interface ISelectionProcessApplication
    {
        public ResponseEndPointDTO<List<CandidatesDTO>> GetListCandidates();
        public ResponseEndPointDTO<bool> CreateCandidate(RequestCreateCandidateDTO requestCreateCandidateDTO);
        public ResponseEndPointDTO<bool> UpdateCandidate(RequestUpdateCandidateDTO requestUpdateCandidateDTO);
        public ResponseEndPointDTO<bool> DeleteCandidate(Guid IdCandidate);
    }
}
