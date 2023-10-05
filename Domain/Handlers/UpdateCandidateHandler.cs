using MediatR;
using Microsoft.EntityFrameworkCore;
using PandaPeAPI.DataAccess.Contexts;
using PandaPeAPI.Domain.Entities.SelectionProcessEntities;
using PandaPeAPI.Infraestructure.Commands;
using System.Linq;

namespace PandaPeAPI.Domain.Handlers
{
    public class UpdateCandidateHandler : IRequestHandler<UpdateCandidate, bool>
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
        public async  Task<bool> Handle(UpdateCandidate request, CancellationToken cancellationToken)
        {
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
                candidateUpdate.ModifiedDate = DateTime.Now;

                _selectionProcessContext.Candidates.Update(candidateUpdate);

                //Item filtrado el cual se quiere actualizar
                var selectExperience = request.requestUpdateCandidateDTO.ExperiencesUpdate.Where(x => candidate.CandidateExperiences != null && candidate.CandidateExperiences
                                                                                                    .Any(a=>a.IdCandidateExperience == x.IdCandidateExperience)).ToList();
                
                //Actualizacion para datos de CandidatesExpiriences
                foreach (var item in selectExperience)
                {
                    CandidateExperiences candidateExperienceUpdate = new CandidateExperiences();
                    candidateExperienceUpdate.IdCandidateExperience = item.IdCandidateExperience;
                    candidateExperienceUpdate.IdCandidate = candidate.IdCandidate;
                    candidateExperienceUpdate.Company=item.Company;
                    candidateExperienceUpdate.Job=item.Job;
                    candidateExperienceUpdate.Description=item.Description;
                    candidateExperienceUpdate.Salary=item.Salary;
                    candidateExperienceUpdate.BeginDate = item.BeginDate;
                    candidateExperienceUpdate.EndDate = item.EndDate;
                    candidateExperienceUpdate.ModifyDate = DateTime.Now;
                    
                   _selectionProcessContext.CandidateExperiences.Update(candidateExperienceUpdate);
                }

                _selectionProcessContext.SaveChanges();

                return true;
            }

            return false;
        }
        #endregion
    }
}
