using MediatR;
using PandaPeAPI.Application.Interface;
using PandaPeAPI.Domain.DTOs;
using PandaPeAPI.Domain.Entities.SelectionProcessEntities;

using PandaPeAPI.DTOs;
using PandaPeAPI.Infraestructure.Commands;
using PandaPeAPI.Infraestructure.Queries;

namespace PandaPeAPI.Application
{
    public class SelectionProcessApplication:ISelectionProcessApplication
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion
        #region Builder
        public SelectionProcessApplication( IMediator mediator)
        {
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
                if (listData.Result ==null)
                {
                    response.ResponseMessage("No se encuentran candidatos registrados en BD", false);
                }
                else
                {
                    response.Result = listData.Result;
                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }

        public ResponseEndPointDTO<bool> CreateCandidate(RequestCreateCandidateDTO requestCreateCandidateDTO)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();
            try
            {
                var insertData = _mediator.Send(new CreateCandidate(requestCreateCandidateDTO));
                if (insertData.IsFaulted)
                {
                    response.ResponseMessage($"Se presento un error al ingresar datos del Candidato", false, insertData.Exception.ToString());
                }
                else
                {
                    response=insertData.Result;
                }
            }
            catch (Exception ex)
            {

                response.ResponseMessage("Error en el sistema", false, ex.Message);
            }
            return response;
        }

        public ResponseEndPointDTO<bool> UpdateCandidate(RequestUpdateCandidateDTO requestUpdateCandidateDTO)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();
            try
            {
                var updateData = _mediator.Send(new UpdateCandidate(requestUpdateCandidateDTO));
                if (updateData.IsFaulted)
                {
                    response.ResponseMessage($"Se presento un error al actualizar datos del Candidato", false, updateData.Exception.ToString());
                }
                else
                {
                    response = updateData.Result;
                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage("Error en el sistema", false, ex.Message); ;
            }
            return response;
        }

        public ResponseEndPointDTO<bool>DeleteCandidate(Guid IdCandidate)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();
            try
            {
                var delete = _mediator.Send(new DeleteCandidate(IdCandidate));
                if (delete.IsFaulted)
                {
                    response.ResponseMessage($"Se presento un error al eliminar el Candidato", false, delete.Exception.ToString());
                }
                else if(!delete.Result)
                {
                    response.ResponseMessage($"No se puede eliminar el registro", false);
                }
                else
                {
                    response.ResponseMessage("Se realizo correctamente la eliminacion de datos del Candidato", true);
                }
            }
            catch (Exception ex)
            {

                response.ResponseMessage("Error en el sistema", false, ex.Message); ;
            }
            return response;
        }


        #endregion

    }
}
