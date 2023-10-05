using MediatR;
using Microsoft.EntityFrameworkCore;
using PandaPeAPI.DataAccess.Contexts;
using PandaPeAPI.Domain.Entities.SelectionProcessEntities;
using PandaPeAPI.DTOs;
using PandaPeAPI.Infraestructure.Commands;
using System.Linq;

namespace PandaPeAPI.Domain.Handlers
{
    public class UpdateCandidateHandler : IRequestHandler<UpdateCandidate, ResponseEndPointDTO<bool>>
    {
        #region Fields
        private readonly SelectionProcessContext _selectionProcessContext;
        #endregion
        #region Builder
        public UpdateCandidateHandler(SelectionProcessContext selectionProcessContext)
        {
            _selectionProcessContext = selectionProcessContext;
        }
        #endregion
        #region Handler
        public async  Task<ResponseEndPointDTO<bool>> Handle(UpdateCandidate request, CancellationToken cancellationToken)
        {
            ResponseEndPointDTO<bool> response = new ResponseEndPointDTO<bool>();

            var candidate = _selectionProcessContext.Candidates.Include(x=>x.CandidateExperiences).AsNoTracking().FirstOrDefault(x=>x.IdCandidate == request.requestUpdateCandidateDTO.IdCandidate);
            
            if (candidate != null)
            {
                //Actualizacion para datos de Candidates
                Candidates candidateUpdate = new Candidates();
                candidateUpdate.IdCandidate = candidate.IdCandidate;
                candidateUpdate.Name = request.requestUpdateCandidateDTO.Name is null? candidate.Name: request.requestUpdateCandidateDTO.Name;
                candidateUpdate.Surname = request.requestUpdateCandidateDTO.Surname is null ? candidate.Surname : request.requestUpdateCandidateDTO.Surname;
                candidateUpdate.Birthdate = request.requestUpdateCandidateDTO.Birthdate is null ? candidate.Birthdate : request.requestUpdateCandidateDTO.Birthdate;
                candidateUpdate.Email=request.requestUpdateCandidateDTO.Email is null?candidate.Email: request.requestUpdateCandidateDTO.Email;
                candidateUpdate.InsertDate = candidate.InsertDate;
                candidateUpdate.ModifiedDate = DateTime.Now;

                _selectionProcessContext.Candidates.Update(candidateUpdate);


                //Actualizacion para datos de CandidatesExpiriences
                foreach (var item in request.requestUpdateCandidateDTO.ExperiencesUpdate)
                {
                    //Busqueda del registro en tabla CandidateExperiences
                    var experience = _selectionProcessContext.CandidateExperiences.AsNoTracking().FirstOrDefault(x=>x.IdCandidateExperience == item.IdCandidateExperience);

                    if (experience != null)
                    {
                        CandidateExperiences candidateExperienceUpdate = new CandidateExperiences();
                        candidateExperienceUpdate.IdCandidateExperience = experience.IdCandidateExperience;
                        candidateExperienceUpdate.IdCandidate = experience.IdCandidate;
                        candidateExperienceUpdate.Company = item.Company is null ? experience.Company : item.Company;
                        candidateExperienceUpdate.Job = item.Job is null ? experience.Job : item.Job;
                        candidateExperienceUpdate.Description = item.Description is null ? experience.Description : item.Description;
                        candidateExperienceUpdate.Salary = item.Salary is null ? experience.Salary : item.Salary;
                        candidateExperienceUpdate.BeginDate = item.BeginDate is null ? experience.BeginDate : item.BeginDate;
                        candidateExperienceUpdate.EndDate = item.EndDate is null ? experience.EndDate : item.EndDate;
                        candidateExperienceUpdate.InsertDate = experience.InsertDate;
                        candidateExperienceUpdate.ModifyDate = DateTime.Now;

                        _selectionProcessContext.CandidateExperiences.Update(candidateExperienceUpdate);
                    }
                    else
                    {
                        response.ResponseMessage($"No se encuentra registro de la experiencia {item.Job} para el candidato {request.requestUpdateCandidateDTO.Name}", false);
                        return response;
                    }
                }

                _selectionProcessContext.SaveChanges();

                response.ResponseMessage($"Se realizo correctamente la actializacion de datos", true);
            }
            else
            {
                response.ResponseMessage($"No se encuentra registro del candidato", false);
            }

            return response;
        }
        #endregion
    }
}
