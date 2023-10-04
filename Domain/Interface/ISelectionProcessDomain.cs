using PandaPeAPI.Domain.Entities.SelectionProcessEntities;

namespace PandaPeAPI.Domain.Interface
{
    public interface ISelectionProcessDomain
    {
        public List<Candidates> GetListCandidates();
    }
}
