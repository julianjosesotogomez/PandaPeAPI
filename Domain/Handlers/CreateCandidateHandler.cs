using MediatR;
using Microsoft.EntityFrameworkCore;
using PandaPeAPI.DataAccess.Contexts;
using PandaPeAPI.Domain.Entities.SelectionProcessEntities;
using PandaPeAPI.DTOs;
using PandaPeAPI.Infraestructure.Commands;

namespace PandaPeAPI.Domain.Handlers
{
    public class CreateCandidateHandler : IRequestHandler<CreateCandidate, ResponseEndPointDTO<bool>>
    {
        #region Fields
        private readonly SelectionProcessContext _selectionProcessContext;
        #endregion
        #region Builder
        public CreateCandidateHandler(SelectionProcessContext selectionProcessContext)
        {
            _selectionProcessContext = selectionProcessContext;
        }
        #endregion
        #region Handler
        public async Task<ResponseEndPointDTO<bool>> Handle(CreateCandidate request, CancellationToken cancellationToken)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();

            var validateEmail = _selectionProcessContext.Candidates.AsNoTracking().FirstOrDefault(x=>x.Email==request.requestCreateCandidateDTO.Email);
            if (validateEmail != null) 
            {
                 response.ResponseMessage($"Ya se encuentra registrado un Candidato con el email {validateEmail.Email}", false);
            }
            else
            {
                Candidates candidate = new Candidates();
                candidate.IdCandidate = Guid.NewGuid();
                candidate.Name = request.requestCreateCandidateDTO.Name;
                candidate.Surname = request.requestCreateCandidateDTO.Surname;
                candidate.Birthdate = request.requestCreateCandidateDTO.Birthdate;
                candidate.Email = request.requestCreateCandidateDTO.Email;
                candidate.InsertDate = DateTime.Now;

                _selectionProcessContext.Candidates.Add(candidate);

                foreach (var item in request.requestCreateCandidateDTO.Expiriences)
                {
                    CandidateExperiences experience = new CandidateExperiences();
                    experience.IdCandidateExperience = Guid.NewGuid();
                    experience.IdCandidate = candidate.IdCandidate;
                    experience.Company = item.Company;
                    experience.Job = item.Job;
                    experience.Description = item.Description;
                    experience.Salary = item.Salary;
                    experience.BeginDate = item.BeginDate;
                    experience.EndDate = item.EndDate;
                    experience.InsertDate = DateTime.Now;

                    _selectionProcessContext.CandidateExperiences.Add(experience);

                }

                _selectionProcessContext.SaveChanges();

                response.ResponseMessage($"Se registro correctamente el registro para {candidate.Name}", true);
            }

            return response;
        }
        #endregion
    }
}
