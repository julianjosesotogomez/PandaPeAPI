
using PandaPeAPI.Domain.DTOs;
using PandaPeAPI.Domain.Entities.SelectionProcessEntities;
using PandaPeAPI.DTOs;

namespace PandaPeAPI.Application.Interface
{
    public interface ISelectionProcessApplication
    {
        public ResponseEndPointDTO<List<CandidatesDTO>> GetListCandidates();
    }
}
