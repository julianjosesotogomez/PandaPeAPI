using MediatR;
using Microsoft.EntityFrameworkCore;
using PandaPeAPI.DataAccess.Contexts;
using PandaPeAPI.Infraestructure.Commands;

namespace PandaPeAPI.Domain.Handlers
{
    public class DeleteCandidateHandler : IRequestHandler<DeleteCandidate, bool>
    {
        #region Fields
        private readonly SelectionProcessContext _selectionProcessContext;
        #endregion
        #region Builder
        public DeleteCandidateHandler(SelectionProcessContext selectionProcessContext)
        {
            _selectionProcessContext = selectionProcessContext;
        }
        #endregion
        #region Handler
        public async Task<bool> Handle(DeleteCandidate request, CancellationToken cancellationToken)
        {
            var candidate = _selectionProcessContext.Candidates.Include(x=>x.CandidateExperiences).AsNoTracking().FirstOrDefault(x=>x.IdCandidate == request.IdCandidate);
            if (candidate == null)
                return false;

            _selectionProcessContext.Candidates.Remove(candidate);
            _selectionProcessContext.SaveChanges();
            return true;
        }
        #endregion
    }
}
