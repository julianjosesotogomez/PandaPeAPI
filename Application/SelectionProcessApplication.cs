using MediatR;
using PandaPeAPI.Application.Interface;
using PandaPeAPI.Domain.DTOs;
using PandaPeAPI.Domain.Entities.SelectionProcessEntities;
using PandaPeAPI.Domain.Interface;
using PandaPeAPI.DTOs;
using PandaPeAPI.Infraestructure.Queries;

namespace PandaPeAPI.Application
{
    public class SelectionProcessApplication:ISelectionProcessApplication
    {
        #region Fields
        private readonly ISelectionProcessDomain _selectionProcessDomain;
        private readonly IMediator _mediator;
        #endregion
        #region Builder
        public SelectionProcessApplication(ISelectionProcessDomain selectionProcessDomain, IMediator mediator)
        {
            _selectionProcessDomain = selectionProcessDomain;
            _mediator = mediator;

        }
        #endregion
        #region Methods
        public ResponseEndPointDTO<List<CandidatesDTO>> GetListCandidates()
        {
            ResponseEndPointDTO<List<CandidatesDTO>> response = new ResponseEndPointDTO<List<CandidatesDTO>>();
            try
            {
                var listData = _mediator.Send(new GetRegisteredCandidates());
                response.Result = listData.Result;
            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }
        #endregion

    }
}
