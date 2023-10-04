using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PandaPeAPI.DataAccess.Contexts;
using PandaPeAPI.Domain.DTOs;
using PandaPeAPI.Infraestructure.Queries;

namespace PandaPeAPI.Domain.Handlers
{
    public class GetRegisterCandidateHandler : IRequestHandler<GetRegisteredCandidates, List<CandidatesDTO>>
    {
        #region Fields
        private readonly SelectionProcessContext _selectionProcessContext;
        private readonly IMapper _mapper;
        #endregion
        #region Builder
        public GetRegisterCandidateHandler(SelectionProcessContext selectionProcessContext, IMapper mapper)
        {
            _selectionProcessContext = selectionProcessContext;
            _mapper = mapper;
        }
        #endregion
        #region Handle
        public async Task<List<CandidatesDTO>> Handle(GetRegisteredCandidates request, CancellationToken cancellationToken)
        {
            var task = await _selectionProcessContext.Candidates.ToListAsync(cancellationToken);
            return _mapper.Map<List<CandidatesDTO>>(task);
        }
        #endregion
    }
}
