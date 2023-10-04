using PandaPeAPI.Domain.Entities.SelectionProcessEntities;
using PandaPeAPI.Domain.Interface;

namespace PandaPeAPI.Domain
{
    public class SelectionProcessDomain:ISelectionProcessDomain
    {
        #region Fields

        #endregion
        #region Builder

        #endregion
        #region Methods
        public List<Candidates> GetListCandidates()
        {
            return new List<Candidates>();
        }
        #endregion
    }
}
