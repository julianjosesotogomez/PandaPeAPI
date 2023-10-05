using MediatR;
using PandaPeAPI.DataAccess.Contexts;
using PandaPeAPI.Domain.Entities.SelectionProcessEntities;
using PandaPeAPI.Infraestructure.Commands;

namespace PandaPeAPI.Domain.Handlers
{
    public class CreateCandidateHandler : IRequestHandler<CreateCandidate, bool>
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
        public async Task<bool> Handle(CreateCandidate request, CancellationToken cancellationToken)
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
                CandidateExperiences expirience = new CandidateExperiences();
                expirience.IdCandidateExperience = Guid.NewGuid();
                expirience.IdCandidate = candidate.IdCandidate;
                expirience.Company = item.Company;
                expirience.Job = item.Job;
                expirience.Description = item.Description;
                expirience.Salary = item.Salary;
                expirience.BeginDate = item.BeginDate;
                expirience.EndDate = item.EndDate; 
                expirience.InsertDate=DateTime.Now;

                _selectionProcessContext.CandidateExperiences.Add(expirience);

            }

            _selectionProcessContext.SaveChanges();

            return true;
        }
        #endregion
    }
}
