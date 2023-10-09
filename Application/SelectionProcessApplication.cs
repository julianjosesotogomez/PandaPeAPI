using AutoMapper;
using MediatR;
using PandaPeAPI.Application.Interface;
using PandaPeAPI.Domain.DTOs;
using PandaPeAPI.DTOs;
using PandaPeAPI.Infraestructure.Commands;
using PandaPeAPI.Infraestructure.Queries;
using System.Threading.Tasks;

namespace PandaPeAPI.Application
{
    public class SelectionProcessApplication:ISelectionProcessApplication
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        #endregion
        #region Builder
        public SelectionProcessApplication( IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public ResponseEndPointDTO<List<CandidatesDTO>> GetListCandidates()
        {
            ResponseEndPointDTO<List<CandidatesDTO>> response = new ResponseEndPointDTO<List<CandidatesDTO>>();
            try
            { 
                var listData = _mediator.Send(new GetRegisteredCandidates());
                if (listData.Result?.Count<0)
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
                var candidate = _mapper.Map<CandidatesDTO>(requestCreateCandidateDTO);
                var validateData = ValidateData(candidate);
                if (validateData != null)
                {
                    response.ResponseMessage(validateData,false);
                }
                else
                {
                    var insertData = _mediator.Send(new CreateCandidate(requestCreateCandidateDTO));
                    if (insertData.IsFaulted)
                    {
                        response.ResponseMessage($"Se presento un error al ingresar datos del Candidato", false, insertData.Exception.ToString());
                    }
                    else
                    {
                        response = insertData.Result;
                    }
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
                var candidate = _mapper.Map<CandidatesDTO>(requestUpdateCandidateDTO);
                var validateData = ValidateData(candidate);
                if (validateData != null)
                {
                    response.ResponseMessage(validateData, false);
                }
                else
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
                else
                {
                    response= delete.Result;
                }
            }
            catch (Exception ex)
            {

                response.ResponseMessage("Error en el sistema", false, ex.Message); ;
            }
            return response;
        }


        #endregion

        #region Private Method
        /// <summary>
        /// Validación de data ingresada
        /// </summary>
        /// <param name="partido"></param>
        /// <returns></returns>
        private string ValidateData(CandidatesDTO candidate)
        {
            if (candidate.CandidateExperiences?.Count > 0) 
            {
                foreach (var item in candidate.CandidateExperiences)
                {
                    // Validar el formato del salario verificamos que tenga 8 dígitos en total 6 en su parte entera y 2 decimales
                    string salaryString = item.Salary.Value.ToString("0.00");
                    if (!System.Text.RegularExpressions.Regex.IsMatch(salaryString, @"^\d{6}.\d{2}$"))
                    {
                        return $"El formato de Salary para el valor {item.Salary} es incorrecto. Debe ser Debe ser NUMERIC(8,2)."; // La validación es incorecta
                    }
                }
            }
            return null;
        }
        #endregion

    }
}
