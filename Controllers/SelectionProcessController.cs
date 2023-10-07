using Microsoft.AspNetCore.Mvc;
using PandaPeAPI.Application.Interface;
using PandaPeAPI.Domain.DTOs;
using PandaPeAPI.Domain.Entities.SelectionProcessEntities;
using PandaPeAPI.DTOs;

namespace PandaPeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SelectionProcessController : ControllerBase
    {
        #region Field
        private readonly ISelectionProcessApplication _selectionProcessApplication;
        #endregion

        #region Builder
        public SelectionProcessController(ISelectionProcessApplication selectionProcessApplication)
        {
            _selectionProcessApplication = selectionProcessApplication;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Servicio que permite obtener el listado de los candidatos 
        /// </summary>
        /// <returns>Listado de todos los candidatos con sus experiencias laborales </returns>
        [HttpGet]
        [Route(nameof(SelectionProcessController.GetListCandidates))]
        public async Task<ResponseEndPointDTO<List<CandidatesDTO>>> GetListCandidates()
        {
            return await Task.Run(() =>
            {
                return _selectionProcessApplication.GetListCandidates();
            });
        }
        /// <summary>
        /// Servicio para crear candidatos
        /// </summary>
        /// <param name="requestCreateCandidateDTO"></param>
        /// <returns>Confirmación de la creación de un candidato con o sin experiencias laborales</returns>
        [HttpPost]
        [Route(nameof(SelectionProcessController.CreateCandidate))]
        public async Task<ResponseEndPointDTO<bool>> CreateCandidate(RequestCreateCandidateDTO requestCreateCandidateDTO)
        {
            return await Task.Run(() =>
            {
                return _selectionProcessApplication.CreateCandidate(requestCreateCandidateDTO);
            });
        }
        /// <summary>
        /// Servicio para actualizar los datos por candidato
        /// </summary>
        /// <param name="requestUpdateCandidateDTO"></param>
        /// <returns>Confirmación de la actualización</returns>
        [HttpPut]
        [Route(nameof (SelectionProcessController.UpdateCandidate))]
        public async Task<ResponseEndPointDTO<bool>> UpdateCandidate([FromBody] RequestUpdateCandidateDTO requestUpdateCandidateDTO)
        {
            return await Task.Run(() =>
            {
                return _selectionProcessApplication.UpdateCandidate(requestUpdateCandidateDTO);
            });
        }
        /// <summary>
        /// Servicio que me permite elimiar registro de candidatos
        /// </summary>
        /// <param name="IdCandidate"></param>
        /// <returns>Confirmación de la eliminacion del candidato</returns>
        [HttpDelete]
        [Route(nameof(SelectionProcessController.DeleteCandidate))]
        public async Task<ResponseEndPointDTO<bool>>DeleteCandidate(Guid IdCandidate)
        {
            return await Task.Run(() =>
            {
                return _selectionProcessApplication.DeleteCandidate(IdCandidate);
            });
        }
        #endregion
    }
}
