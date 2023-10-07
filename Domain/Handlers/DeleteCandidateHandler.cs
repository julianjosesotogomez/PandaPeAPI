using MediatR;
using Microsoft.EntityFrameworkCore;
using PandaPeAPI.DataAccess.Contexts;
using PandaPeAPI.DTOs;
using PandaPeAPI.Infraestructure.Commands;

namespace PandaPeAPI.Domain.Handlers
{
    public class DeleteCandidateHandler : IRequestHandler<DeleteCandidate, ResponseEndPointDTO<bool>>
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
        public async Task<ResponseEndPointDTO<bool>> Handle(DeleteCandidate request, CancellationToken cancellationToken)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();

            var candidate = _selectionProcessContext.Candidates.Include(x=>x.CandidateExperiences).AsNoTracking().FirstOrDefault(x=>x.IdCandidate == request.IdCandidate);
            if (candidate == null)
            {
                response.ResponseMessage($"No se encuentra registro para el candidato", false);
            }
            else
            {
                _selectionProcessContext.Candidates.Remove(candidate);
                _selectionProcessContext.SaveChanges();

                response.ResponseMessage($"Se elimino corectamente el registro del candidato", true);
            }
            return response;
        }
        #endregion
    }
}
