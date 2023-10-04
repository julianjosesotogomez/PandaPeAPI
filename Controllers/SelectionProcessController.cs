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
        [HttpGet]
        [Route(nameof(SelectionProcessController.GetListCandidates))]
        public async Task<ResponseEndPointDTO<List<CandidatesDTO>>> GetListCandidates()
        {
            return await Task.Run(() =>
            {
                return _selectionProcessApplication.GetListCandidates();
            });
        }
        #endregion
    }
}
