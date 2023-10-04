using MediatR;
using PandaPeAPI.Domain.DTOs;

namespace PandaPeAPI.Infraestructure.Queries
{
    public record GetRegisteredCandidates:IRequest<List<CandidatesDTO>>;
}
